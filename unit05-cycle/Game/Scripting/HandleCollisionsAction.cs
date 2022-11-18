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
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
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
                HandleSnakeCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSnakeCollisions(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetSecondActor("snake");
            Score score = (Score)cast.GetFirstActor("score");
            
            
            // MUST ADD LOGIC FOR THIS

        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetSecondActor("snake");

            Actor head = snake.GetHead();
            Actor head2 = snake2.GetHead();

            List<Actor> body = snake.GetBody();
            List<Actor> body2 = snake2.GetBody();

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
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                // make everything white
                if(PlayerOneWins == true)
                {
                    Snake snake = (Snake)cast.GetSecondActor("snake");
                    List<Actor> segments = snake.GetSegments();

                    Actor message = new Actor();
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
                    Snake snake = (Snake)cast.GetFirstActor("snake");
                    List<Actor> segments = snake.GetSegments();

                    Actor message = new Actor();
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