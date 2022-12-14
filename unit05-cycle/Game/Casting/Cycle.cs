using System;
using System.Collections.Generic;
using System.Linq;

namespace unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>Bikes that leave an untouchable trail.</para>
    /// <para>The responsibility of Cycle is to move itself.</para>
    /// </summary>
    public class Cycle : Actor
    {
        private List<Actor> _segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of a Cycle.
        /// </summary>
        public Cycle(int x, int y, Color color)
        {
            PrepareBody(x, y, color);
        }

        /// <summary>
        /// Gets the cycle's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(_segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the cycle's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return _segments[0];
        }

        /// <summary>
        /// Gets the cycle's segments (including the head).
        /// </summary>
        /// <returns>A list of cycle segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return _segments;
        }

        public void ResetTailPower()
        {
            int length = _segments.Count();
            Actor head = _segments[0];
            _segments.Clear();
            _segments.Add(head);
            for (int i = 0; i < 8; i++)
            {
                Actor tail = _segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);
                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(tail.GetColor());
                _segments.Add(segment);
            }
        }

        public void GrowTailPower()
        {
            for (int i = 0; i < 8; i++)
            {
                Actor tail = _segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(tail.GetColor());
                _segments.Add(segment);
            }
        }

        /// <summary>
        /// Grows the cycle's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = _segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(tail.GetColor());
                _segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in _segments)
            {
                segment.MoveNext();
            }

            for (int i = _segments.Count - 1; i > 0; i--)
            {
                Actor trailing = _segments[i];
                Actor previous = _segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the head of the cycle in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            _segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the cycle body for moving.
        /// </summary>
        private void PrepareBody(int x, int y, Color color)
        {
            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {

                // put in constructer and pass in x and y
                Point position = new Point(x - i * Constants.CELL_SIZE, y);

                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);

                // if I = 0, return 8, else return #
                string text = i == 0 ? "8" : "#";
                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                _segments.Add(segment);
            }

        
        }
    }
}