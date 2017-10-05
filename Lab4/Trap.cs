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
        private string triggeredIcon = "X";
        private ConsoleColor color = ConsoleColor.Black;
        private bool tileExplored;
        private bool triggered = false;

        public bool Triggered { get { return triggered; } set { triggered = value; } }
        public override bool TileExplored { get { return tileExplored; } set { tileExplored = value; } }
        public override ConsoleColor Color { get { return color; } set { color = value; } }
        public override string Icon
        {
            get
            {
                if (triggered)
                    return triggeredIcon;
                else
                    return icon;
            }
            set { icon = value; }
        }

        public Trap() { }
    }
}
