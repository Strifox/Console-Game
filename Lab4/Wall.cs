using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Wall : Board, IGraphic
    {
        private string icon = "#";

        public ConsoleColor Color { get { return color; } set { color = value; } }
        public string Icon { get { return icon; } set { value = icon; } }

        public Wall(): base()
        { }
    }
}
