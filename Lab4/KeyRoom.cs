using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class KeyRoom : Room, IDurability
    {
        private int durability;
        private string icon = "K";
        private ConsoleColor color = ConsoleColor.DarkYellow;
        private bool tileExplored;
        public override bool TileExplored { get { return tileExplored; } set { tileExplored = value; } }
        public override string Icon { get { return icon; } set { value = icon; } }
        public override ConsoleColor Color { get { return color; } set { Color = value; } }
        public bool hasKey = true;

        public KeyRoom(int durability) : base()
        {
            this.durability = durability;
        }
        // Interface
        public int Durability { get { return durability; } set { durability = value; } }

        public void CheckDurability()
        {
            if (Durability <= 0)
            {
                Player.hasSuperKey = false;
                Player.numOfSuperkeys -= 1;
            }
        }
    }
}
