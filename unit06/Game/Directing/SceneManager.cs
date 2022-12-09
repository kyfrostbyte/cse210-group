using System;
using System.Collections.Generic;
using System.IO;
using Unit06.Game.Casting;
using Unit06.Game.Scripting;
using Unit06.Game.Services;


namespace Unit06.Game.Directing
{
    public class SceneManager
    {
        public DateTime _start;
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.NEXT_LEVEL)
            {
                PrepareNextLevel(cast, script);
            }
            else if (scene == Constants.TRY_AGAIN)
            {
                PrepareTryAgain(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {

            AddStats(cast);
            AddHealth(cast);
            AddScore(cast);
            AddLives(cast);
            AddPlayer(cast);
            AddEnemy(cast);

            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.NEXT_LEVEL);
            script.AddAction(Constants.INPUT, a);

            AddOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        public DateTime getStart()
        {
            return _start;

        }



        private void PrepareNextLevel(Cast cast, Script script)
        {
            AddPlayer(cast);
            AddDialog(cast, Constants.PREP_TO_LAUNCH);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);

            PlaySoundAction sa = new PlaySoundAction(AudioService, Constants.WELCOME_SOUND);
            script.AddAction(Constants.OUTPUT, sa);
        }

        private void PrepareTryAgain(Cast cast, Script script)
        {
            AddPlayer(cast);
            AddEnemy(cast);
            AddDialog(cast, Constants.PREP_TO_LAUNCH);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.IN_PLAY, 2, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddUpdateActions(script);
            AddOutputActions(script);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            script.ClearAllActions();

            ControlPlayerAction action = new ControlPlayerAction(KeyboardService);
            script.AddAction(Constants.INPUT, action);

            AddUpdateActions(script);
            AddOutputActions(script);

        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            AddPlayer(cast);
            AddEnemy(cast);
            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();

            TimedChangeSceneAction ta = new TimedChangeSceneAction(Constants.NEW_GAME, 5, DateTime.Now);
            script.AddAction(Constants.INPUT, ta);

            AddOutputActions(script);
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------


        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE,
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

            Text text2 = new Text("Move with WASD", Constants.FONT_FILE, Constants.FONT_SIZE,
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position2 = new Point(Constants.CENTER_X, Constants.CENTER_Y + 100);

            Label label = new Label(text, position);
            Label label2 = new Label(text2, position2);
            cast.AddActor(Constants.DIALOG_GROUP, label);
            cast.AddActor(Constants.DIALOG_GROUP, label2);
        }

        

        private void AddLives(Cast cast)
        {
            cast.ClearActors(Constants.TIME_GROUP);

            Text text = new Text(Constants.TIME_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE,
                Constants.ALIGN_RIGHT, Constants.WHITE);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN,
                Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.TIME_GROUP, label);
        }

        private void AddScore(Cast cast)
        {
            cast.ClearActors(Constants.SCORE_GROUP);

            Text text = new Text(Constants.SCORE_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE,
                Constants.ALIGN_LEFT, Constants.WHITE);
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.SCORE_GROUP, label);
        }
        private void AddHealth(Cast cast)
        {
            cast.ClearActors(Constants.HEALTH_GROUP);

            Text text = new Text(Constants.HEALTH_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE,
                Constants.ALIGN_CENTER, Constants.WHITE);
            Point position = new Point(Constants.CENTER_X, Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.HEALTH_GROUP, label);
        }

        private void AddStats(Cast cast)
        {
            cast.ClearActors(Constants.STATS_GROUP);
            Stats stats = new Stats();
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private void AddPlayer(Cast cast)
        {
            cast.ClearActors(Constants.PLAYER_GROUP);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);
            Point size = new Point(Constants.PLAYER_WIDTH, Constants.PLAYER_HEIGHT);
            Point velocity = new Point(0, 0);
            Body body = new Body(position, size, velocity);
            Animation animation = new Animation(Constants.PLAYER_IMAGES, Constants.PLAYER_RATE, 0);
            Player player = new Player(body, animation, false, Constants.PLAYER_HEALTH);
            cast.AddActor(Constants.PLAYER_GROUP, player);
        }

        private void AddEnemy(Cast cast)
        {
            cast.ClearActors(Constants.ENEMY_GROUP);
            int x = 0;
            int y = 0;
            Random random = new Random();
            for (int i = 0; i < Constants.ENEMY_COUNT; i++)
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

            }
        }


        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService,
                VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }

        private void AddOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawPlayerAction(VideoService));
            script.AddAction(Constants.OUTPUT, new SpawnProjectileAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawEnemyAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new CollideEnemyAction(PhysicsService, AudioService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService,
                VideoService));
        }

        private void AddUpdateActions(Script script)
        {
            script.AddAction(Constants.UPDATE, new MovePlayerAction());
            script.AddAction(Constants.UPDATE, new MoveEnemyAction());
            script.AddAction(Constants.UPDATE, new MoveProjectileAction());
            script.AddAction(Constants.UPDATE, new DrawProjectileAction(VideoService));   
            script.AddAction(Constants.UPDATE, new CollidePlayerAction(PhysicsService, AudioService));
        }
    }
}