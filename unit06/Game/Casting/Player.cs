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
        /// Moves the racket to its next position.
        /// </summary>
        public void MoveNext()
        {
            Point position = _body.GetPosition();
            Point velocity = _body.GetVelocity();
            Point newPosition = position.Add(velocity);
            _body.SetPosition(newPosition);
        }

        /// <summary>
        /// Swings the racket to the left.
        /// </summary>
        public void SwingLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Swings the racket to the right.
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

        public int GetHealth()
        {
            return _health;
        }

        public void HitPlayer(int ENEMY_DAMAGE)
        {
            _health = _health - ENEMY_DAMAGE;
        }


        /// <summary>
        /// Stops the racket from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            _body.SetVelocity(velocity);
        }
        
    }
}