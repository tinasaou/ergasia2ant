using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLibrary
{
    interface IShip
    {
        string Name { get; set; }
        List<string> Location { get; set; }
        bool IsDead { get; set; }
        int HitPoints { get; set; }

    }
}
