using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace brandonMiranda_17610437
{
    class ResourceBuilding : Buildings 
    {
        private ResourceType type;
        private int generatedPerRound;
        private int generated;
        private int pool;
        
        public ResourceBuilding (int x, int y, string faction) : base (x, y, 100, faction, 'R') // constructor for resource building
        {
            generatedPerRound = GameEngine.random.Next(1, 6);
            generated = 0;
            pool = GameEngine.random.Next(100, 200);
            type = (ResourceType)GameEngine.random.Next(0, 4);
        }
        public ResourceBuilding(string values) // setting the parameters for resource building while calling value
        {
            string[] parameters = values.Split(',');

            x = int.Parse(parameters[1]);
            y = int.Parse(parameters[2]);
            health = int.Parse(parameters[3]);
            maxHealth = int.Parse(parameters[4]);
            type = (ResourceType)int.Parse(parameters[5]);
            generatedPerRound = int.Parse(parameters[6]);
            generated = int.Parse(parameters[7]);
            pool = int.Parse(parameters[8]);
            faction = parameters[9];
            symbol = parameters[10][0];
            isDestroyed = parameters[11] == "True" ? true : false;
        }

        public override void Destroy() // overriden method for destroy
        {
            isDestroyed = true;
            symbol = '_';
        }
        public override string Save() // save method is called to save information on resource buildings
        {
            return string.Format(
                $"Resource, {x}, {y}, {health}, {maxHealth}, {(int)type})," + $"{generatedPerRound}, {generated}, {pool}," + $"{faction}, {symbol}, {isDestroyed}");
        }
        public void GeneratedResources() // method for gathered resources 
        {
            if (isDestroyed)
                return;
            if(pool > 0)
            {
                int resourcesGenerated = Math.Min(pool, generatedPerRound);
                generated += resourcesGenerated;
                pool -= resourcesGenerated;
            }
        }
        private string GetResources() // method for resource tipes stored in a string.
        {
            return new string[] { "Wood", "Food", "Rock", "Gold" }[(int)type];
        }
        public override string ToString()
        {
            return
                "-------------------------------------------" + Environment.NewLine + "Resource Building (" + symbol + "/" + faction[0] + ")" + Environment.NewLine + "-------------------------------------------" + Environment.NewLine + GetResources() + ":" + generated + Environment.NewLine + "Pool: " + pool + Environment.NewLine + base.ToString() + Environment.NewLine;
        }
    }
}
