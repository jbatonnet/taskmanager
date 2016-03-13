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
using AlertDialog = Android.App.AlertDialog;

namespace TaskManager.Android
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class TaskEditionActivity : AppCompatActivity
    {
        private int? taskId = null;
        private Task task;

        private EditText nameBox;
        private EditText descriptionBox;
        private TextView dateLabel;
        private TextView tagsLabel;
        private View dateButton, tagsButton, attachementsButton, metadataButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TaskEditionActivity);

            // Setup toolbar
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // Get current task
            Bundle extras = Intent.Extras;
            if (extras != null && extras.ContainsKey("Task.Id"))
            {
                taskId = extras.GetInt("Task.Id");
                task = App.Database.Tasks.First(t => t.Id == taskId);
            }
            else
            {
                task = new Task();

                if (extras != null && extras.ContainsKey("Task.ParentId"))
                {
                    int parentId = extras.GetInt("Task.ParentId");
                    Task parent = App.Database.Tasks.First(t => t.Id == parentId);
                    task.Parents.Add(parent);
                }
            }
            
            // Get UI elements
            nameBox = FindViewById<EditText>(Resource.Id.TaskEdition_Name);
            descriptionBox = FindViewById<EditText>(Resource.Id.TaskEdition_Description);
            dateLabel = FindViewById<TextView>(Resource.Id.TaskEdition_Date);
            tagsLabel = FindViewById<TextView>(Resource.Id.TaskEdition_Tags);
            dateButton = FindViewById(Resource.Id.TaskEdition_DateButton);

            // Subscribe events
            dateButton.Click += DateButton_Click;

            Refresh();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.TaskEditionActivityMenu, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case global::Android.Resource.Id.Home:
                    OnBackPressed();
                    break;

                case Resource.Id.SaveTaskMenuItem:
                    task.Name = nameBox.Text;
                    task.Description = descriptionBox.Text;

                    // If no task id is provided, save a new task
                    if (taskId == null)
                        App.Database.Tasks.Add(task);

                    App.Database.Save();

                    Toast.MakeText(this, "Task successfully saved", ToastLength.Short).Show();
                    Finish();
                    break;
            }

            return true;
        }

        private void DateButton_Click(object sender, EventArgs e)
        {
            DateTime date = task.Date ?? DateTime.Now;

            DatePickerDialog dialog = new DatePickerDialog(this, (s, ea) =>
            {
                task.Date = ea.Date;
                Refresh();
            }, date.Year, date.Month, date.Day);

            dialog.Show();
            
            /*EditText editText = new EditText(this);
            editText.SetPadding(8, 0, 8, 0);

            new AlertDialog.Builder(this)
                .SetTitle("Title")
                .SetMessage("Message")
                .SetView(editText)
                .SetPositiveButton("OK", (s, ea) =>
                {
                    Toast.MakeText(this, editText.Text, ToastLength.Short).Show();
                })
                .SetNegativeButton("Cancel", (s, ea) =>
                {
                    Toast.MakeText(this, "Cancel", ToastLength.Short).Show();
                })
                .Show();*/
        }

        private void Refresh()
        {
            nameBox.Text = task.Name;
            descriptionBox.Text = task.Description;
            dateLabel.Text = task.Date?.ToLongDateString() ?? "Unset";
            tagsLabel.Text = task.Tags.Count > 0 ? task.Tags.Select(t => t.Name).Join(", ") : "Unset";
        }
    }
}