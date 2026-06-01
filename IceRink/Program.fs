open System
open IceRinkGame

[<EntryPoint>]
let main _ =
    Console.CursorVisible <- false
    
    let mutable curst = 1
    let mutable run = true
    
    while run && curst <= 5 do
        Console.Clear()
        
        let mutable state = { 
            CurTile = MapData.getStage curst
            CurPos = MapData.start curst
            CurKey = 0
            CurSta = 0
            IsOver = false 
            CurPlc = MapData.place curst
            PlcMod = false
            CurStg = curst
        }

        Renderer.display state.CurTile state
        Renderer.disPlayer state.CurPos

        let mutable stgRun = true
        while stgRun && not state.IsOver do
            let key = Console.ReadKey(true).Key
            match key with
            | ConsoleKey.Spacebar ->
                state <- { state with PlcMod = not state.PlcMod }
                Renderer.display state.CurTile state
                Renderer.disPlayer state.CurPos

            | ConsoleKey.R ->
                state <- { 
                    CurTile = MapData.getStage curst
                    CurPos = MapData.start curst
                    CurKey = 0
                    CurSta = 0 
                    IsOver = false 
                    CurPlc = MapData.place curst
                    PlcMod = false                                                   
                    CurStg = curst
                }
                Renderer.display state.CurTile state
                Renderer.disPlayer state.CurPos
            
            | ConsoleKey.W | ConsoleKey.A | ConsoleKey.S | ConsoleKey.D ->
                match key with
                | ConsoleKey.W -> if state.PlcMod then state <- GameLogic.placing state Up else state <- GameLogic.slide state Up
                | ConsoleKey.A -> if state.PlcMod then state <- GameLogic.placing state Left else state <- GameLogic.slide state Left
                | ConsoleKey.S -> if state.PlcMod then state <- GameLogic.placing state Down else state <- GameLogic.slide state Down
                | _ -> if state.PlcMod then state <- GameLogic.placing state Right else state <- GameLogic.slide state Right
                Renderer.display state.CurTile state
                Renderer.disPlayer state.CurPos

            | ConsoleKey.Escape -> 
                stgRun <- false
                run <- false
            | _ -> ()

        if state.IsOver then
            if state.CurSta = 2 then
                Console.Clear()
                printfn "===================================="
                printfn "          You crushed Bomb!         "
                printfn "             GAME OVER              "
                printfn "===================================="
                
                let mutable askRun = true
                while askRun do
                    printf " Try again current stage? (y/n): "
                    let intent = Console.ReadKey(true).Key
                    printfn ""
                    if intent = ConsoleKey.Y then askRun <- false
                    elif intent = ConsoleKey.N then
                        askRun <- false
                        run <- false
                    else printfn " Please enter Y or N "

            elif state.CurSta = 1 then
                if curst < 5 then
                    Console.Clear()
                    printfn "===================================="
                    printfn "       STAGE %d CLEAR SUCCESS!       " curst
                    printfn "===================================="
                    
                    let mutable askNext = true
                    while askNext do
                        printf " Move to next stage? (y/n): "
                        let intent = Console.ReadKey(true).Key
                        printfn ""
                        if intent = ConsoleKey.Y then
                            askNext <- false
                            curst <- curst + 1
                        elif intent = ConsoleKey.N then
                            askNext <- false
                            run <- false
                        else printfn " Please enter Y or N "
                else
                    Console.Clear()
                    printfn "===================================="
                    printfn "         ALL STAGES CLEAR!!         "
                    printfn "          Congratulation!           "
                    printfn "===================================="
                    printfn " Please press Enter to exit program "
                    Console.ReadLine() |> ignore
                    run <- false
        else 
            run <- false

    Console.Clear()
    Console.CursorVisible <- true
    printfn " Game closed "
    0