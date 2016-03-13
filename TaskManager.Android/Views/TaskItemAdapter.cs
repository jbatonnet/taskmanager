using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

using TaskManager.Common;

namespace TaskManager.Android
{
    public class TaskItemAdapter : RecyclerView.Adapter, View.IOnClickListener
    {
        public override int ItemCount
        {
            get
            {
                return tasks.Length;
            }
        }

        private Task[] tasks;
        private List<TaskItemViewHolder> viewHolders = new List<TaskItemViewHolder>();
        
        public TaskItemAdapter(IEnumerable<Task> tasks)
        {
            this.tasks = tasks.ToArray();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.TaskItem, parent, false);
            itemView.SetOnClickListener(this);

            return new TaskItemViewHolder(itemView);
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TaskItemViewHolder viewHolder = holder as TaskItemViewHolder;
            Task task = tasks[position];

            viewHolder.Name.Text = task.Name;
            viewHolder.Description.Text = task.Children.Count + " sub items";

            viewHolders.Add(viewHolder);
        }

        public void OnClick(View v)
        {
            TaskItemViewHolder viewHolder = viewHolders.First(vh => vh.ItemView == v);
            Task task = tasks[viewHolder.AdapterPosition];

            Intent intent = new Intent(v.Context, typeof(TaskActivity));
            intent.PutExtra("Task.Id", task.Id);

            v.Context.StartActivity(intent);
        }
    }
}