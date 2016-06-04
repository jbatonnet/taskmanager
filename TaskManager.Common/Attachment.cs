using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public enum AttachmentType
    {
        Binary,

        Link,
        File,
        Picture,
        Document
    }

    public class Attachment
    {
        public string Name { get; set; }
        public AttachmentType Type { get; set; }
        public byte[] Data { get; set; }
    }
}