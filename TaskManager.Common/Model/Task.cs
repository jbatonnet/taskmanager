using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public class Task
    {
        public int Id { get; private set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Attachement> Attachements { get; set; }
    }
}