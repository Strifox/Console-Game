using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Door : Board
    {
        private static bool isLocked = true;
        private string icon = "D";
        private ConsoleColor color = ConsoleColor.DarkGreen;
        private bool tileExplored;
        public override bool TileExplored { get { return tileExplored; } set { tileExplored = value; } }
        public override string Icon { get { return icon; } set { icon = value; } }
        public static bool IsLocked { get { return isLocked; } set { value = isLocked; } }

        public override ConsoleColor Color { get { return color; } set { color = value; } }

        public Door(): base()
        { }

        public static void DoorInteraction()
        {
            if (Player.HasKey || Player.hasSuperKey)
                isLocked = false;

            else
                isLocked = true;
        }
    
    }
}
