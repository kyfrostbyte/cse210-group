using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawProjectileAction : Action
    {
        private VideoService _videoService;
        
        public DrawProjectileAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Projectile projectile = (Projectile)cast.GetFirstActor(Constants.PROJECTILE_GROUP);
            Body body = projectile.GetBody();

            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Body playerBody = player.GetBody();
            Point playerDirection = playerBody.GetPosition();

            if (projectile.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Image image = projectile.GetImage();
            Point position = body.GetPosition();

            _videoService.DrawImage(image, position);

            int positionX = position.GetX();
            int positionY = position.GetY();

            if(positionX > Constants.SCREEN_WIDTH || positionX < -50)
            {
                cast.ClearActors(Constants.PROJECTILE_GROUP);
            }

            if(positionY > Constants.SCREEN_HEIGHT || positionY < -50)
            {
                cast.ClearActors(Constants.PROJECTILE_GROUP);
            }
        }
    }
}