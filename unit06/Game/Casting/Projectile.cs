using System;
using System.Collections.Generic;

namespace Unit06.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class Projectile : Actor
    {
        private Body _body;
        private Animation _animation;
        private Point _bodyPosition;
        
    
    
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Projectile(Body body, Animation animation, bool debug = false) : base(debug)
        {
            // IF velocity = 0 do something else statment, else take velocity from player..
            
            this._body = body;
            this._animation = animation;
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
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Animation GetAnimation()
        {
            return _animation;
        }
    }
}  