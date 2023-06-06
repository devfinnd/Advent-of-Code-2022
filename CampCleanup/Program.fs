open System
open System.IO

type Assignment(elf1, elf2) =
    member this.Elf1Sections = Assignment.parseSections elf1
    member this.Elf2Sections = Assignment.parseSections elf2

    static member areSectionsSupersets (ass: Assignment) =
        Set.isSuperset ass.Elf1Sections ass.Elf2Sections || Set.isSubset ass.Elf1Sections ass.Elf2Sections

    static member areSectionsIntersecting (ass: Assignment) =
        Set.intersect ass.Elf1Sections ass.Elf2Sections |> Seq.length > 0

    static member parse(input: string) =
        let elves = input.Split(",")
        Assignment(elves[0], elves[1])

    static member parseSections (elf: string) =
        let sections = elf.Split("-")
        let startSection = Int32.Parse sections[0]
        let endSection = Int32.Parse sections[1]
        Set.ofList [startSection .. endSection]

let ass = File.ReadAllLines "input.txt"
          |> Array.map (Assignment.parse >> Assignment.areSectionsIntersecting)
          |> Array.where id
Console.WriteLine ass.Length
