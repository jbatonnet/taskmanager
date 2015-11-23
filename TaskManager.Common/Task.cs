using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public class Task : IEquatable<Task>
    {
        public int Id { get; private set; }

        // Common
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Attachement> Attachements { get; } = new List<Attachement>();
        public List<Tag> Tags { get; } = new List<Tag>();
        public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();

        // Graph
        public List<Task> Parents { get; } = new List<Task>();
        public List<Task> Children { get; } = new List<Task>();

        // Modules
        public IEnumerable<Module> Modules { get; }
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

        public bool Equals(Task other)
        {
            return Id == other.Id;
        }
    }
}