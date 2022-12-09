using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Diagnostics;
using System;

namespace Unit06.Game.Scripting
{
    public class SpawnEnemiesAction : Action
    {
        private VideoService _videoService;
        private double _delay = 2;
        private DateTime _start;
        private int _numberToSpawn = 1;

        
        public SpawnEnemiesAction(VideoService videoService, DateTime start)
        {
            this._videoService = videoService;
            this._start = start;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)

        {
            int x = 0;
            int y = 0;
            Random random = new Random();

            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime.Subtract(_start);
            // Console.WriteLine(elapsedTime);
            // Console.WriteLine(elapsedTime.Seconds);
            if (elapsedTime.Seconds > _delay)
            { 
                for (int i = 0; i < 1; i++)
                {
                    int _side = random.Next(1,5);

                    if (_side == 1)
                    {
                        x = random.Next(0, 1200);
                        y = 0;
                    }
                    else if (_side == 2)
                    {
                        x = random.Next(0, 1200);
                        y = 750; 
                    }
                    else if (_side == 3)
                    {
                        x = 0;
                        y = random.Next(0, 800);
                    }
                    else if(_side == 4)
                    {
                        x = 1150;
                        y = random.Next(0, 800);
                    }

                    Point position = new Point(x, y);
                    Point size = new Point(Constants.ENEMY_WIDTH, Constants.ENEMY_HEIGHT);
                    Point velocity = new Point(0, 0);

                    Body body = new Body(position, size, velocity);
                    Animation animation = new Animation(Constants.ENEMY_IMAGES, Constants.ENEMY_RATE, 0);
                    Enemy enemy = new Enemy(body, animation, false, Constants.ENEMY_HEALTH);
                    cast.AddActor(Constants.ENEMY_GROUP, enemy);

                    i = 0;
                    Console.WriteLine(elapsedTime);
                    Console.WriteLine(elapsedTime.Seconds);
                    Console.WriteLine(_delay);
                    _delay += 1;
                    if(_delay == 59)
                    {
                        _delay = 1;
                    }
                }
            }
        }
    }
}