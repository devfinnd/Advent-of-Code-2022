open System
open System.IO
open System.Linq

type Action =
    | Rock
    | Paper
    | Scissors

type Target =
    | Win
    | Draw
    | Loose

let getWinningMove move =
    match move with
    | Rock -> Paper
    | Paper -> Scissors
    | Scissors -> Rock

let getLoosingMove move =
    match move with
    | Rock -> Scissors
    | Paper -> Rock
    | Scissors -> Paper


let getActionScore action =
    match action with
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

let getRoundScore outcome =
    match outcome with
    | Win -> 6
    | Draw -> 3
    | Loose -> 0

let getScoreForStratFromString (str: string) =
    let values = str.Split(" ", StringSplitOptions.RemoveEmptyEntries)

    if (values.Length <> 2) then
        failwith "invalid number of values"

    let opponentAction =
        match values[0] with
        | "A" -> Rock
        | "B" -> Paper
        | "C" -> Scissors
        | _ -> failwith "unmapped action"

    let target =
        match values[1] with
        | "X" -> Loose
        | "Y" -> Draw
        | "Z" -> Win
        | _ -> failwith "unmapped target"

    let myAction =
        match target with
        | Win -> getWinningMove opponentAction
        | Draw -> opponentAction
        | Loose -> getLoosingMove opponentAction

    (getActionScore myAction) + (getRoundScore target)


let totalScore =
    File.ReadLines "input.txt"
    |> Enumerable.ToArray
    |> Array.map getScoreForStratFromString
    |> Array.sum

Console.WriteLine totalScore
