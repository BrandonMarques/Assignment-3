using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace brandonMiranda_17610437
{
    class GameEngine
    {
        public static Random random = new Random();
        const string UNITS_FILENAME = "units.txt"; // save files
        const string BUILDINGS_FILENAME = "buildings.txt";
        const string ROUND_FILENAME = "rounds.txt";

        Map map;
        bool isGameOver = false; // setting the bool to false at the start so the game can run
        string winningFaction = "";
        int round = 0;

        public GameEngine(int x, int y)
        {
            map = new Map(10, 10, x,y); //making the map size with x and y sizes
        }

        public GameEngine()
        {
            map = new Map(10, 10, 20, 20); // standard size of map
        }
        public bool IsGameOver
        {
            get { return isGameOver; }
        }
        public string WinningFaction
        {
            get { return winningFaction; }
        }
        public int Round
        {
            get { return round; } // getters for the variables 
        }
        public void GameLoop() // the game loop
        {
            UpdateUnits();
            UpdateBuildings();
            map.UpdateMap();
            round++;

        }
        void UpdateBuildings() // updating the buildings to make sure it keeps the buildings in  the game, dead or alive.
        {
            foreach (Buildings building in map.Buildings)
            {
                if (building is FactoryBuilding)
                {
                    FactoryBuilding factoryBuilding = (FactoryBuilding)building;

                    if (round % factoryBuilding.ProductionSpeed == 0)
                    {
                        Unit newUnit = factoryBuilding.SpawnUnit();
                        map.AddUnit(newUnit);
                    }
                }
                else if (building is ResourceBuilding)
                {
                    ResourceBuilding resourceBuilding = (ResourceBuilding)building;
                    resourceBuilding.GeneratedResources();
                }
            }
        }
        void UpdateUnits() // updates the units and checks if they are bellow a certain health threshold and cheching if they should run away, or if they are dead
        {
            foreach (Unit unit in map.Units)
            {
                if (unit.IsDestroyed)
                {
                    continue;
                }

                Unit closestUnit = unit.GetClosestUnit(map.Units);
                if (closestUnit == null)
                {
                    isGameOver = true;
                    winningFaction = unit.Faction;
                    map.UpdateMap();
                    return;
                }
                double healthPercentage = unit.Health / unit.MaxHealth;
                if (healthPercentage <= 0.5 && unit.Faction == "N-Team")
                {
                    unit.Runaway();
                }
                else if (healthPercentage <= 0.25)
                {
                    unit.Runaway();
                }
                else if(unit.Faction == "N-Team")
                {
                    foreach (Unit allUnits in map.Units)
                    {
                        if (unit.IsInRange(allUnits))
                        {
                            unit.Attack(allUnits);

                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (IsInRange(unit)) // calls the isinrange method and if it is not in range it breaks out of the if statement.
                {
                    break;
                   
                }
                else
                {
                    unit.Move(closestUnit);
                }
                StayInBounds(unit, map.NumxLength, map.NumyLength);
            }
        }
        private bool IsInRange(Unit unit) // checking if the unit is in range, set it as a bool, it remains false until a unit or building comes into range 
        {
            bool inRange = false;
            Unit closestUnit = unit.GetClosestUnit(map.Units);
            Buildings closestBuilding = unit.GetClosestBuilding(map.Buildings);

            if (unit.GetDistance(closestUnit) < unit.GetBuildingDistance(closestBuilding))
            {
                inRange = true;
                unit.Attack(closestUnit);
            }
            else if (unit.GetBuildingDistance(closestBuilding) >= unit.GetDistance(closestUnit))
            {
                inRange = true;
                unit.Attack(closestBuilding);
            }
            else
            {
                inRange = false;
            }
            return inRange;
        }
        private void StayInBounds(Unit unit, int numxLength, int numylength) // stay within the bounds of the map
        {
            if (unit.X < 0)
            {
                unit.X = 0;
            }
            else if (unit.X >= numxLength)
            {
                unit.X = numxLength - 1;
            }
            if (unit.Y < 0)
            {
                unit.Y = 0;
            }
            else if (unit.Y >= numylength)
            {
                unit.Y = numylength - 1;
            }
        }
        public int NumUnits
        {
            get { return map.Units.Length; }
        }
        public int NumBuildings
        {
            get { return map.Buildings.Length; }
        }
        public string MapDisplay
        {
            get { return map.GetMapDisplay(); }
        }
        public string GetUnitInfo()
        {
            string unitInfo = "";
            foreach (Unit unit in map.Units)
            {
                unitInfo += unit + Environment.NewLine;
            }
            return unitInfo;
        }
        public string GetBuildingsInfo()
        {
            string buildingsInfo = "";
            foreach (Buildings building in map.Buildings)
            {
                buildingsInfo += building + Environment.NewLine;
            }
            return buildingsInfo;
        }
        public void Reset() // reset, save and load methods 
        {
            map.Reset();
            isGameOver = false;
            round = 0;
        }
        public void SaveGame()
        {
            Save(UNITS_FILENAME, map.Units);
            Save(BUILDINGS_FILENAME, map.Buildings);
            SaveRound();
        }
        public void LoadGame()
        {
            map.Clear();
            Load(UNITS_FILENAME);
            Load(BUILDINGS_FILENAME);
            LoadRound();
            map.UpdateMap();
        }
        private void Load(string filename) // load method that reads the file and loads the information onto the map.
        {
            FileStream inFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string recordIn;
            recordIn = reader.ReadLine();
            while (recordIn != null)
            {
                int length = recordIn.IndexOf(",");
                string firstField = recordIn.Substring(0, length);
                switch (firstField)
                {
                    case "Melee": map.AddUnit(new MeleeUnit(recordIn)); break;
                    case "Ranged": map.AddUnit(new RangedUnit(recordIn)); break;
                    case "Factory": map.AddBuilding(new FactoryBuilding(recordIn)); break;
                    case "Resource": map.AddBuilding(new ResourceBuilding(recordIn)); break;
                }
                recordIn = reader.ReadLine();
            }
            reader.Close();
            inFile.Close();
        }
        private void Save (string filename, object[] objects) //save files (writes them out)
        {
            FileStream outFile = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            foreach(object obj in objects)
            {
                if (obj is Unit)
                {
                    Unit unit = (Unit)obj;
                    writer.WriteLine(unit.Save());
                }
                else if (obj is Buildings)
                {
                    Buildings building = (Buildings)obj;
                    writer.WriteLine(building.Save());
                }
            }
            writer.Close();
            outFile.Close();
        }
        private void SaveRound() // save round method
        {
            FileStream outFile = new FileStream(ROUND_FILENAME, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            writer.Close();
            outFile.Close();
        }
        private void LoadRound() // load round method
        {
            FileStream inFile = new FileStream(ROUND_FILENAME, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            round = int.Parse(reader.ReadLine());
            reader.Close();
            inFile.Close();
        }
    }

}




