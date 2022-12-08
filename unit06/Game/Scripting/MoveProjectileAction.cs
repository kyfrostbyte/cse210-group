using Unit06.Game.Casting;
namespace Unit06.Game.Scripting
{
    public class MoveProjectileAction : Action
    {
        public MoveProjectileAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Projectile projectile = (Projectile)cast.GetFirstActor(Constants.PROJECTILE_GROUP);
            Body body = projectile.GetBody();

            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Body playerBody = player.GetBody();

            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();


            Point pointZero = new Point(0, 0);
            Point pointMove = new Point(0, -5);

            if (velocity == pointZero)
            {
                velocity = pointMove;
            }
            

            Point newPosition = position.Add(velocity);
            
            body.SetPosition(newPosition);
        }
    }
}