using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    // holds all People - including NPC's
    public class People
    {

        public int health;
        public Loc location = new Loc();
        public string symbol;

        protected People(int HP, string Symbol)
        {
            health = HP;
            symbol = Symbol;
        }

        // two functions to generate the new X and Y coords of NPCs
        protected int genRandomX()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(-1, 3);
        }
        protected int genRandomY()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(-1, 3);
        }
        // virtual function to define actions
        public virtual void Action(Player mainPlayer)
        {
        }


    }
    // define the Player class
    public class Player : People
    {
        // define the base damage, HP, Symbol, and starting position
        int damage = 10;
        public Player()
            : base(100, "#")
        {
            location.Is(14, 14);


        }
        // attack a Bad Guy 
        public void Attack(BadGuy badGuy)
        {
            badGuy.health = badGuy.health - damage;
        }
        // logic to move the character around
        public int Right()
        {
            return ++location.y;
        }
        public int Left()
        {
            return --location.y;
        }
        public int Up()
        {
            return --location.x;
        }
        public int Down()
        {
            return ++location.x;
        }

    }
    // define a Bad Guy
    public class BadGuy : People
    {
        public BadGuy()
            : base(20, "&")
        {

            // location.Is(genRandom(), genRandom());
            location.Is(5, 5);

        }
        public override void Action(Player mainPlayer)
        {
            mainPlayer.health = mainPlayer.health - 20;
        }
        public Loc UpdateLocation()
        {
            location.Is(location.x + genRandomX(), location.y + genRandomY());
            return location;
        }

    }
    // define the Mines
    public class Mines : People
    {
        public Mines()
            : base(50, "@")
        {

            location.Is(2, 1);

        }
        public override void Action(Player mainPlayer)
        {
            mainPlayer.health = mainPlayer.health - 50;
        }
        public Loc UpdateLocation()
        {
            location.Is(location.x + genRandomX(), location.y + genRandomY());
            return location;
        }

    }
    // define the Medics

    public class Medic : People
    {
        public Medic()
            : base(20, "$")
        {

            location.Is(10, 10);

        }
        public override void Action(Player mainPlayer)
        {
            mainPlayer.health = mainPlayer.health + 30;
        }
        public Loc UpdateLocation()
        {
            location.Is(location.x + genRandomX(), location.y + genRandomY());
            return location;
        }

    }

    
}