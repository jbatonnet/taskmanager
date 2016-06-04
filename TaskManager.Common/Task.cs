using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public class Task : IEquatable<Task>
    {
        public int Id { get; set; } = -1;

        // Common
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public List<Tag> Tags { get; } = new List<Tag>();
        public List<Attachment> Attachements { get; } = new List<Attachment>();
        public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();

        // Graph
        public List<Task> Parents { get; } = new List<Task>();
        public List<Task> Children { get; } = new List<Task>();

        // Modules
        public IEnumerable<Module> Modules
        {
            get
            {
                Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                                                      .SelectMany(a => a.GetTypes())
                                                      .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(Module)))
                                                      .ToArray();

                foreach (Type type in types)
                {
                    ModuleAttribute module = type.GetCustomAttribute<ModuleAttribute>();
                    if (module == null)
                        continue;

                    if (Metadata.Any(p => p.Key.StartsWith(module.Prefix)))
                    {
                        ConstructorInfo constructor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).FirstOrDefault();
                        if (constructor == null)
                            continue;

                        yield return constructor.Invoke(new object[] { this }) as Module;
                    }
                }
            }
        }
        public ProjectModule Project
        {
            get
            {
                return Modules.OfType<ProjectModule>().FirstOrDefault();
            }
        }
        public ContactModule Contact
        {
            get
            {
                return Modules.OfType<ContactModule>().FirstOrDefault();
            }
        }

        public T GetModule<T>() where T : Module
        {
            T module = Modules.OfType<T>().FirstOrDefault();
            if (module != null)
                return module;

            ConstructorInfo constructor = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).FirstOrDefault();
            if (constructor == null)
                return null;

            return constructor.Invoke(new object[] { this }) as T;
        }

        public bool Equals(Task other)
        {
            return Id == other.Id;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}