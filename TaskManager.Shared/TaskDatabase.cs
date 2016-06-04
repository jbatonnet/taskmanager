using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

using TaskManager.Common;

namespace TaskManager.Shared
{
    public class TaskDatabase
    {
        public List<Task> Tasks
        {
            get
            {
                if (tasks == null)
                    Reload();

                return tasks;
            }
        }

        private DbConnection connection;
        private List<Task> tasks;

        public TaskDatabase(DbConnection connection)
        {
            this.connection = connection;
        }

        public void Reload()
        {
            tasks = new List<Task>();

            // Get tasks
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT id, name, description, date FROM tasks";

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Task task = new Task()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Date = reader.IsDBNull(3) ? (DateTime?)null : DateTime.Parse(reader.GetString(3))
                        };

                        tasks.Add(task);
                    }
                }
            }

            // Get parents
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT parent_id, child_id FROM tasks_relations";

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int parentId = reader.GetInt32(0);
                        int childId = reader.GetInt32(1);

                        Task parent = tasks.First(t => t.Id == parentId);
                        Task child = tasks.First(t => t.Id == childId);

                        parent.Children.Add(child);
                        child.Parents.Add(parent);
                    }
                }
            }

            Dictionary<int, Tag> tags = new Dictionary<int, Tag>();

            // Get tags
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT id, name, color FROM tags";

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tag tag = new Tag()
                        {
                            Name = reader.GetString(1),
                            Color = reader.IsDBNull(2) ? TagColor.None : (TagColor)Enum.Parse(typeof(TagColor), reader.GetString(2), true)
                        };

                        tags.Add(reader.GetInt32(0), tag);
                    }
                }
            }

            // Get task tags
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT task_id, tag_id FROM tasks_tags";

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int taskId = reader.GetInt32(0);
                        int tagId = reader.GetInt32(1);

                        Task task = tasks.First(t => t.Id == taskId);
                        Tag tag = tags[tagId];

                        task.Tags.Add(tag);
                    }
                }
            }

            // Get attachements
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT task_id, name, type_id, data FROM attachements";

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Attachment attachement = new Attachment()
                        {
                            Name = reader.GetString(1),
                            Type = reader.IsDBNull(2) ? AttachmentType.Binary : (AttachmentType)Enum.Parse(typeof(AttachmentType), reader.GetString(2), true)
                        };

                        attachement.Data = (byte[])reader.GetValue(3);

                        /*using (Stream dataStream = reader.GetStream(3))
                        using (BinaryReader binaryStream = new BinaryReader(dataStream))
                            attachement.Data = binaryStream.ReadBytes((int)dataStream.Length);*/

                        int taskId = reader.GetInt32(0);

                        Task task = tasks.First(t => t.Id == taskId);
                        task.Attachements.Add(attachement);
                    }
                }
            }

            // Get metadata
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT task_id, `key`, `value` FROM metadata";

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader.GetString(1);
                        string value = reader.IsDBNull(2) ? null : reader.GetString(2);

                        int taskId = reader.GetInt32(0);

                        Task task = tasks.First(t => t.Id == taskId);
                        task.Metadata.Add(key, value);
                    }
                }
            }
        }
        public void Save()
        {
            Func<string, int[]> list = table =>
            {
                List<int> ids = new List<int>();

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT id FROM " + table;

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            ids.Add(reader.GetInt32(0));
                    }
                }

                return ids.ToArray();
            };

            // Uniquify task ids
            int id = Math.Max(tasks.Max(t => t.Id), 0);
            foreach (Task task in tasks)
            {
                if (task.Id == -1 || tasks.Count(t => t.Id == task.Id) > 1)
                    task.Id = id++;
            }

            // Get distinct tags
            Tag[] tags = tasks.SelectMany(t => t.Tags).Distinct().ToArray();

            List<string> queries = new List<string>();

            // List existing things
            int[] taskIds = list("tasks");
            int[] tagIds = list("tags");

            // Remove deleted tasks
            int[] taskIdsToDelete = taskIds.Where(i => !tasks.Any(t => t.Id == i)).ToArray();
            if (taskIdsToDelete.Length > 0)
                queries.Add("DELETE FROM tasks WHERE id IN (" + taskIdsToDelete.Join(", ") + ")");

            // Update modified tasks
            foreach (Task task in tasks)
                if (taskIds.Contains(task.Id))
                    queries.Add(string.Format("UPDATE tasks SET name = '{0}', description = '{1}', date = {2} WHERE id = {3}",
                        ProtectValue(task.Name),
                        ProtectValue(task.Description),
                        task.Date == null ? "NULL" : ("'" + task.Date.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'"),
                        task.Id));

            // Insert new tasks
            Task[] tasksToInsert = tasks.Where(t => !taskIds.Contains(t.Id)).ToArray();
            if (tasksToInsert.Length > 0)
            {
                queries.Add("INSERT INTO tasks (id, name, description, date) VALUES " + string.Join(", ",
                    tasksToInsert.Select(t => string.Format("({0}, '{1}', '{2}', {3})",
                        t.Id,
                        ProtectValue(t.Name),
                        ProtectValue(t.Description),
                        t.Date == null ? "NULL" : ("'" + t.Date.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'")))));
            }

            // Update tasks relations
            queries.Add("DELETE FROM tasks_relations");
            List<string> taskRelations = new List<string>();
            foreach (Task task in tasks)
                foreach (Task parent in task.Parents)
                    taskRelations.Add(string.Format("({0}, {1})", parent.Id, task.Id));
            if (taskRelations.Count > 0)
                queries.Add("INSERT INTO tasks_relations (parent_id, child_id) VALUES " + taskRelations.Join(", "));

            // Save attachements
            //queries.Add("DELETE FROM attachements");
            //foreach (Task task in tasks)
            //    foreach (Attachement attachement in task.Attachements)
            //        queries.Add(string.Format("INSERT INTO attachements (task_id, name, type_id, data) VALUES ({0}, '{1}', {2}, '{3}')",
            //            task.Id,
            //            ProtectValue(attachement.Name),
            //            attachement.Type,
            //            attachement.Data));

            // Save metadata
            queries.Add("DELETE FROM metadata");
            List<string> taskMetadata = new List<string>();
            foreach (Task task in tasks)
                foreach (KeyValuePair<string, object> metadata in task.Metadata)
                    taskMetadata.Add(string.Format("({0}, '{1}', '{2}')",
                        task.Id,
                        ProtectValue(metadata.Key),
                        metadata.Value.ToString()));
            if (taskMetadata.Count > 0)
                queries.Add("INSERT INTO metadata (task_id, `key`, `value`) VALUES " + taskMetadata.Join(", "));

            // TODO: Save tags

            // Delete attachements
            queries.Add("DELETE FROM attachements");

            // Execute all commands
            for (int i = 0; i < queries.Count; i++)
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Join(";", queries[i]);
                    command.ExecuteNonQuery();
                }
            }

            // Save attachements
            queries.Add("DELETE FROM attachements");
            foreach (Task task in tasks)
                foreach (Attachment attachement in task.Attachements)
                {
                    using (DbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("INSERT INTO attachements (task_id, name, type_id, data) VALUES ({0}, '{1}', {2}, @attachement_data)",
                            task.Id,
                            ProtectValue(attachement.Name),
                            (int)attachement.Type);

                        DbParameter parameter = command.CreateParameter();
                        parameter.ParameterName = "@attachement_data";
                        parameter.Value = attachement.Data;
                        command.Parameters.Add(parameter);

                        command.ExecuteNonQuery();
                    }
                }
        }

        private static string ProtectValue(string value)
        {
            if (value == null)
                return null;

            return value.Replace("\\", "\\\\")
                        .Replace("'", "''");
        }

#if DEBUG
        public void InsertDebugData()
        {
            if (tasks == null)
                tasks = new List<Task>();
            else
                tasks.Clear();

            // Tasks hierachy
            Task projectsTask = new Task() { Name = "Projects" };
                Task systemTask = new Task() { Name = "System", Description = "An operating system built from scratch" };
                    Task interfaceTask = new Task() { Name = "Interface" };
                    Task driversTask = new Task() { Name = "Drivers" };
                        Task networkTask = new Task() { Name = "Network" };
                        Task threeDTask = new Task() { Name = "3D" };
                        Task usbTask = new Task() { Name = "USB" };
                Task flowTomatorTask = new Task() { Name = "FlowTomator", Description = "A nodal automation tool" };
                    Task desktopTask = new Task() { Name = "Desktop" };
                    Task androidTask = new Task() { Name = "Android" };
                Task smartSyncTask = new Task() { Name = "SmartSync", Description = "A synchronization and backup utility" };
                    Task pluginsTask = new Task() { Name = "Plugins" };
                        Task adbTask = new Task() { Name = "Adb" };
            Task lifeTask = new Task() { Name = "Life" };
                Task recipesTask = new Task() { Name = "Recipes" };
                    Task crepesTask = new Task() { Name = "Crepes" };
                    Task mugCakeTask = new Task() { Name = "Mug cake" };
                    Task cakeSaleTask = new Task() { Name = "Cake sale" };
            Task contactsTask = new Task() { Name = "Contacts" };
                Task adelineTask = new Task() { Name = "Adeline" };

            tasks.AddRange(projectsTask, systemTask, interfaceTask, driversTask, networkTask, threeDTask, usbTask, flowTomatorTask, desktopTask, androidTask, smartSyncTask, pluginsTask, adbTask, lifeTask, recipesTask, crepesTask, mugCakeTask, cakeSaleTask, contactsTask, adelineTask);

            // Task relations
            projectsTask.Children.AddRange(systemTask, flowTomatorTask, smartSyncTask);
            systemTask.Children.AddRange(interfaceTask, driversTask);
            driversTask.Children.AddRange(networkTask, threeDTask, usbTask);
            flowTomatorTask.Children.AddRange(desktopTask, androidTask);
            smartSyncTask.Children.AddRange(pluginsTask);
            pluginsTask.Children.AddRange(adbTask);
            lifeTask.Children.AddRange(recipesTask);
            recipesTask.Children.AddRange(crepesTask, mugCakeTask, cakeSaleTask);
            contactsTask.Children.AddRange(adelineTask);

            // Build parents
            foreach (Task task in tasks)
                foreach (Task child in task.Children)
                    child.Parents.Add(task);

            // Add tags
            Tag uiTag = new Tag("UI/UX", TagColor.Black);
            Tag csTag = new Tag("C#", TagColor.Black);
            Tag androidTag = new Tag("Android", TagColor.Black);
            Tag cppTag = new Tag("C++", TagColor.Black);

            // Add some metadata
            ContactModule adelineContact = adelineTask.GetModule<ContactModule>();
            adelineContact.Name = "Adeline Gostner";
            adelineContact.Birthday = new DateTime(1992, 1, 1);

            // Save debug data
            Save();
        }
#endif
    }
}