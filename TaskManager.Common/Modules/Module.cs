using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public abstract class Module
    {
        public Task Task { get; private set; }

        public Module(Task task)
        {
            Task = task;
        }

        protected T ReadMetadata<T>(string name)
        {
            object value;

            if (!Task.Metadata.TryGetValue(name, out value))
                return default(T);

            return (T)value;
        }
        protected void WriteMetadata<T>(string name, T value)
        {
            if (value == null)
                Task.Metadata.Remove(name);
            else
                Task.Metadata[name] = value;
        }
    }
}