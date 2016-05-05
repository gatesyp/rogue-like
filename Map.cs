using System.Collections.Generic;
using System;
namespace Game
{
    public class Map
    {
        // variables the map needs
        public int x;
        public int y;
        public Loc exit = new Loc();
        // 2d List which holds the map
        public List<List<string>> mapping = new List<List<string>>();

        public Map()
        {
        }
        // initialize the map
        public Map(int X, int Y, Loc InExit)
        {
            
            x = 30;
            y = Y;
            exit = InExit;
            for (int i = 0; i < x; ++i)
            {
                var l = new List<string>();
                mapping.Add(l);

            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (exit.x == i && exit.y == j) mapping[i].Add("!");
                    else mapping[i].Add("*");
                }
            }

        }
        // draw the map
        public void Draw(Player MainGuy, BadGuy BadGuy, Medic Medic, Mines Mine)
        {
            Console.Clear();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(CheckLocation(i, j, MainGuy.location.x, MainGuy.location.y, MainGuy, BadGuy, Medic, Mine));
                    if (i == 0 || j == 0 || j == (x - 1) || i == (x - 1))
                    {
                        // logic to draw the boundaries, and show HUD
                        Console.Write(mapping[i][j]);
                        if (j == x - 1 && i == 2) Console.Write("   Get to the ! symbol, avoid the rest. ");
                        if (j == x - 1 && i == 3) Console.Write("   One of the NPCs is a medic! ");
                        if (j == x - 1 && i == 4) Console.Write("   HEALTH: " + MainGuy.health);
                    }
                    else
                        Console.Write(" ");
                }
                if (i == x - 1) Console.Write(" ");
                else
                Console.WriteLine(" ");
            }


        }
        // check to see if the location of the player is on top of any of the NPC's
        public string CheckLocation(int i, int j, int newX, int newY, Player MainGuy, BadGuy BadGuy1, Medic Medic1, Mines Mine1)
        {
            // location.Print();
            if (i == newX && j == newY) { return MainGuy.symbol; }
            if (i == BadGuy1.location.x && j == BadGuy1.location.y) { return BadGuy1.symbol; }
            if (i == Medic1.location.x && j == Medic1.location.y) { return Medic1.symbol; }
            if (i == Mine1.location.x && j == Mine1.location.y) { return Mine1.symbol; }
            return " ";

        }
        public Loc GetExit()
        {
            return exit;
        }
    }
}
