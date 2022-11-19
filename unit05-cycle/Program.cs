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
            // Creates the cast
            Cast cast = new Cast();

            // Creates 2 instances of cycle
            cast.AddActor("cycle", new Cycle(450, 195, Constants.RED));
            cast.AddActor("cycle", new Cycle(450, 405, Constants.YELLOW));

            // Creates a new intance of score
            cast.AddActor("score", new Score());

            // Creates the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // Creates the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // Starts the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}