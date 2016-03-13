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
using Android.Utilities;
using Android.Views;
using Android.Widget;

using TaskManager.Common;

namespace TaskManager.Android
{
    public class TaskGroupViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public RecyclerView Items { get; private set; }

        public TaskGroupViewHolder(ViewGroup parent, View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.TaskGroupName);

            Items = itemView.FindViewById<RecyclerView>(Resource.Id.TaskGroupItems);
            Items.HasFixedSize = true;
            Items.SetLayoutManager(new WrapLayoutManager(parent.Context));
            Items.AddItemDecoration(new DividerItemDecoration(parent.Context, WrapLayoutManager.Vertical));
        }
    }
}