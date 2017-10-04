using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Wall : Board, IGraphic
    {
        private string icon = "#";
        private ConsoleColor color = ConsoleColor.DarkGray;

        public override ConsoleColor Color { get { return color; } set { color = value; } }
        public override string Icon { get { return icon; } set { value = icon; } }

        public Wall() : base()
        { }
    }
}
