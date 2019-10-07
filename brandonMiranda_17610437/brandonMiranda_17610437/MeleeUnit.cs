using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace brandonMiranda_17610437
{
    class MeleeUnit : Unit
    {
        public MeleeUnit(int x, int y, string faction) : base(x, y, 200, 2, 20, 1, faction, 'K', "Knight") //constructor for melee units which is inheriting from the main unit class
        {

        }
        public MeleeUnit(string values) : base(values)
        {

        }
        public override string Save()
        {
            return string.Format($"Melee, {x}, {y}, {health}, {maxHealth}, {speed}, {attack}, {attackRange}," + $"{faction}, {symbol}, {name}, {isDestroyed}");
        } //saves the information of the melee unit 
    }
}
