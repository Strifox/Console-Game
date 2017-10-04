using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    interface IDurability
    {
        int Durability { get; set; }
        void CheckDurability();
    }
}
