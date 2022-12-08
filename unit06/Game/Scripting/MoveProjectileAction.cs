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

            Point position1 = body.GetPosition();
            Point velocity = playerBody.GetVelocity();

            Point position = position1.Add(velocity);

            body.SetPosition(position);  
        }
    }
}