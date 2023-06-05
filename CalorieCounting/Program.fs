open System
open System.IO
open CalorieCounting

let text = File.ReadAllText "input.txt"

let elvesOrderedByCalories =
    text.Split(Environment.NewLine + Environment.NewLine)
    |> Array.map Elf.fromString
    |> Array.sortByDescending (fun elf -> elf.Calories)

let maximumCalorieELf = elvesOrderedByCalories[0]

Console.WriteLine $"The maximum calorie count is from elf {maximumCalorieELf.Index} with {maximumCalorieELf.Calories}"

let topThreeElves = elvesOrderedByCalories[0..2]

let getIndices (elfSlice: Elf.Elf array) =
    String.Join(", ", elfSlice |> Array.map (fun elf -> elf.Index))

let totalCalories (elfSlice: Elf.Elf array) =
    elfSlice |> Array.sumBy (fun elf -> elf.Calories)

Console.WriteLine $"The top three elves are {getIndices topThreeElves} with {totalCalories topThreeElves} calories in total"
