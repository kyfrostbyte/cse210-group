using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Directing;
using unit05_cycle.Game.Scripting;
using unit05_cycle.Game.Services;
using System.Collections.Generic;


namespace unit05_cycle
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            Color RED = new Color(255, 0, 0);
            Color WHITE = new Color(255, 255, 255);
            // create the cast

            
            Cast cast = new Cast();
            cast.AddActor("food", new Food());
            cast.AddActor("snake", new Snake());
            cast.AddActor("snake", new Snake());

            Snake snake = (Snake)cast.GetFirstActor("snake");
            snake.SetPosition(new Point(300, 300));

            Snake snake2 = (Snake)cast.GetSecondActor("snake");
            snake2.SetPosition(new Point(100, 100));
            List<Actor> segments2 = snake2.GetSegments();
            foreach(Actor segment in segments2)
            {
                segment.SetColor(RED);
            }
            segments2[0].SetColor(WHITE);

            

            
            cast.AddActor("score", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}