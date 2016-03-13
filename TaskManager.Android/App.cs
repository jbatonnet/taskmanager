using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Utilities;
using Android.Views;
using Android.Widget;

using TaskManager.Shared;

namespace TaskManager.Android
{
    public class App
    {
        public const string Name = "TaskManager";
        public static TaskDatabase Database { get; private set; }

        private static bool initialized = false;
        
        public static void Initialize(Context context)
        {
            if (initialized) return;
            initialized = true;

            // Connect to local database
            AndroidDatabaseConnection connection = new AndroidDatabaseConnection(context, "Tasks.db");
            connection.VersionUpgraded += Connection_VersionUpgraded;
            connection.Open();

            // Setup tasks database
            Database = new TaskDatabase(connection);
        }

        private static void Connection_VersionUpgraded(AndroidDatabaseConnection connection, int oldVersion, int newVersion)
        {
            List<string> queries = new List<string>();

            queries.Add("CREATE TABLE tasks (id INTEGER NOT NULL, name TEXT NOT NULL, description TEXT, date TEXT, PRIMARY KEY (id))");
            queries.Add("CREATE TABLE tasks_relations (parent_id INTEGER NOT NULL, child_id INTEGER NOT NULL, PRIMARY KEY (parent_id, child_id))");
            queries.Add("CREATE TABLE tags (id INTEGER NOT NULL, name TEXT NOT NULL, color TEXT, PRIMARY KEY (id))");
            queries.Add("CREATE TABLE tasks_tags (task_id INTEGER NOT NULL, tag_id INTEGER NOT NULL, PRIMARY KEY (task_id, tag_id))");
            queries.Add("CREATE TABLE attachements (task_id INTEGER NOT NULL, name TEXT NOT NULL, type_id TEXT NOT NULL, data BLOB, PRIMARY KEY (task_id, name))");
            queries.Add("CREATE TABLE attachement_types (name TEXT NOT NULL, PRIMARY KEY (name))");
            queries.Add("CREATE TABLE metadata (task_id INTEGER NOT NULL, key TEXT NOT NULL, value TEXT, PRIMARY KEY (task_id, key))");
            
            foreach (string query in queries)
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
            }

#if DEBUG
            TaskDatabase database = new TaskDatabase(connection);
            database.InsertDebugData();
#endif
        }
    }
}