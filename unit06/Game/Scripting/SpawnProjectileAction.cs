using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Diagnostics;
using System;

namespace Unit06.Game.Scripting
{
    public class SpawnProjectileAction : Action
    {
        private VideoService _videoService;
        
        public SpawnProjectileAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Body playerBody = player.GetBody();
            Point playerPosition = playerBody.GetPosition();
            Point playerVelocity = playerBody.GetVelocity();

            
            Point size = new Point(Constants.PROJECTILE_WIDTH, Constants.PROJECTILE_HEIGHT);
            Animation animation = new Animation(Constants.PROJECTILE_IMAGES, Constants.ENEMY_RATE, 0);
            Body projectileBody = new Body(playerPosition.Add(player.GetShootDirection()), size, playerVelocity);
            
            Projectile projectile = new Projectile(projectileBody, animation, false);

            cast.AddActor(Constants.PROJECTILE_GROUP, projectile);
            
        }
    }
}