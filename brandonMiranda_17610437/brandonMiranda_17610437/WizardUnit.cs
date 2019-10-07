using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brandonMiranda_17610437
{
    class WizardUnit : Unit
    {
        public WizardUnit(int x, int y, string faction) : base(x, y, 150, 2, 20, 1, faction, 'W', "Wizard") // similar to melee and ranged units. inherits from the unit class
        {

        }
        public WizardUnit(string values): base(values)
        {

        }
        public override string Save()
        {
            return string.Format($"Wizard, {x}, {y}, {health}, {maxHealth}, {speed}, {attack}, {attackRange}," + $"{faction}, {symbol}, {name}, {isDestroyed}");
        }
    }
}
