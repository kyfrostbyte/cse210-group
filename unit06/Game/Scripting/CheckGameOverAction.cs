using System;
using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CheckGameOverAction : Action
    {
        public CheckGameOverAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {

            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            if (player.GetHealth() == 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
                callback.OnNext(Constants.GAME_OVER);
            }
        }
    }
}