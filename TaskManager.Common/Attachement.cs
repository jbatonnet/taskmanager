using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public enum AttachementType
    {
        Binary,

        Link,
        File,
        Picture,
        Document
    }

    public class Attachement
    {
        public string Name { get; set; }
        public AttachementType Type { get; set; }
        public byte[] Data { get; set; }
    }
}