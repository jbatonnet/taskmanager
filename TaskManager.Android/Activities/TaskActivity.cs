using System;
using System.Collections.Generic;
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
using Android.Views;
using Android.Widget;

using TaskManager.Common;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using MySql.Data.MySqlClient;

namespace TaskManager.Android
{
    [Activity(Label = App.Name, MainLauncher = true, Icon = "@mipmap/ic_launcher", Theme = "@style/AppTheme.NoActionBar")]
    public class TaskActivity : AppCompatActivity
    {
        private int? taskId = null;
        private Task task;

        protected override void OnCreate(Bundle bundle)
        {
            App.Initialize(this);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TaskActivity);

            // Setup toolbar
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);

            // Get current task
            Bundle extras = Intent.Extras;
            if (extras != null && extras.ContainsKey("Task.Id"))
                taskId = extras.GetInt("Task.Id");
            
            // Create adapter
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.TaskGroups);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            RefreshTasks();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.TaskActivityMenu, menu);

            if (task == null)
            {
                IMenuItem editMenuItem = menu.FindItem(Resource.Id.EditTaskMenuItem);
                editMenuItem.SetVisible(false);
            }

            /*if (task != null)
            {
                IMenuItem uploadMenuItem = menu.FindItem(Resource.Id.UploadMenuItem);
                uploadMenuItem.SetVisible(false);

                IMenuItem downloadMenuItem = menu.FindItem(Resource.Id.DownloadMenuItem);
                downloadMenuItem.SetVisible(false);
            }*/

            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.AddTaskMenuItem)
            {
                Intent intent = new Intent(this, typeof(TaskEditionActivity));

                if (task != null)
                    intent.PutExtra("Task.ParentId", task.Id);

                StartActivity(intent);
            }
            else if (item.ItemId == Resource.Id.EditTaskMenuItem)
            {
                Intent intent = new Intent(this, typeof(TaskEditionActivity));
                intent.PutExtra("Task.Id", task.Id);

                StartActivity(intent);
            }

            else if (item.ItemId == Resource.Id.UploadMenuItem)
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("Server=127.0.0.1;Database=julien_taskmanager;Uid=julien_taskmanag;Pwd=taskmanager");
                    connection.Open();

                    TaskDatabase database = new TaskDatabase(connection);
                    database.Tasks.Clear();
                    database.Tasks.AddRange(App.Database.Tasks);
                    database.Save();

                    Toast.MakeText(this, "Upload succeeded", ToastLength.Short).Show();
                }
                catch
                {
                    Toast.MakeText(this, "Upload failed", ToastLength.Short).Show();
                }
            }
            else if (item.ItemId == Resource.Id.DownloadMenuItem)
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("Server=127.0.0.1;Database=julien_taskmanager;Uid=julien_taskmanag;Pwd=taskmanager");
                    connection.Open();

                    TaskDatabase database = new TaskDatabase(connection);
                    App.Database.Tasks.Clear();
                    App.Database.Tasks.AddRange(database.Tasks);
                    App.Database.Save();

                    RefreshTasks();

                    Toast.MakeText(this, "Download succeeded", ToastLength.Short).Show();
                }
                catch
                {
                    Toast.MakeText(this, "Download failed", ToastLength.Short).Show();
                }
            }

            return true;
        }

        private void RefreshTasks()
        {
            task = null;

            if (taskId != null)
            {
                task = App.Database.Tasks.First(t => t.Id == taskId);
                if (task == null)
                {
                    Finish();
                    return;
                }

                Title = task.Name;
            }

            Task[] tasks = App.Database.Tasks.Where(t => task == null ? !t.Parents.Any() : t.Parents.Contains(task)).ToArray();

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.TaskGroups);
            recyclerView.SetAdapter(new TaskGroupAdapter(tasks));
        }
    }
}