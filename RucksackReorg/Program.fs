open System
open System.IO

type Group(rucksack1: string, rucksack2: string, rucksack3: string) =
    member this.Rucksack1 = rucksack1 |> Set.ofSeq
    member this.Rucksack2 = rucksack2 |> Set.ofSeq
    member this.Rucksack3 = rucksack3 |> Set.ofSeq

    static member getBadge (g: Group) = Set.intersectMany [g.Rucksack1; g.Rucksack2; g.Rucksack3] |> Seq.head

    static member parse(input: array<string>) : Group =
        Group(input[0], input[1], input[2])

let getGroups input =
    input |> Array.chunkBySize 3 |> Array.map Group.parse

let offsetFrom (c: char) =
    let small = ['a' .. 'z']
    let large = ['A' .. 'Z']
    match c with
    | _ when List.contains c small -> int 'a' - 1
    | _ when List.contains c large -> int 'A' - 27
    | _ -> failwith "unmapped"

let charToAlphaInteger c =
    int c - offsetFrom c


let sum =
    File.ReadAllLines "input.txt"
    |> getGroups
    |> Array.map (Group.getBadge >> charToAlphaInteger)
    |> Array.sum

Console.WriteLine sum
