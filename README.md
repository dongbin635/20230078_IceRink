# IceRink

Please ensure your terminal window is sufficiently resized (or maximized) before starting the game. If not, it could cause System.ArgumentOutOfRangeException.
Please do not move or extend/shrink terminal during the game. It could cause rendering artifacts.
---

## Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)  
  Verify with: `dotnet --version` (should show `10.x.x`)

### Run

```bash
cd 20230078_IceRink
dotnet run
```

### Build

```bash
cd 20230078_IceRink
dotnet build
```

## Play

### Outline

If you start the game, you will see a map like this for each stage.
```
#########
#@K3K  O#
#K   X###
#########
```
You can move @ by W,A,S,D keys. W goes up, A goes left, S goes down, and D goes 
right. After player presses move command, the character ‘@’ slides in 
that direction until it is blocked by a normal obstacle ‘#’,
placeable obstacle ‘P’, a breakable obstacle which is expressed with 
integer number, bomb ‘X’ or exit ‘O’.

There are three keys ‘K’ placed on the map. The player must 
collect all three keys by sliding over it. (Collecting key does not 
stop the character’s movement.) If not, player could not clear the 
stage even if the character ‘@’ hits exit ‘O’. The number of keys 
that player collected is displayed at the top.

When the ‘@’ hits exit ‘O’ after collecting all three keys, the 
stage ends. Then player can go to next stage.

If the ‘@’ hits a bomb ‘X’, the stage ends immediately with a 
game-over message. Then player can restart that stage.

Breakable obstacles are displayed with an integer number like 
‘3’. Each time the ‘@’ hits the obstacle, the number decreases by 1. 
When the ‘@’ is blocked by the number ‘1’, ‘@’ stops, and then the 
breakable obstacle disappears.

Player starts with 0 ~ 2 placeable obstacles ‘P’. (Its quantity
differs by stages.) By pressing Space command, the player can enter 
placing mode. During the placing mode, when player presses the W, A, 
S, or D command, player can place obstacle ‘P’ in the immediately adjacent location in that direction. If there is already another 
obstacle or object in there, obstacle is not placed, and no 
placeable obstacle is consumed. During the placing mode, ‘@’ does 
not move. The player can turn off the placing mode by pressing Space
command once more. The number of placeable obstacles is displayed on
the top. The state of placing mode is displayed at the top.

There are total of 5 stages. After clearing the last stage, 
player wins.

When you clear a stage, a message appears asking if you want to play the next stage.
When you clear the 5th stage, a "Congratulation!" message appears, and you win.
If you hit a bomb, a message appears asking if you want to try again. If you try again, you will restart that stage. You can also restart the stage by pressing R.
The game ends when you press N after the next stage message or bomb message appears, or when you press Enter after the "Congratulation!" message appears. If you want to exit the game in the middle, press ESC.

### Caution

Breakable obstacle's number doesn't exceed 3. If there's number like 13, it's actually two distinct digit blocks (1 and 3) placed side by side, not a block with number thirteen.

## Project Structure
```
20230078_IceRink/
├── IceRink.fsproj     # .NET F# project file
├── README.md
├── .gitignore
└── IceRink/
    ├── Type.fs        # type & data structure declaration
    ├── Map.fs         # map generation
    ├── Renderer.fs    # Screen rendering and output
    ├── Game.fs        # Game Loop and Core Logic
    └── Program.fs     # Entry Point
```

## AI Usage

I received assistance from GEMINI when implementing the interaction for when @ collides with integers, O, and X. 
I put the prompt "When the ‘@’ hits exit ‘O’ after collecting all three keys, the 
stage ends. If the ‘@’ hits a bomb ‘X’, the stage ends. Breakable obstacles are displayed with an integer number like ‘3’. Each time the ‘@’ hits the obstacle, the number decreases by 1. When the ‘@’ is blocked by the number ‘1’, ‘@’ stops, and then the breakable obstacle disappears." However, the AI ​​did not understand the meaning of "hit" and implemented it so that the object interacts when a key is pressed in the direction of the object while @ is adjacent to it.
Since my original intention was for @ to interact when it is moving and collides with an object, I had to implement it as follows:
"When @ is in contact with 3 and the arrow key is held down in the direction of the number, the number decreases continuously, but I don't want that to happen. I want the number to decrease only when it collides while moving. How can I achieve this?" Then I had to fix the code using a bool 'move'.
The main point is, it seems that when commanding the AI ​​to implement specific code, it fails to take care of detailed aspects such as the meaning of "hit."