using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public class ProjectModule : Module
    {
        private const string Prefix = "Project.";

        public DateTime? StartDate
        {
            get
            {
                return ReadMetadata<DateTime?>(Prefix + nameof(StartDate));
            }
            set
            {
                WriteMetadata(Prefix + nameof(StartDate), value);
            }
        }
        public DateTime? DueDate
        {
            get
            {
                return ReadMetadata<DateTime?>(Prefix + nameof(DueDate));
            }
            set
            {
                WriteMetadata(Prefix + nameof(DueDate), value);
            }
        }
        public float? Priority
        {
            get
            {
                return ReadMetadata<float?>(Prefix + nameof(Priority));
            }
            set
            {
                WriteMetadata(Prefix + nameof(Priority), value);
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

        internal ProjectModule(Task task) : base(task) { }
    }
}