using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public class TaskGroupAdapter : RecyclerView.Adapter
    {
        public override int ItemCount
        {
            get
            {
                return moduleTypes.Length;
            }
        }

        public Task[] tasks;
        public Type[] moduleTypes;

        public TaskGroupAdapter(IEnumerable<Task> tasks)
        {
            this.tasks = tasks.ToArray();
            this.moduleTypes = tasks.SelectMany(t => t.Modules.Any() ? t.Modules.Select(m => m.GetType()) : new Type[] { null })
                                    .Distinct()
                                    .OrderBy(t => t?.Name ?? "ZZZ")
                                    .ToArray();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.TaskGroup, parent, false);
            return new TaskGroupViewHolder(parent, itemView);
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TaskGroupViewHolder viewHolder = holder as TaskGroupViewHolder;

            Type type = moduleTypes[position];

            viewHolder.Name.Text = type != null ? type.GetCustomAttribute<ModuleAttribute>()?.Category ?? type.Name.Replace("Module", "") : "Other";
            viewHolder.Items.SetAdapter(new TaskItemAdapter(tasks.Where(t => type == null ? !t.Modules.Any() : t.Modules.Any(m => m.GetType() == type))));
        }
    }
}