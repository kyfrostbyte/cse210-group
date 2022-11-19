using System.Collections.Generic;
using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of DrawActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // Gets the 2 instances of cycle to enable access to their segments
            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            List<Actor> segments = cycle.GetSegments();
            Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");
            List<Actor> segments2 = cycle2.GetSegments();


            List<Actor> messages = cast.GetActors("messages");
            
            // Draws cycles on screen
            _videoService.ClearBuffer();
            _videoService.DrawActors(segments);
            _videoService.DrawActors(segments2);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}