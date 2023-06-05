namespace CalorieCounting

open System

module Elf =
    type ElfCounter() =
        static let mutable counter = 0
        static member Counter
            with get () = counter
            and set v = counter <- v

    type Elf = { Index: Int32; Calories: Int32 }

    let fromString (input: string) : Elf =
        ElfCounter.Counter <- ElfCounter.Counter + 1
        let calories =
            input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            |> Array.map Int32.Parse
            |> Array.sum in

           { Index = ElfCounter.Counter; Calories = calories }
