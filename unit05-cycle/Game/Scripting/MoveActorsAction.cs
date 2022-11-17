using System;
using System.Collections.Generic;
using unit05_cycle.Game.Casting;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>

    public class MoveActorsAction : Action
    {

        int _counter = 1;

        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActorsAction()
        {
        }

        // 3) Override the Execute(Cast cast, Script script) method. Use the following 
        //    method comment. You custom implementation should do the following:
        //    a) get all the actors from the cast
        //    b) loop through all the actors
        //    c) call the MoveNext() method on each actor.
        public void Execute(Cast cast, Script script)
        {
            
            List<Actor> actors = cast.GetAllActors();
            Snake snakeOne = (Snake)cast.GetFirstActor("snake");
            Snake snakeTwo = (Snake)cast.GetSecondActor("snake");
            foreach(Actor actor in actors)
            {
                actor.MoveNext();
                _counter += 1;
                if(_counter % 50 == 0)
                {
                    snakeOne.GrowTail(1);
                    snakeTwo.GrowTail(1);  
                }
            }
        }

        

    }

}