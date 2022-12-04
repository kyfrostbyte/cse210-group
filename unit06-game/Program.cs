using System;
using Raylib_cs;

namespace unit06_game
{
  class Program
  {
    static void Main(string[] args)
    {
        Raylib.InitWindow(1200, 800, "Test") ;
        Raylib_cs.Texture2D background = Raylib.LoadTexture("Assets/Images/test2.png");
        Raylib_cs.Texture2D player = Raylib.LoadTexture("Assets/Images/player_image.png");  
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawTexture(background, 0, -100, Color.WHITE);
            Raylib.DrawTexture(player, 1100, 0, Color.WHITE);
            Raylib.EndDrawing();

            
        }
        Raylib.CloseWindow();
    }
  }
}
