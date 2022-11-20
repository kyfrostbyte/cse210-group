# Cycle
Two Cycles compete in the ulitmate game of skill. As they cycles move, they leave a an untouchable trail in their wake. If the opposing cycle touches this in any way, they lose. Play smart, make quick decisions, and force the other cycle to run into your trail! Two powerups will spawn regularly. The White Power Up will cause your trail to instantly grow by 8 segments longer, while the Green Power Up resets the trail of you opponent!

---
## Getting Started
Make sure you have dotnet 6.0 or newer installed on your machine. Navigate to root folder in the terminal
and run these commands to start the game.
```
dotnet build
dotnet run 
```
You can also run the program from an IDE like Visual Studio Code. 
Start your IDE and open the project folder. Select "Run and Debug" on 
the Activity Bar. Next, select the project you'd like to run from the 
drop down list at the top of the Side Bar. Lastly, click the green 
arrow or "start debugging" button.

## Project Structure
The project files and folders are organized as follows:
```
root                          (project root folder)
+-- Game                      (source code folder)
+-- Program.cs                (program entry point)    
+-- README.md                 (general info)
+-- Unit05-cycle.csproj       (dotnet project file)
```

## Required Technologies
* dotnet 6.0
* raylib-cs 3.7.0.1

## Author
* Aaron Alexander (ale20011@byui.edu)
* Grant Watson (???)
* Bri (???)

TO DO:
1) Spawn 2 cycles --DONE: A.A.
2) Make it so color and spawn location of cycles can be passed into constructor --DONE: A.A.
3) Add keybinds for 2nd Cycle --DONE: A.A.
4) Make snakes spawn in the correct location --DONE: G.W.
5) Fix collision so snakes die if their head touchs the other snake --DONE: G.W.
6) Make snake leave a "trail" of some sorts --DONE: G.W.
7) Center "Game Over" message --DONE: A.A.
8) Add power ups --DONE: A.A.

