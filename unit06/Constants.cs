using System.Collections.Generic;
using Unit06.Game.Casting;
using System.Diagnostics;


namespace Unit06
{
    public class Constants
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Survivor";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int SCREEN_WIDTH = 1200;
        public static int SCREEN_HEIGHT = 800;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;

        // FIELD
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";
        public static string ENEMY_GROAN_SOUND = "Assets/Sounds/groan.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;

        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);

        // KEYS
        public static string LEFT = "a";
        public static string RIGHT = "d";
        public static string UP = "w";
        public static string DOWN = "s";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVELS
        public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        public static int BASE_LEVELS = 5;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string LEVEL_GROUP = "level";
        public static string TIME_GROUP = "time";
        public static string SCORE_GROUP = "score";
        public static string HEALTH_GROUP = "health";
        public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string TIME_FORMAT = "TIME: {0}";
        public static string SCORE_FORMAT = "SCORE: {0}";
        public static string HEALTH_FORMAT = "HEALTH: {0}";

        // BALL
        public static string BALL_GROUP = "balls";
        public static string BALL_IMAGE = "Assets/Images/000.png";
        public static int BALL_WIDTH = 28;
        public static int BALL_HEIGHT = 28;
        public static int BALL_VELOCITY = 6;

        // Projectiles
        public static int PROJECTILE_WIDTH = 25;
        public static int PROJECTILE_HEIGHT = 20;
        public static int PROJECTILE_VELOCITY = 12;
        public static int PROJECTILE_DAMAGE = 5;
        public static string PROJECTILE_GROUP = "projectiles";
        public static string PROJECTILE_IMAGE = "Assets/Images/Arcane_Effect_1.png";
         public static List<string> PROJECTILE_IMAGES
            = new List<string>() {
                "Assets/Images/Arcane_Effect_1.png",
                "Assets/Images/Arcane_Effect_2.png",
                "Assets/Images/Arcane_Effect_3.png",
                "Assets/Images/Arcane_Effect_4.png",
                "Assets/Images/Arcane_Effect_5.png",
                "Assets/Images/Arcane_Effect_6.png",
                "Assets/Images/Arcane_Effect_7.png"
            };

        // PLAYER
        public static string PLAYER_GROUP = "players";
        public static List<string> PLAYER_IMAGES
            = new List<string>() {
                "Assets/Images/100.png",
            };

        public static int PLAYER_WIDTH = 55;
        public static int PLAYER_HEIGHT = 48;
        public static int PLAYER_RATE = 6;
        public static int PLAYER_VELOCITY = 7;
        public static int PLAYER_HEALTH = 1000;

        // ENEMY
        public static string ENEMY_GROUP = "enemys";
        public static List<string> ENEMY_IMAGES
            = new List<string>() {
                "Assets/Images/goblingood.png"
            };

        public static int ENEMY_WIDTH = 50;
        public static int ENEMY_HEIGHT = 44;
        public static int ENEMY_RATE = 6;
        public static int ENEMY_VELOCITY = 1;
        public static int ENEMY_DAMAGE = 2;
        public static int ENEMY_HEALTH = 100;
        public static int ENEMY_COUNT = 10;

        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string PREP_TO_LAUNCH = "PREPARING TO LAUNCH";
        public static string WAS_GOOD_GAME = "GAME OVER";

    }
}