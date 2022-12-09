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
            if(!cast.GroupIsEmpty(Constants.PROJECTILE_GROUP))
            {
                Projectile projectile = (Projectile)cast.GetFirstActor(Constants.PROJECTILE_GROUP);
                Body projectileBody = projectile.GetBody();
                Point position = projectileBody.GetPosition();
                Point velocity = projectileBody.GetVelocity();

                Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
                Point playerDirection = player.GetDirection();
                Point pointZero = new Point(0, 0);

                if(velocity.Equals(pointZero))
                {
                    projectileBody.SetVelocity(playerDirection);
                }

                Point newPosition = position.Add(velocity.Scale(2));
                projectileBody.SetPosition(newPosition);
            }
        }
    }
}