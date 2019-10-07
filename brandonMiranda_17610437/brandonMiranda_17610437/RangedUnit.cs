using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace brandonMiranda_17610437
{
    class RangedUnit : Unit
    {
        public RangedUnit(int x, int y, string faction) : base(x, y, 100, 1, 10, 3, faction, 'A', "Archer") // constructor for ranged unit.
        {

        }
        public RangedUnit(string values) : base(values) // assigning the values of ranged unit to its parent class of unit
        {

        }
        public override string Save() // save ranged unit info
        {
            return string.Format($"Ranged, {x}, {y}, {health}, {maxHealth}, {speed}, {attack}, {attackRange}," + $"{faction}, {symbol}, {name}, {isDestroyed}");
        }
    }
}
