using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Common
{
    public enum TagColor
    {
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

    public struct Tag
    {
        public string Name { get; private set; }
        public TagColor Color { get; private set; }

        public Tag(string name, TagColor color)
        {
            Name = name;
            Color = color;
        }
    }
}