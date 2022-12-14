namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Enemy : Actor
    {
        private Body _body;
        private Animation _animation;
        private int _enemyHealth;
        
        /// <summary>
        /// Constructs a new instance of Enemy.
        /// </summary>
        public Enemy(Body body, Animation animation, bool debug, int enemyHealth) : base(debug)
        {
            this._body = body;
            this._animation = animation;
            this._enemyHealth = enemyHealth;
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        public Animation GetAnimation()
        {
            return _animation;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return _body;
        }

        /// <summary>
        /// Gets the enemy health
        /// </summary>
        /// <returns> Enemy Health </returns>
        public int GetEnemyHealth()
        {
            return _enemyHealth;
        }
        /// <summary>
        /// Reduces the enemy health by 
        /// projectile damage amount
        /// </summary>
        public void hitEnemy(int PROJECTILE_DAMAGE)
        {
            _enemyHealth = _enemyHealth - PROJECTILE_DAMAGE;
        }

        
    }
}