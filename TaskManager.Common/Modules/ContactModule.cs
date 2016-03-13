using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    [Module("Contact", Prefix)]
    public class ContactModule : Module
    {
        private const string Prefix = "Contact.";

        public string Name
        {
            get
            {
                return ReadMetadata<string>(Prefix + nameof(Name));
            }
            set
            {
                WriteMetadata(Prefix + nameof(Name), value);
            }
        }
        public DateTime Birthday
        {
            get
            {
                return ReadMetadata<DateTime>(Prefix + nameof(Birthday));
            }
            set
            {
                WriteMetadata(Prefix + nameof(Birthday), value);
            }
        }

        internal ContactModule(Task task) : base(task) { }
    }
}