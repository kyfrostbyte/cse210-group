using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlPlayerAction : Action
    {
        private KeyboardService _keyboardService;

        public ControlPlayerAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            if (_keyboardService.IsKeyDown(Constants.LEFT))
            {
                if ((_keyboardService.IsKeyDown(Constants.LEFT)) && (_keyboardService.IsKeyDown(Constants.UP)))
                {
                    player.SwingUpLeft();
                }
                else if ((_keyboardService.IsKeyDown(Constants.LEFT)) && (_keyboardService.IsKeyDown(Constants.DOWN)))
                {
                    player.SwingDownLeft();
                }
                else
                {
                    player.SwingLeft();
                }
            }
            else if (_keyboardService.IsKeyDown(Constants.RIGHT))
            {
                if ((_keyboardService.IsKeyDown(Constants.RIGHT)) && (_keyboardService.IsKeyDown(Constants.UP)))
                {
                    player.SwingUpRight();
                }
                else if ((_keyboardService.IsKeyDown(Constants.RIGHT)) && (_keyboardService.IsKeyDown(Constants.DOWN)))
                {
                    player.SwingDownRight();
                }
                else
                {
                    player.SwingRight();
                }
            }
            else if (_keyboardService.IsKeyDown(Constants.UP))
            {
                if ((_keyboardService.IsKeyDown(Constants.RIGHT)) && (_keyboardService.IsKeyDown(Constants.UP)))
                {
                    player.SwingUpRight();
                }
                else if ((_keyboardService.IsKeyDown(Constants.LEFT)) && (_keyboardService.IsKeyDown(Constants.UP)))
                {
                    player.SwingUpLeft();
                }
                else
                {
                    player.SwingUp();
                }

            }
            else if (_keyboardService.IsKeyDown(Constants.DOWN))
            {
                if ((_keyboardService.IsKeyDown(Constants.RIGHT)) && (_keyboardService.IsKeyDown(Constants.DOWN)))
                {
                    player.SwingDownRight();
                }
                else if ((_keyboardService.IsKeyDown(Constants.LEFT)) && (_keyboardService.IsKeyDown(Constants.DOWN)))
                {
                    player.SwingDownLeft();
                }
                else
                {
                    player.SwingDown();
                }
            }
            else
            {
                player.StopMoving();
            }

            if (_keyboardService.IsKeyDown(Constants.SPACE))
            {
                player.ShootProjectile();
            }
        }
    }
}