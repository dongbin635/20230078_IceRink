namespace IceRinkGame

open System

module Renderer =
    let draw (x: int) (y: int) (str: string) =
        Console.SetCursorPosition(x, y)
        printf "%s" str

    let display (map: Tile[,]) (state: Obj) =
        // Console.Clear()  
        Console.SetCursorPosition(0, 0)
        printfn "=========================================================================="
        printfn " [STAGE %d]  |  [Placing Mode] %s  |  [Remaining P] x%d  |  [Keys] %d / 3 "
            state.CurStg
            (if state.PlcMod then "ON " else "OFF")
            state.CurPlc
            state.CurKey
        printfn "=========================================================================="

        for y in 0 .. map.GetLength(0) - 1 do
            for x in 0 .. map.GetLength(1) - 1 do
                match map.[y, x] with
                | Wall -> draw x (y + 3) "#"
                | Floor -> draw x (y + 3) " "
                | Exit -> draw x (y + 3) "O"
                | Key -> draw x (y + 3) "K" 
                | Bomb -> draw x (y + 3) "X" 
                | Weak n -> draw x (y + 3) (string n) 
                | _ -> draw x (y + 3) "P"
        printfn ""

    let disPlayer (pos: Position) =
        draw pos.X (pos.Y + 3) "@"

    let clearPlayer (pos: Position) =
        draw pos.X (pos.Y + 3) " "