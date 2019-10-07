using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace brandonMiranda_17610437
{
    class FactoryBuilding : Buildings
    {
        private FactoryType type;
        int productionSpeed;
        int ySpawn;
        

        public FactoryBuilding(int x, int y, string faction) : base(x, y, 100, faction, 'F') //essetially a copy of resource building
        {
            if (y >= Map.numyLength- 1)
            {
                ySpawn = y - 1;
            }
            else
            {
                ySpawn = y + 1;
            }
            type = (FactoryType)GameEngine.random.Next(0, 2);
            productionSpeed = GameEngine.random.Next(3, 7);
        }

        public FactoryBuilding(string values)
        {
            string[] parameters = values.Split(',');


            x = int.Parse(parameters[1]);
            y = int.Parse(parameters[2]);
            health = int.Parse(parameters[3]);
            maxHealth = int.Parse(parameters[4]);
            type = (FactoryType)int.Parse(parameters[5]);
            productionSpeed = int.Parse(parameters[6]);
            ySpawn = int.Parse(parameters[7]);
            faction = parameters[8];
            symbol = parameters[9][0];
            isDestroyed = parameters[10] == "True" ? true : false;
        }
        public int ProductionSpeed
        {
            get { return productionSpeed; }

        }
        public override void Destroy()
        {
            isDestroyed = true;
            symbol = '_';
        }
        public override string Save()
        {
            return string.Format(
                $"Factory, {x}, {y}, {health}, {maxHealth}, {(int)type})," + $"{productionSpeed}, {ySpawn}" + $"{faction}, {symbol}, {isDestroyed}");
        }
        public Unit SpawnUnit() // spawn unit method that spawns melee and ranged units only.
        {
            Unit unit;
            if (type == FactoryType.MELEE)
            {
                unit = new MeleeUnit(x, ySpawn, faction);
            }
            else
            {
                unit = new RangedUnit(x, ySpawn, faction);
            }
            return unit;
        }
        private string GetFactoryTypeName() // method that stores the diffrent building types
        {
            return new string[] { "Melee", "Ranged" }[(int)type];
        }
        public override string ToString()
        {
            return "-------------------------------------------" + Environment.NewLine + "Factory Building (" + symbol + "/" + faction[0] + ")" + Environment.NewLine + "-------------------------------------------" + Environment.NewLine + GetFactoryTypeName() + Environment.NewLine + base.ToString() + Environment.NewLine;
        }
    }
}
