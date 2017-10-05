using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Debug
    {
        ////Debug method for invisible map
        ////Remove the // of the following 10 lines to use debug mode, also uncomment the debug method in the PrintMap method (line 144, end of the PrintMap method)
        static public void DebugExploreMap()
        {
            for (int y = 0; y < Program.map.GetLength(0); y++)
            {
                for (int x = 0; x < Program.map.GetLength(1); x++)
                {
                    Program.map[y, x].TileExplored = true;
                }
            }
        }
    }
}
