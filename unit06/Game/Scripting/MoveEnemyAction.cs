using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;

namespace Unit06.Game.Scripting
{
    public class MoveEnemyAction : Action
    {

        public MoveEnemyAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Body playerBody = player.GetBody();
            Point playerPosition = playerBody.GetPosition();
            Point playerVelocity = playerBody.GetVelocity();
            int playerX = playerPosition.GetX();
            int playerY = playerPosition.GetY();


            List<Actor> enemys = cast.GetActors(Constants.ENEMY_GROUP);
            foreach (Actor actor in enemys)
            {

                Enemy enemy = (Enemy)actor;
                Body body = enemy.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                int x = position.GetX();
                int y = position.GetY();

                if (playerX > x)
                {
                    position = new Point(x + Constants.ENEMY_VELOCITY, position.GetY());
                }
                else if (playerX < x)
                {
                    position = new Point(x - Constants.ENEMY_VELOCITY, position.GetY());
                }


                if (playerY > y)
                {
                    position = new Point(position.GetX(), y + Constants.ENEMY_VELOCITY);
                }
                else if (playerY < y)
                {
                    position = new Point(position.GetX(), y - Constants.ENEMY_VELOCITY);
                }

            // if (x < 0)
            // {
            //     position = new Point(0, position.GetY());
            // }
            // else if (x > Constants.SCREEN_WIDTH - Constants.ENEMY_WIDTH)
            // {
            //     position = new Point(Constants.SCREEN_WIDTH - Constants.ENEMY_WIDTH, 
            //         position.GetY());
            // }

                body.SetPosition(position);       
            }
        }
    }
}