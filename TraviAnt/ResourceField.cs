using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraviAnt
{
    public class ResourceField
    {
        public Rectangle Rectangle { get; }
        public string Type { get; }
        public int Index { get; }
        public int Id { get; }

        public ResourceField(Rectangle rectangle, string type, int index, int id)
        {
            Rectangle = rectangle;
            Type = type;
            Index = index;
            Id = id;
        }
    }
}
