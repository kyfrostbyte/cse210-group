using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Diagnostics;
using Raylib_cs;


namespace Unit06.Game.Scripting
{
    public class DrawHudAction : Action
    {
        private VideoService _videoService;
        
        public DrawHudAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            double timer = Raylib.GetTime();
            string timer1 = timer.ToString("#");

            DrawLabel(cast, Constants.SCORE_GROUP, Constants.SCORE_FORMAT, stats.GetScore());
            DrawTextLabel(cast, Constants.TIME_GROUP, Constants.TIME_FORMAT, timer1);
            DrawLabel(cast, Constants.HEALTH_GROUP, Constants.HEALTH_FORMAT, player.GetHealth());
        }

        private void DrawLabel(Cast cast, string group, string format, int data)
        {
            string theValueToDisplay = string.Format(format, data);
            
            Label label = (Label)cast.GetFirstActor(group);
            Text text = label.GetText();
            text.SetValue(theValueToDisplay);
            Point position = label.GetPosition();
            _videoService.DrawText(text, position);
        }

        private void DrawTextLabel(Cast cast, string group, string format, string data)
        {
            string theValueToDisplay = string.Format(format, data);
            
            Label label = (Label)cast.GetFirstActor(group);
            Text text = label.GetText();
            text.SetValue(theValueToDisplay);
            Point position = label.GetPosition();
            _videoService.DrawText(text, position);
        }

    }
}