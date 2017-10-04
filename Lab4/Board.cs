using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public abstract class Board : IGraphic
    {
        public abstract ConsoleColor Color { get; set; }
        public abstract string Icon { get; set; }
    }
}
