using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public abstract class Board
    {
        public abstract ConsoleColor Color { get; set; }
        public abstract string Icon { get; set; }
    }
}
