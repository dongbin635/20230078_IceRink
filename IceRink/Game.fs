namespace IceRinkGame
open System.Threading

module GameLogic =
    let where k =
        match k with
        | Up -> (0, -1) 
        | Down -> (0, 1) 
        | Left -> (-1, 0) 
        | Right -> (1, 0)

    let block (s: Obj) x y =
        if x < 0 || x >= s.CurTile.GetLength(1) || y < 0 || y >= s.CurTile.GetLength(0) then true
        else 
            match s.CurTile.[y, x] with
            | Wall -> true
            | Exit -> true
            | Bomb -> true
            | Weak _ -> true
            | Place -> true
            | _ -> false

    let placing (s: Obj) (d: Direction) : Obj =
        if s.CurPlc = 0 then s
        else
            let (dx, dy) = where d
            let tarX = s.CurPos.X + dx
            let tarY = s.CurPos.Y + dy

            if tarX >= 0 && tarX < s.CurTile.GetLength(1) && tarY >= 0 && tarY < s.CurTile.GetLength(0) && s.CurTile.[tarY, tarX] = Floor then
                s.CurTile.[tarY, tarX] <- Place
                { s with CurPlc = s.CurPlc - 1 }
            else s

    let slide (s: Obj) (d: Direction) : Obj =
        let (dx, dy) = where d
        let mutable curPos = s.CurPos
        let mutable sliding = true
        let mutable over = s.IsOver
        let mutable keys = s.CurKey
        let mutable status = s.CurSta
        let mutable move = false

        while sliding do
            let nextX = curPos.X + dx
            let nextY = curPos.Y + dy

            if (block s nextX nextY) = false then
                move <- true
                Renderer.clearPlayer curPos
                curPos <- { X = nextX; Y = nextY }
                match s.CurTile.[curPos.Y, curPos.X] with
                | Key ->
                    keys <- keys + 1
                    s.CurTile.[curPos.Y, curPos.X] <- Floor
                | _ -> ()
                Renderer.disPlayer curPos
                Thread.Sleep(50)
            else
                if nextX >= 0 && nextX < s.CurTile.GetLength(1) && nextY >= 0 && nextY < s.CurTile.GetLength(0) then
                    match s.CurTile.[nextY, nextX] with
                    | Exit -> 
                        if keys >= 3 then
                            over <- true
                            status <- 1
                    | Bomb -> 
                        over <- true
                        status <- 2
                    | Weak n ->
                        if move then    
                            if n > 1 then s.CurTile.[nextY, nextX] <- Weak (n - 1)
                            else
                                s.CurTile.[nextY, nextX] <- Floor
                    | _ -> ()
                sliding <- false
        { s with CurPos = curPos; IsOver = over; CurKey = keys; CurSta = status }