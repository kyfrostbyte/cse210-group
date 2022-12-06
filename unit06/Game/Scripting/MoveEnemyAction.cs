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
            Racket racket = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
            Body playerBody = racket.GetBody();
            Point playerPosition = playerBody.GetPosition();
            Point playerVelocity = playerBody.GetVelocity();
            int playerX = playerPosition.GetX();
            int playerY = playerPosition.GetY();

            Enemy enemy = (Enemy)cast.GetFirstActor(Constants.ENEMY_GROUP);
            Body body = enemy.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();
            int y = position.GetY();

            if (playerX > x)
            {
                position = new Point(x + 7, position.GetY());
            }
            else if (playerX < x)
            {
                position = new Point(x - 7, position.GetY());
            }

            if (playerY > y)
            {
                position = new Point(position.GetX(), y + 7);
            }
            else if (playerY < y)
            {
                position = new Point(position.GetX(), y = 7);
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