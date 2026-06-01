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
dotnet run
```

### Build

```bash
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
You can move @ by W,A,S,D keys. After collecting 3 keys, if you hit O, you can move on to the next stage.
For details on each object, please refer to the PDF.

When you clear a stage, a message appears asking if you want to play the next stage.
When you clear the 5th stage, a "Congratulation!" message appears, and you win.
If you hit a bomb, a message appears asking if you want to try again. If you try again, you will restart that stage. You can also restart the stage by pressing R.
The game ends when you press N after the next stage message or bomb message appears, or when you press Enter after the "Congratulation!" message appears. If you want to exit the game in the middle, press ESC.

### Caution

Breakable obstacle's number doesn't exceed 3. If there's number like 13, it's actually two distinct digit blocks (1 and 3) placed side by side, not a block with number thirteen.

## AI Usage

I received assistance from AI when implementing the interaction for when @ collides with integers, O, and X. 
However, the AI ​​did not understand the meaning of "hit" and implemented it so that the object interacts when a key is pressed in the direction of the object while @ is adjacent to it.
Since my original intention was for @ to interact when it is moving and collides with an object, I had to implement it as follows:
"When @ is in contact with 3 and the arrow key is held down in the direction of the number, the number decreases continuously, but I don't want that to happen. I want the number to decrease only when it collides while moving. How can I achieve this?"
It seems that when commanding the AI ​​to implement specific code, it fails to take care of detailed aspects such as the meaning of "hit." I had to fix the code using bool 'move'.