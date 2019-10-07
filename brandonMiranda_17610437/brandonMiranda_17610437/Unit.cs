using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace brandonMiranda_17610437
{
    abstract class Unit
    {
        protected int x, y, health, maxHealth, speed, attack, attackRange; // protected base varieables for unit, this is enhirited by melee units and ranged units and wizard units
        protected string faction, name;
        protected char symbol;
        protected bool isAttacking = false;


        protected bool isDestroyed = false;
        public static Random random = new Random();



        public Unit(int x, int y, int health, int speed, int attack, int attackRange, string faction, char symbol, string name) // constructor for the unit class
        {
            this.x = x;
            this.y = y;
            this.health = health;
            maxHealth = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.faction = faction;
            this.symbol = symbol;
            this.name = name;
        }
        public Unit(string values) // setting the parameters for the unit values 
        {
            string[] parameters = values.Split(',');
            x = int.Parse(parameters[1]);
            y = int.Parse(parameters[2]);
            health = int.Parse(parameters[3]);
            maxHealth = int.Parse(parameters[4]);
            speed = int.Parse(parameters[5]);
            attack = int.Parse(parameters[6]);
            attackRange = int.Parse(parameters[7]);
            faction = parameters[8];
            symbol = parameters[9][0];
            name = parameters[10];
            isDestroyed = parameters[11] == "True" ? true : false;
        }
        //the only abstract method left
        public abstract string Save();
        public int X // getters and setters for the variables above 
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int MaxHealth
        {
            get { return health; }

        }
        public string Faction
        {
            get { return faction; }
            set { faction = value; }
        }
        public char Symbol
        {
            get { return symbol; }
        }
        public bool IsDestroyed
        {
            get { return isDestroyed; }
        }
        public string Name
        {
            get { return name; }
        }
        //Made the abstract methods from before virtual instead
        public virtual void Attack(Unit otherUnit)
        {
            isAttacking = true;
            otherUnit.Health -= attack;

            if (otherUnit.Health <= 0)
            {
                otherUnit.Health = 0;
                otherUnit.Destroy();
            }
        }
        public virtual void Attack(Buildings otherBuilding)
        {
            isAttacking = true;
            otherBuilding.Health -= attack;

            if (otherBuilding.Health <= 0)
            {
                otherBuilding.Health = 0;
                otherBuilding.Destroy();
            }
        }
        public virtual void Destroy()
        {
            isDestroyed = true;
            isAttacking = false;
            symbol = 'X';
        }
        public virtual void DestroyBuilding()
        {
            isDestroyed = true;
            symbol = 'X';
        }
        public virtual Unit GetClosestUnit(Unit[] units) // method for getclosestunit in units
        {
           
            double closestUnitDistance = int.MaxValue;
           
            Unit closestUnit = null;
            
            foreach (Unit otherUnit in units)
            {

                if (otherUnit == this || otherUnit.Faction == faction || otherUnit.IsDestroyed)
                {
                    continue;
                }
                double distance = GetDistance(otherUnit);
                if (distance < closestUnitDistance)
                {
                    closestUnitDistance = distance;
                    closestUnit = otherUnit;
                }
            }
                return closestUnit;
           
           
            
        }
        public virtual Buildings GetClosestBuilding(Buildings[] buildings) // method for getting closest bulding 
        {

          
            double closestBuildingDistance = int.MaxValue;
            Buildings closestBuilding = null;
            foreach (Buildings otherBuilding in buildings)
            {

                if (otherBuilding.Faction == faction || otherBuilding.IsDestroyed)
                {
                    continue;
                }
                double distance = GetBuildingDistance(otherBuilding);
                if (distance < closestBuildingDistance)
                {
                    closestBuildingDistance = distance;
                    closestBuilding = otherBuilding;
                }
                
            }
            return closestBuilding;
        }
        public virtual bool IsInRange(Unit otherunit)
        {
            return GetDistance(otherunit) <= attackRange;
        }
        public virtual bool IsBuildingInRange(Buildings otherBuilding) // checking if the building is in range of the unit, it will return true if its in range.
        {
            return GetBuildingDistance(otherBuilding) <= attackRange;
        }
        public virtual void Move(Unit closestUnit) // method for unit movement 
        {
            isAttacking = false;
            int xDirection = closestUnit.X - X;
            int yDirection = closestUnit.Y - Y;

            if (Math.Abs(xDirection) > Math.Abs(yDirection))
            {
                x += Math.Sign(xDirection);
            }
            else
            {
                y += Math.Sign(yDirection);
            }
        }
        public virtual void Runaway() // method for running away when bellow a certain health working on percentage 
        {
            isAttacking = false;
            int direction = random.Next(0, 4);
            if (direction == 0)
            {
                x += 1;
            }
            else if (direction == 1)
            {
                x -= 1;
            }
            else if (direction == 2)
            {
                y += 1;
            }
            else
            {
                y -= 1;
            }
        }
        public double GetDistance(Unit otherUnit) // Get distance method for unit from another unit using pythagoroas 
        {
            double xDistance = otherUnit.X - X;
            double yDistance = otherUnit.Y - Y;
            return Math.Sqrt(xDistance * yDistance + yDistance * yDistance);
        }
        public double GetBuildingDistance(Buildings otherBuilding) //get distance for the unit for the building using pythagoroas 
        {
            double xDistance = otherBuilding.X - X;
            double yDistance = otherBuilding.Y - Y;
            return Math.Sqrt(xDistance * yDistance + yDistance * yDistance);
        }
        public override string ToString()
        {
            return
            "-------------------------------------------" + Environment.NewLine + "Factory Building (" + symbol + "/" + faction[0] + ")" + Environment.NewLine + "-------------------------------------------" + Environment.NewLine + "Faction: " + faction + Environment.NewLine + "Position: " + x + ", " + y + Environment.NewLine + "Health; " + health + "/ " + maxHealth + Environment.NewLine;
        }
       
    }
    
}
