using System;
using System.Reflection;

namespace Game
{
    public class Game
    {
        Loc exitPoint = new Loc();
        GameEngine engine = new GameEngine();
        void loadExtensions()
        {
            // extension logic
            var DLL = Assembly.LoadFile(@"C:\Users\gatesyp\Documents\Visual Studio 2015\Projects\Game\Game\Extensions\EndScreen.dll");
            var class1Type = DLL.GetType("Game.EndScreenExtension");
            dynamic c = Activator.CreateInstance(class1Type);
            string end = c.GetEnding();
            engine.endScreen = end;
        }
        public Game(int param)
        {
            Console.Clear();
            
            // load players and objects
            exitPoint.Is(0, 0);
            
            // create the engine with initial inputs
            engine = new GameEngine(30, 30, exitPoint);
            engine.Init();
            // if param is 48 (number assigned to key '0'), start game w/ extensions
            // else, vanilla game is created
            if (param == 48)
                loadExtensions();

            var mainPlayer = engine.GetPlayer();
        }

        // will start the game loop
        public void Loop()
        {
            // game loop starts here. calls for event checks from engine and moves the player according to key presses
            for (;;)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;

                    if (key == ConsoleKey.UpArrow)
                    {
                        engine.mainPlayer.Up();
                        engine.CheckEvents();
                    }
                    if (key == ConsoleKey.DownArrow)
                    {
                        engine.mainPlayer.Down();
                        engine.CheckEvents();
                    }
                    if (key == ConsoleKey.LeftArrow)
                    {
                        engine.mainPlayer.Left();
                        engine.CheckEvents();
                    }
                    if (key == ConsoleKey.RightArrow)
                    {
                        engine.mainPlayer.Right();
                        engine.CheckEvents();
                    }

                }
            }


        }

    }
}