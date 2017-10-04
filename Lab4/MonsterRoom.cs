using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class MonsterRoom : Room
    {
        private string icon = "M";
        private ConsoleColor color = ConsoleColor.Red;
        public override string Icon { get { return icon; } set { value = icon; } }
        public override ConsoleColor Color { get { return color; } set { color = value; } }
        public bool hasMonster = true;

        public MonsterRoom() : base()
        { }
    }
}
