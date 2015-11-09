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

        // Project
        public DateTime? StartDate
        {
            get
            {
                object value;

                if (!Metadata.TryGetValue("Project." + nameof(StartDate), out value))
                    return null;

                return value as DateTime?;
            }
            set
            {
                if (value == null)
                    Metadata.Remove("Project." + nameof(StartDate));
                else
                    Metadata["Project." + nameof(StartDate)] = value;
            }
        }
        public DateTime? DueDate
        {
            get
            {
                object value;

                if (!Metadata.TryGetValue("Project." + nameof(DueDate), out value))
                    return null;

                return value as DateTime?;
            }
            set
            {
                if (value == null)
                    Metadata.Remove("Project." + nameof(DueDate));
                else
                    Metadata["Project." + nameof(DueDate)] = value;
            }
        }
        public float? Priority
        {
            get
            {
                object value;

                if (!Metadata.TryGetValue("Project." + nameof(Priority), out value))
                    return null;

                return value as float?;
            }
            set
            {
                if (value == null)
                    Metadata.Remove("Project." + nameof(Priority));
                else
                    Metadata["Project." + nameof(Priority)] = value;
            }
        }
        public TimeSpan? Duration
        {
            get
            {
                if (StartDate == null || DueDate == null)
                    return null;

                return DueDate - StartDate;
            }
        }
        public TimeSpan? Remaining
        {
            get
            {
                if (DueDate == null)
                    return null;

                return DueDate - DateTime.Now;
            }
        }

        public bool Equals(Task other)
        {
            return Id == other.Id;
        }
    }
}