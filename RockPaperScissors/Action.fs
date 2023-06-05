namespace RockPaperScissors.Actions

type Action =
    | Rock
    | Paper
    | Scissor

module Action =
    let parseOpponent input : Action =
        match input with
        | "A" -> Rock
        | "B" -> Paper
        | "C" -> Scissor
        | _ -> failwith "invalid"

    let parsePlayer input : Action =
        match input with
        | "X" -> Rock
        | "Y" -> Paper
        | "Z" -> Scissor
        | _ -> failwith "invalid"

    let asInteger action =
        match action with
        | Rock -> 1
        | Paper -> 2
        | Scissor -> 3
