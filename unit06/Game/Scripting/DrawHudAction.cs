using Unit06.Game.Casting;
using Unit06.Game.Services;


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

            DrawLabel(cast, Constants.LEVEL_GROUP, Constants.LEVEL_FORMAT, stats.GetLevel());
            DrawLabel(cast, Constants.LIVES_GROUP, Constants.LIVES_FORMAT, stats.GetLives());
            DrawHealth(cast, Constants.SCORE_GROUP, Constants.SCORE_FORMAT, player.GetHealth());
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

        private void DrawHealth(Cast cast, string group, string format, int data)
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