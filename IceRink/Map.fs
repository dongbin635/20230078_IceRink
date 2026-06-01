namespace IceRinkGame

module MapData =
    let getStage (stgNum: int) =
        match stgNum with
        | 1 ->
            Array2D.init 4 9 (fun y x -> 
            if y = 0 || y = 3 || x = 0 || x = 8 || (y = 2 && (x = 6 || x = 7)) then Wall 
            elif y = 1 && x = 7 then Exit
            elif (y = 1 && x = 2) || (y = 1 && x = 4) || (y = 2 && x = 1) then Key
            elif y = 2 && x = 5 then Bomb
            elif y = 1 && x = 3 then Weak 3
            else Floor)
        | 2 ->
            Array2D.init 9 12 (fun y x -> 
            if x = 0 || x = 11 || y = 0 || ((y = 7 || y = 8) && x <> 10) || ((x = 2 || x = 5) && y = 1) || (x = 8 && y = 2) || (x = 9 && y = 4) then Wall 
            elif x = 10 && y = 8 then Exit
            elif (x = 3 && y = 3) || (x = 8 && y = 4) || (x = 4 && y = 1) then Key
            elif x = 1 && y = 6 then Bomb
            elif x = 1 && y = 5 then Weak 3
            elif x = 2 && (y = 6 || y = 3) then Weak 2
            else Floor)
        | 3 ->
            Array2D.init 8 13 (fun y x -> 
            if x = 0 || x = 12 || (((x >= 1 && x <= 3) || (x >= 9 && x <= 11)) && (y <> 1)) || y = 0 || y = 7 || (x = 4 && y = 5) || (x = 7 && y = 6) then Wall 
            elif x = 1 && y = 1 then Exit
            elif (x = 4 && y = 3) || (x = 5 && y = 6) || (x = 8 && y = 5) then Key
            elif x = 11 && y = 1 then Bomb
            elif (x = 6 && y = 4) || (x = 10 && y = 1) then Weak 1
            elif x = 2 && y = 1 then Weak 2
            else Floor)
        | 4 ->
           Array2D.init 10 13 (fun y x -> 
            if ((x = 0 || x = 1) && (y <> 5)) || x = 12 || y = 0 || y = 9 || ((x = 2) && (y = 1 || y = 2 || y = 6)) || ((y = 5) && (x = 6 || x = 9 || x = 11)) || (x = 5 && y = 4) || (x = 6 && y = 3) || (x = 10 && y = 8) then Wall 
            elif x = 0 && y = 5 then Exit
            elif (x = 11 && y = 1) || (x = 2 && y = 8) || (x = 11 && y = 8) then Key
            elif x = 3 && y = 4 then Bomb
            elif x = 8 && y = 8 then Weak 2
            else Floor)
        | _ ->
            Array2D.init 12 14 (fun y x -> 
            if y = 0 || x = 13 || ((y = 1 || y = 2) && x <> 10) || (y = 3 && (x <> 9 && x <> 10)) || ((x = 0 || x = 1) && y <> 5) || (x = 12 && y <> 7) || ((y = 10 || y = 11) && (x <> 10)) || ((x = 2 || x = 3 || x = 5) && y = 4) || (x = 4 && y = 6) || (x = 8 && y = 8) then Wall
            elif x = 10 && y = 11 then Exit
            elif (x = 4 && y = 4) || (x = 10 && y = 1) || (x = 12 && y = 7) then Key
            elif x = 0 && y = 5 then Bomb
            elif x = 11 && y = 5 then Weak 3
            elif (x = 10 && (y = 2 || y = 3 || y = 5)) || (x = 11 && y = 7) then Weak 1
            else Floor)

    let place (stgNum: int) =
        match stgNum with
        | 1 -> 1
        | 2 -> 0
        | 3 -> 1
        | 4 -> 2
        | _ -> 2

    let start (stgNum: int) =
        match stgNum with
        | 1 -> { X = 1; Y = 1 }
        | 2 -> { X = 1; Y = 1 }
        | 3 -> { X = 6; Y = 1 }
        | 4 -> { X = 6; Y = 1 }
        | _ -> { X = 2; Y = 9 }