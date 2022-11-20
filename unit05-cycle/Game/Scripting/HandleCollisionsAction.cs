using System;
using System.Collections.Generic;
using System.Data;
using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the cycle 
    /// collides with the food, or the cycle collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;
        private bool PlayerOneWins = true;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGreenPowerCollisions(cast);
                HandleWhitePowerCollisions(cast);
                HandleGameOver(cast);
            }
        }
        // If a cycle touches the green power up, it causes the other cycles trail to reset
        private void HandleGreenPowerCollisions(Cast cast)
        {
            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");
            Power power = (Power)cast.GetFirstActor("power");
            
            if (cycle.GetHead().GetPosition().Equals(power.GetPosition()))
            {
                cycle2.ResetTailPower();
                power.Reset();
            }

            if (cycle2.GetHead().GetPosition().Equals(power.GetPosition()))
            {
                cycle.ResetTailPower();
                power.Reset();
            }
        }

        // If a cycle touches the white power up, it causes its trail to get 8 new segments instantly
        private void HandleWhitePowerCollisions(Cast cast)
        {
            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");
            Power power = (Power)cast.GetSecondActor("power");
            
            if (cycle.GetHead().GetPosition().Equals(power.GetPosition()))
            {
                cycle.GrowTailPower();
                power.Reset();
            }

            if (cycle2.GetHead().GetPosition().Equals(power.GetPosition()))
            {
                cycle2.GrowTailPower();
                power.Reset();
            }
        }

        /// <summary>
        /// Sets the game over flag if the cycle collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
            Cycle cycle2 = (Cycle)cast.GetSecondActor("cycle");

            Actor head = cycle.GetHead();
            Actor head2 = cycle2.GetHead();

            List<Actor> body = cycle.GetBody();
            List<Actor> body2 = cycle2.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    _isGameOver = true;
                    Console.WriteLine("Player Two Loses");
                    PlayerOneWins = true;
                }
            }

            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    _isGameOver = true;
                    Console.WriteLine("Player One Loses");
                    PlayerOneWins = false;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                // create a "game over" message
                int x = Constants.MAX_X / 4;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                // make everything white
                if(PlayerOneWins == true)
                {
                    Cycle cycle = (Cycle)cast.GetSecondActor("cycle");
                    List<Actor> segments = cycle.GetSegments();

                    Actor message = new Actor();
                    message.SetFontSize(30);
                    message.SetText("Game Over! Player One Wins!");
                    message.SetPosition(position);
                    cast.AddActor("messages", message);
                    foreach (Actor segment in segments)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                }
                else if(PlayerOneWins == false)
                {
                    Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
                    List<Actor> segments = cycle.GetSegments();

                    Actor message = new Actor();
                    message.SetFontSize(30);
                    message.SetText("Game Over! Player Two Wins!");
                    message.SetPosition(position);
                    cast.AddActor("messages", message);
                    foreach (Actor segment in segments)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                }
            }
        }

    }
}