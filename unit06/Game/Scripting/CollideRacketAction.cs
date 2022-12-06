using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollideRacketAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideRacketAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Enemy enemy = (Enemy)cast.GetFirstActor(Constants.ENEMY_GROUP);

            Racket player = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
            Body enemyBody = enemy.GetBody();
            Body racketBody = player.GetBody();
            int health = player.GetHealth();

            if (_physicsService.HasCollided(racketBody, enemyBody))
            {
                Sound sound = new Sound(Constants.BOUNCE_SOUND);
                _audioService.PlaySound(sound);
                player.HitPlayer();

            }
        }
    }
}