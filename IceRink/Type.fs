namespace IceRinkGame

type Direction = Up | Down | Left | Right

type Tile =
    | Floor
    | Wall  // #
    | Key   // K
    | Exit  // O
    | Bomb  // X
    | Weak of int
    | Place // P

type Position = { X: int; Y: int }

type Obj = {
    CurTile: Tile[,]
    CurPos: Position
    CurKey: int
    CurSta: int
    IsOver: bool
    CurPlc: int
    PlcMod: bool
    CurStg: int
}