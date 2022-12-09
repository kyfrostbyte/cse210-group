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
        private Point _direction = new Point(0, -5);
        
        /// <summary>
        /// Constructs a new instance of Player.
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
            _direction = velocity;
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player to the right.
        /// </summary>
        public void SwingRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, 0);
            _direction = velocity;
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player up.
        /// </summary>
        public void SwingUp()
        {
            Point velocity = new Point(0, -Constants.PLAYER_VELOCITY);
            _direction = velocity;
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player down.
        /// </summary>
        public void SwingDown()
        {
            Point velocity = new Point(0, Constants.PLAYER_VELOCITY);
            _direction = velocity;
            _body.SetVelocity(velocity);
        }

                /// <summary>
        /// Swings the player up and to the left.
        /// </summary>
        public void SwingUpLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, -Constants.PLAYER_VELOCITY);
            _direction = velocity;
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player up and to the right.
        /// </summary>
        public void SwingUpRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, -Constants.PLAYER_VELOCITY);
            _direction = velocity;
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player down and to the left.
        /// </summary>
        public void SwingDownLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, Constants.PLAYER_VELOCITY);
            _direction = velocity;
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the player down and to the Right.
        /// </summary>
        public void SwingDownRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, Constants.PLAYER_VELOCITY);
            _direction = velocity;
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Gets the direction.
        /// </summary>
        /// <returns>The direction.</returns>
        public Point GetDirection()
        {
            return _direction;
        }

        /// <summary>
        /// Gets the players heath.
        /// </summary>
        /// <returns>The players health.</returns>
        public int GetHealth()
        {
            return _health;
        }

        /// <summary>
        /// Reduces player health if hit
        /// </summary>

        public void HitPlayer(int ENEMY_DAMAGE)
        {
            _health = _health - ENEMY_DAMAGE;
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