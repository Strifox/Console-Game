using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Room : Board
    {
        private string icon = " ";
        private ConsoleColor color = ConsoleColor.Red;
        private bool tileExplored;
        public override bool TileExplored { get { return tileExplored; } set { tileExplored = value; } }
        public override string Icon { get { return icon; } set { value = icon; } }

        public override ConsoleColor Color { get { return color; } set { color = value; } }

        public Room() : base()
        { }

        
    }
}
