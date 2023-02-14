using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipLibrary
{
    public abstract class Ships
    {
        public List<string> AircraftCarrier { get; set; }
        public List<string> Destroyer { get; set; }
        public List<string> Warship { get; set; }
        public List<string> Submarine { get; set; }

        public bool isDeadAC { get; set; }
        public bool isDeadDS { get; set; }
        public bool isDeadWH { get; set; }
        public bool isDeadSM { get; set; }

        
    }
}
