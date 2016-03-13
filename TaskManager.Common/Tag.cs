using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public enum TagColor
    {
        None,

        Black,
        Gray,
        White,
        
        Red,
        Green,
        Blue,

        Cyan,
        Magenta,
        Yellow,
    }

    public struct Tag : IEqualityComparer<Tag>, IEquatable<Tag>
    {
        public string Name { get; set; }
        public TagColor Color { get; set; }

        public Tag(string name, TagColor color)
        {
            Name = name;
            Color = color;
        }

        public bool Equals(Tag x, Tag y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(Tag obj)
        {
            return obj.Name.GetHashCode();
        }
        public bool Equals(Tag other)
        {
            return Name == other.Name;
        }
    }
}