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
    public class TaskItemViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public TextView Description { get; private set; }

        public TaskItemViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.TaskItemName);
            Description = itemView.FindViewById<TextView>(Resource.Id.TaskItemDescription);
        }
    }
}