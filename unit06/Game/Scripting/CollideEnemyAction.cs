using System;
using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollideEnemyAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideEnemyAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if(!cast.GroupIsEmpty(Constants.PROJECTILE_GROUP))
            {
                Projectile projectile = (Projectile)cast.GetFirstActor(Constants.PROJECTILE_GROUP);
                List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);
                Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);


                foreach (Actor actor in enemies)
                {
                    Enemy enemy = (Enemy)actor;
                    Body enemyBody = enemy.GetBody();
                    Body projectileBody = projectile.GetBody();

                    if (_physicsService.HasCollided(projectileBody, enemyBody))
                    {
                        Sound sound = new Sound(Constants.ENEMY_GROAN_SOUND);
                        _audioService.PlaySound(sound);

                        cast.RemoveActor(Constants.ENEMY_GROUP, enemy);
                        cast.RemoveActor(Constants.PROJECTILE_GROUP, projectile);

                        int points = 10;
                        stats.AddPoints(points);
                    }
                }
            }
        }
    }
}