using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class KeyRoom : Room
    {
        private string icon = "K";
        private ConsoleColor color = ConsoleColor.DarkYellow;
        public override string Icon { get { return icon; } set { value = icon; } }
        public override ConsoleColor Color { get { return color; } set { Color = value; } }
        public bool hasKey = true;

        public KeyRoom() : base()
        { }
    }
}
