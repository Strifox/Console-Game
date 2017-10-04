using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class ExitDoor : Door
    {
        private string icon = "E";
        public override string Icon { get { return icon; } set { icon = value; } }

        public ExitDoor() : base()
        { }
    }
}
