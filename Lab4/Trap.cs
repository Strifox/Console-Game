using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Trap : Board
    {
        private string icon = "T";
        private ConsoleColor color = ConsoleColor.DarkRed;
        private bool tileExplored = false;

        public override bool TileExplored { get { return tileExplored; } set { tileExplored = value; } }
        public override ConsoleColor Color { get { return color; } set { color = value; } }
        public override string Icon{ get { return icon; } set { icon = value; } }

        public Trap() { }
    }
}
