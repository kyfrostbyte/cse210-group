// using System;
// using System.Collections.Generic;


// namespace Unit06.Game.Casting
// {
//     /// <summary>
//     /// 
//     /// </summary>
//     public class Projectile : Actor
//     {
//         private Body _body;
//         private Image _image;

//         /// <summary>
//         /// Constructs a new instance of Actor.
//         /// </summary>
//         public Projectile(Body body, Image image, bool debug = false) : base(debug)
//         {
//             this._body = body;
//             this._image = image;
//         }

//         /// <summary>
//         /// Bounces the ball horizontally.
//         /// </summary>
//         public void ShootProjectile()
//         {
//             Point velocity = _body.GetVelocity();
//             double rn = (_random.NextDouble() * (1.2 - 0.8) + 0.8);
//             double vx = velocity.GetX() * -1;
//             double vy = velocity.GetY();
//             Point newVelocity = new Point((int)vx, (int)vy);
//             _body.SetVelocity(newVelocity);
//         }

        
//         /// <summary>
//         /// Gets the body.
//         /// </summary>
//         /// <returns>The body.</returns>
//         public Body GetBody()
//         {
//             return _body;
//         }

//         /// <summary>
//         /// Gets the image.
//         /// </summary>
//         /// <returns>The image.</returns>
//         public Image GetImage()
//         {
//             return _image;
//         }
//     }
// }  