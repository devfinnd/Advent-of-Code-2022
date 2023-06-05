open System
open System.IO
open System.Linq
open RockPaperScissors.Strategy
open RockPaperScissors.Scoring

let totalScore =
    File.ReadLines "input.txt"
    |> Enumerable.ToArray
    |> Array.map StrategyCombination.fromString
    |> Array.map Score.judgeFromStrategy
    |> Array.sum

Console.WriteLine totalScore
