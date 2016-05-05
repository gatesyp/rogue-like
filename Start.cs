using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Start
    {
        static void Main(string[] args)
        {
            // create new game (starts game engine)
            Console.WriteLine("Input 0 if you want to use extended end screen pack");
            Console.WriteLine("Input anything else if you want vanilla game");
            var game = new Game(Console.Read());

            // start the game loop
            game.Loop();

        }
    }
}
