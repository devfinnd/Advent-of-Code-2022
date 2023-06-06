open System
open System.IO

type Rucksack(compartmentInput1: string, compartmentInput2: string) =
    member this.Compartment1 = compartmentInput1 |> Array.ofSeq

    member this.Compartment2 = compartmentInput2 |> Array.ofSeq

    static member getDuplicates(rucksack: Rucksack) =
        let set1 = Set.ofArray rucksack.Compartment1
        let set2 = Set.ofArray rucksack.Compartment2
        let intersection = Set.intersect set1 set2

        if intersection.Count <> 1 then
            let dups = String.Join(",", intersection)
            failwith $"too few or too many duplicates {dups}"

        intersection

    static member parse(input: string) : Rucksack =
        let half = input.Length / 2
        let compartment1 = input.Substring(0, half)
        let compartment2 = input.Substring(half)

        if compartment1.Length > compartment2.Length then
            failwith "1 too large"

        if compartment1.Length < compartment2.Length then
            failwith "1 too small"

        Rucksack(compartment1, compartment2)

let offsetFrom (c: char) =
    let small = ['a' .. 'z']
    let large = ['A' .. 'Z']
    match c with
    | _ when List.contains c small -> int 'a' - 1
    | _ when List.contains c large -> int 'A' - 27
    | _ -> failwith "unmapped"

let charToAlphaInteger c =
    int c - offsetFrom c

Console.WriteLine (charToAlphaInteger 'a')
Console.WriteLine (charToAlphaInteger 'A')


let sum =
    File.ReadAllLines "input.txt"
    |> Array.map (
        Rucksack.parse
        >> Rucksack.getDuplicates
        >> Seq.head
        >> charToAlphaInteger
    ) |> Array.sum

Console.WriteLine sum
