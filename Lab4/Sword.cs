using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Sword : Board
    {
        private string icon = "$";
        private ConsoleColor color = ConsoleColor.DarkCyan;

        public override ConsoleColor Color { get { return color; } set { color = value; } }
        public override string Icon { get { return icon; } set { value = icon; } }
        public void ExtraAttackDamage()
        {
            Player.playerAttack += 10;
        }
        public Sword() : base()
        { }

        }
}
