open System
open System.IO
open System.Linq
open RockPaperScissors.Strategy
open RockPaperScissors.Scoring

let getScoreForStratFromString str =
    StrategyCombination.fromString str
    |> Score.judgeFromStrategy
    |> (fun x -> x.Value)

let totalScore =
    File.ReadLines "input.txt"
    |> Enumerable.ToArray
    |> Array.map getScoreForStratFromString
    |> Array.sum

Console.WriteLine totalScore
