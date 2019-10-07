using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace brandonMiranda_17610437
{
    abstract class Buildings
    {
        protected int x, y, health, maxHealth;
        protected string faction;
        protected char symbol;
        protected bool isDestroyed = false;
        // setting the the protected variables and setting is destroyed to false as a base


        public Buildings(int x, int y, int health, string faction, char symbol) //constructor initializing buildings
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.maxHealth = health;
            this.faction = faction;
            this.symbol = symbol;
        } 

        public Buildings() { } //geters and setters for the variables 
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string Faction { get { return faction; } }
        public char Symbol { get { return symbol; } }
        public bool IsDestroyed
        {
            get { return isDestroyed; }
            set { isDestroyed = value; }
        }

        public virtual void DestroyBuilding()
        {
            isDestroyed = true;
            symbol = 'X';
        }

        public abstract void Destroy(); //calling the destroy and save methods
        public abstract string Save();


        public override string ToString()
        {
            return
                "Faction: " + faction + Environment.NewLine + "Position: " + x + ", " + y + Environment.NewLine + "Health: " + health + " / " + maxHealth + Environment.NewLine;

        }
    }
    public enum ResourceType //resource types
    {
        WOOD,
        FOOD,
        ROCK,
        GOLD
    }

    public enum FactoryType //types of units 
    {
        MELEE,
        RANGED
    }
}
