using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        class GameObject
        {
            protected int x, y;
            protected string name;
            protected int hitPoints;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
            public int HitPoints
            {
                get { return hitPoints; }
                set { hitPoints = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int FieldWidth = 300;
            public int FieldHeight = 200;
            public GameObject() { }
        }
        class MovableObject : GameObject
        {
            public MovableObject() { }
            public virtual void Move(int deltaX, int deltaY) 
            {
                X += deltaX;
                Y += deltaY;
            }
        }
        class Player : MovableObject
        {
            protected int score;
            public int Score
            { 
                get { return score; }
                set { score = value; }
            }
            public Player(int x, int y, string name) : base()
            {
                X = x;
                Y = y;
                Name = name;
                Score = 0;
                HitPoints = 100;
            }
            public void Respawn() { Score = 0; HitPoints = 100; }
        }
        class Volf : MovableObject
        {
            public Volf(int x, int y, string name) : base()
            {
                X = x;
                Y = y;
                Name = name;
                HitPoints = 10;
            }
        }
        class Bear : MovableObject
        {
            public Bear(int x, int y, string name) : base()
            {
                X = x;
                Y = y;
                Name = name;
                HitPoints = 20;
            }
            public void Regenerate()
            {
                Random r = new Random();
                this.HitPoints += r.Next(0, 4);
            }
        }
        class ClawOfDeath : MovableObject
        {
            public ClawOfDeath(int x, int y, string name) : base()
            {
                X = x;
                Y = y;
                Name = name;
                HitPoints = 50;
            }
            public void Teleportate()
            {
                Random r = new Random();
                this.Move(r.Next(0, 5), r.Next(0, 5));
            }
        }
        class Bonus : GameObject
        {
            public enum TypeOfBonus
            {
                health, power, invisibility, death
            }

            protected int bonusValue;
            protected TypeOfBonus bonusType;
            public int BonusValue
            {
                get { return bonusValue; }
                set { bonusValue = value; }
            }
            public TypeOfBonus BonusType
            {
                get { return bonusType; }
                set { bonusType = value; }
            }
        }
        class Apple : Bonus
        {
            public Apple(int x, int y) : base()
            {
                X = x;
                Y = y;
                BonusType = TypeOfBonus.health;
                BonusValue = 30;
            }
        }
        class Chery : Bonus
        {
            public Chery(int x, int y) : base()
            {
                X = x;
                Y = y;
                BonusType = TypeOfBonus.power;
                BonusValue = 30;
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
