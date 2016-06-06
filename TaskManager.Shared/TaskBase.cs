using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading;
using Couchbase.Lite;
using Couchbase.Lite.Auth;
using Newtonsoft.Json.Linq;
using TaskManager.Common;

namespace TaskManager.Shared
{
    public class TaskProxy : ObjectProxy<Task>
    {
        public Document Document { get; }

        public TaskProxy(Task task, Document document) : base(task)
        {
            Document = document;
        }

        protected override void OnMethodCall(MethodBase method)
        {
            
        }
    }

    public class TaskBase : ObjectDatabase<Task>
    {
        public override ICollection<Task> Objects
        {
            get
            {
                if (tasks == null)
                    Load();

                return tasks;
            }
        }

        private Database database;
        private Uri uri;
        private IAuthenticator authenticator;

        private List<Task> tasks;

        private List<Tuple<Task, Document>> taskDocuments = new List<Tuple<Task, Document>>();

        public TaskBase(string address, string username, string password)
        {
            Manager manager = Manager.SharedInstance;
            database = manager.GetDatabase("tasks");

            uri = new Uri(address);
            authenticator = AuthenticatorFactory.CreateBasicAuthenticator(username, password);
        }

        public override void Load()
        {
           /* 

            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection(@"Data Source=D:\Projets\C#\TaskManager\Samples\Tasks.db");
            connection.Open();

            //Clear();

            TaskDatabase db = new TaskDatabase(connection);
            tasks = db.Tasks;

            return;
            
            /**/

            tasks = new List<Task>();

            // Force sync to sevrer
            Replication replication = database.CreatePullReplication(uri);
            replication.Authenticator = authenticator;
            replication.Run();
            
            Query query = database.CreateAllDocumentsQuery();
            Document[] documents = query.Run().Select(r => r.Document).ToArray();

            Dictionary<string, Tag> tags = new Dictionary<string, Tag>();

            // First pass to create task objects
            foreach (Document document in documents)
            {
                Task task = new Task();

                task.Name = document.GetProperty<string>("name");
                task.Description = document.GetProperty<string>("description");
                task.Date = document.GetProperty<DateTime?>("date");

                // Tags
                JArray tagNames = document.GetProperty("tags") as JArray;
                if (tagNames != null)
                {
                    foreach (JToken tagName in tagNames)
                    {
                        string name = tagName.Value<string>();

                        Tag tag;
                        if (!tags.TryGetValue(name, out tag))
                            tags.Add(name, tag = new Tag(name, TagColor.Black));

                        task.Tags.Add(tag);
                    }
                }

                // Attachements
                foreach (Couchbase.Lite.Attachment dbAttachment in document.CurrentRevision.Attachments)
                {
                    Common.Attachment attachment = new Common.Attachment();

                    attachment.Name = dbAttachment.Name;
                    attachment.Type = AttachmentType.Binary;
                    attachment.Data = dbAttachment.ContentStream.ReadBytes();

                    task.Attachements.Add(attachment);
                }

                // Metadata
                JObject metadata = document.GetProperty("metadata") as JObject;
                if (metadata != null)
                {
                    foreach (var pair in metadata)
                        task.Metadata.Add(pair.Key, pair.Value);
                }

                taskDocuments.Add(Tuple.Create(task, document));
                tasks.Add(task);
            }

            // Second pass to link them
            foreach (Document document in documents)
            {
                Task task = taskDocuments.First(p => p.Item2 == document).Item1;

                JArray children = document.GetProperty("children") as JArray;
                if (children != null)
                {
                    foreach (JObject childDocument in children)
                    {
                        string childDocumentId = childDocument["_id"].Value<string>();

                        Task childTask = taskDocuments.FirstOrDefault(p => p.Item2.Id == childDocumentId)?.Item1;
                        if (childTask == null)
                            continue;

                        task.Children.Add(childTask);
                        childTask.Parents.Add(task);
                    }
                }
            }
        }
        public override void Save()
        {
            // Save everything
            database.RunInTransaction(new RunInTransactionDelegate(() =>
            {
                // Delete unused documents
                Task[] oldTasks = taskDocuments.Select(p => p.Item1).Except(tasks).ToArray();
                foreach (Task oldTask in oldTasks)
                    taskDocuments.First(p => p.Item1 == oldTask).Item2.Delete();

                // Create new documents
                Task[] newTasks = tasks.Except(taskDocuments.Select(p => p.Item1)).ToArray();
                foreach (Task newTask in newTasks)
                    taskDocuments.Add(Tuple.Create(newTask, database.CreateDocument()));

                // Update everything
                foreach (var pair in taskDocuments)
                {
                    Task task = pair.Item1;
                    if (oldTasks.Contains(task))
                        continue;

                    pair.Item2.Update(r =>
                    {
                        IDictionary<string, object> properties = r.Properties;

                        properties["name"] = task.Name;
                        properties["description"] = task.Description;
                        properties["date"] = task.Date;
                        properties["tags"] = new JArray(task.Tags.Select(t => t.Name));
                        properties["metadata"] = new JObject(task.Metadata.Select(m => new JProperty(m.Key, m.Value)));
                        properties["children"] = new JArray(task.Children.Select(c => new JObject(new JProperty("_id", taskDocuments.First(p => p.Item1 == c).Item2.Id))));

                        return true;
                    });
                }

                return true;
            }));

            // Then force sync to sevrer
            Replication replication = database.CreatePushReplication(uri);
            replication.Authenticator = authenticator;
            replication.Run();
        }

        public void Clear()
        {
            // Remove every documents
            database.RunInTransaction(new RunInTransactionDelegate(() =>
            {
                Query query = database.CreateAllDocumentsQuery();

                foreach (QueryRow row in query.Run())
                    row.Document.Delete();

                return true;
            }));

            // Then force sync to sevrer
            Replication replication = database.CreatePushReplication(uri);
            replication.Authenticator = authenticator;
            replication.Run();
        }
    }

    internal static class ReplicationExtensions
    {
        internal static void Run(this Replication me)
        {
            if (me.Continuous)
                throw new NotSupportedException();

            ManualResetEvent resetEvent = new ManualResetEvent(false);

            EventHandler<ReplicationChangeEventArgs> handler = (s, e) =>
            {
                if (e.Status == ReplicationStatus.Stopped)
                    resetEvent.Set();
            };

            me.Changed += handler;
            me.Start();

            resetEvent.WaitOne();
            me.Changed -= handler;
        }
    }
}