namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Player : Actor
    {
        private Body _body;
        private Animation _animation;
        private int _health;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Player(Body body, Animation animation, bool debug, int health) : base(debug)
        {
            this._body = body;
            this._animation = animation;
            this._health = health;
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
        /// Swings the player to the left.
        /// </summary>
        public void SwingLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player to the right.
        /// </summary>
        public void SwingRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        public void SwingUp()
        {
            Point velocity = new Point(0, -Constants.PLAYER_VELOCITY);
            _body.SetVelocity(velocity);
        }

        public void SwingDown()
        {
            Point velocity = new Point(0, Constants.PLAYER_VELOCITY);
            _body.SetVelocity(velocity);
        }

                /// <summary>
        /// Swings the player up and to the left.
        /// </summary>
        public void SwingUpLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, -Constants.PLAYER_VELOCITY);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player up and to the right.
        /// </summary>
        public void SwingUpRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, -Constants.PLAYER_VELOCITY);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player down and to the left.
        /// </summary>
        public void SwingDownLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, Constants.PLAYER_VELOCITY);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player down and to the Right.
        /// </summary>
        public void SwingDownRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, Constants.PLAYER_VELOCITY);
            _body.SetVelocity(velocity);
        }

        public int GetHealth()
        {
            return _health;
        }

        public void HitPlayer(int ENEMY_DAMAGE)
        {
            _health = _health - ENEMY_DAMAGE;
        }

        public void ShootProjectile()
        {
            Point position = _body.GetPosition();
            Point velocity = _body.GetVelocity();
            // Projectile projectile = new Projectile(_body, _image, false);

        }


        /// <summary>
        /// Stops the player from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            _body.SetVelocity(velocity);
        }
        
    }
}