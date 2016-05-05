using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameEngine
    {
        // initialize the NPCs and important vars

        public Player mainPlayer = new Player();
        public BadGuy BadGuy1 = new BadGuy();
        public Medic Medic1 = new Medic();
        public Mines Mine1 = new Mines();
        int x;
        int y;
        Loc exitPoint = new Loc();
        Map map = new Map();

        public GameEngine() { }

        // default constructor defining the boundaries
        public GameEngine(int X, int Y, Loc exit)
        {
            x = X;
            y = Y;
            exitPoint = exit;
        }
        // getter for MC
        public Player GetPlayer()
        {
            return mainPlayer;
        }

        // initialize the map and draw it
        public void Init()
        {
            map = new Map(x, y, exitPoint);
            map.Draw(mainPlayer, BadGuy1, Medic1, Mine1);
        }
        public string endScreen = "┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\n███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀\n██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼\n██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀\n██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼\n███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\n███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼\n██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼\n██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼\n██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼\n███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼\n┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼\n";

        // function to print the end game screen
        void printEnd()
        {
            Console.WriteLine(endScreen + "\n\n");
            Console.WriteLine("Press <Enter> to exit... ");
        }

        // function to check for events
        // such as if they die, or reach the exit
        // or if they touch an NPC
        public void CheckEvents()
        {
            // if reached a end condition
            if (EndCondition(mainPlayer))
            {
                Console.Clear();
                printEnd();
                Console.WriteLine();
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                Environment.Exit(0);
            }
            // when touching a BadGuy
            if (mainPlayer.location == BadGuy1.UpdateLocation())
            {
                Console.WriteLine("BADGUY HAPPENED");
                BadGuy1.Action(mainPlayer);
            }
            // when touching a Medic
            if (mainPlayer.location == Medic1.UpdateLocation())
            {
                Console.WriteLine("MEDIC HAPPENED");
                Medic1.Action(mainPlayer);

            }
            // when touching a Mine
            if (mainPlayer.location == Mine1.UpdateLocation())
            {
                Console.WriteLine("ON A MINE HAPPENED");
                Mine1.Action(mainPlayer);

            }
            // Draw the map after performing actions
            map.Draw(mainPlayer, BadGuy1, Medic1, Mine1);


        }

        // define the end condition as either reaching checkpoint or having HP below 0
        public bool EndCondition(Player mainPlayer)
        {

            if (mainPlayer.health < 1)
                return true;
            if (mainPlayer.location == map.GetExit())
            {
                return true;
            }
            return false;
        }
    }
}
