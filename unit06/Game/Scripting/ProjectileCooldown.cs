// using System;
// using Unit06.Game.Casting;
// using Unit06.Game.Services;


// namespace Unit06.Game.Scripting
// {
//     public class ProjectileCooldown : Action
//     {
//         private string _nextScene;
//         private double _delay;
//         private DateTime _start;
        
//         public ProjectileCooldown(DateTime start)
//         {
//             this._start = start;
//         }

//         public void Execute(Cast cast, Script script, ActionCallback callback)
//         {
//             DateTime currentTime = DateTime.Now;
//             TimeSpan elapsedTime = currentTime.Subtract(_start);

//             TimeSpan projectileCooldown = 2;
//             if (elapsedTime % 2 == 0)
//             {
//                 callback.OnNext(_nextScene);
//             }
//         }
//     }
// }