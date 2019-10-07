using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace brandonMiranda_17610437
{
    class Map
    {
      
        Random random = new Random();
        int numUnits;
        int numBuildings;
        public static int numxLength;
        public static int numyLength;
        Unit[] units;
        Buildings[] buildings;
        string[,] map;
        string[] faction = { "A-Team", "B-Team", "N-Team" }; //declaring the map lengths, number of buildings and units,, creating the factions.
        

        public Map(int numUnits, int numBuildings, int xLength, int yLength) // creating the constructors for map 
        {
            this.numUnits = numUnits;
            this.numBuildings = numBuildings;
            numxLength = xLength;
            numyLength = yLength;
            Reset();
        }
        public Unit[] Units // getting and setting units
        {
            get { return units; }
        }
        public Buildings[] Buildings // getting and setting Buildings
        {
            get { return buildings; }
        }
      
        public int NumxLength
        {
            get { return numxLength; }
            set { numxLength = value; }
        }
        public int NumyLength       //getting and setting lenght for x and y
        {
            get { return numyLength; }
            set { numyLength = value; }
        }
        private void InitializeUnits()    // method for intializing units 
        {
            units = new Unit[numUnits];
            for (int i = 0; i < units.Length; i++)
            {
                int x = random.Next(0, numxLength);
                int y = random.Next(0, numyLength);
                int factionIndex = random.Next(0, 2);
                int unitType = random.Next(0, 3);

                while (map[x, y] != null)
                {
                    x = random.Next(0, numxLength);
                    y = random.Next(0, numyLength);
                }
                if (unitType == 0)
                {
                    units[i] = new MeleeUnit(x, y, faction[factionIndex]);
                }
                else if (unitType == 1)
                {
                    units[i] = new RangedUnit(x, y, faction[factionIndex]);
                }
                
                else if (unitType == 2)
                {
                    units[i] = new WizardUnit(x, y, "N-Team");  // set the wizards to specifically fall under the neutral faction
                }
                map[x, y] = units[i].Faction[0] + "/" + units[i].Symbol;
            }
        }
        private void InitializeBuildings() // method for initializing buildings
        {
            buildings = new Buildings[numBuildings];
            for (int i = 0; i < buildings.Length; i++)
            {
                int x = random.Next(0, numxLength);
                int y = random.Next(0, numyLength);
                int factionIndex = random.Next(0, 3);
                int buildingType = random.Next(0, 2);

                while (map[x, y] != null)
                {
                    x = random.Next(0, numxLength);
                    y = random.Next(0, numyLength);
                }
                if (buildingType == 0)
                {
                    buildings[i] = new FactoryBuilding(x, y, faction[factionIndex]);
                }
                else
                {
                    buildings[i] = new ResourceBuilding(x, y, faction[factionIndex]);
                }
                map[x, y] = buildings[i].Faction[0] + "/" + buildings[i].Symbol;  // assigns factory and resource building to factions
            }

        }

        public void AddUnit(Unit unit) // add units to the map
        {
            Unit[] resizeUnit = new Unit[units.Length + 1];
            for (int i = 0; i < units.Length; i++)
            {
                resizeUnit[i] = units[i];
            }
            resizeUnit[resizeUnit.Length - 1] = unit;
            units = resizeUnit;
        }
        public void AddBuilding(Buildings building)
        {
            Array.Resize(ref buildings, Buildings.Length + 1);
            buildings[buildings.Length - 1] = building;
        }
        public void UpdateMap()
        {
            for (int y = 0; y < numyLength; y++)
            {
                for (int x = 0; x < numxLength; x++)
                {
                    map[x, y] = "      ";
                }
            }
            foreach (Unit unit in units)
            {
                map[unit.X, unit.Y] = unit.Faction[0] + "/" + unit.Symbol;
            }
            foreach (Buildings b in buildings)
            {
                map[b.X, b.Y] = b.Faction[0] + "/" + b.Symbol;
            }
        }
        public string GetMapDisplay()  // displaying the map
        {
            string mapString = "";
            for (int y = 0; y < numyLength; y++)
            {
                for (int x = 0; x < numxLength; x++)
                {
                    mapString += map[x, y];
                }
                mapString += "\n";

            }
            return mapString;
        }

        public void Clear() // clears the map
        {
            units = new Unit[0];
            buildings = new Buildings[0];
        }
        public void Reset()  // resets the map
        {
            map = new string[numxLength, numyLength];
            units = new Unit[numUnits];
            InitializeUnits();
            InitializeBuildings();
            UpdateMap();
        }
    }

}
