using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollidePlayerAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollidePlayerAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if(!cast.GroupIsEmpty(Constants.ENEMY_GROUP))
            {
                Enemy enemy = (Enemy)cast.GetFirstActor(Constants.ENEMY_GROUP);
                Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
                Body enemyBody = enemy.GetBody();
                Body playerBody = player.GetBody();
                
                if (_physicsService.HasCollided(playerBody, enemyBody))
                {
                    Sound sound = new Sound(Constants.ENEMY_GROAN_SOUND);
                    _audioService.PlaySound(sound);
                    player.HitPlayer(Constants.ENEMY_DAMAGE);
                }
            }
        }
    }
}