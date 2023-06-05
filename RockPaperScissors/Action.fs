namespace RockPaperScissors.Actions

open RockPaperScissors.Outcome

type Action =
    | Rock
    | Paper
    | Scissor

module Action =
    let decide opponent player: Outcome  =
        match opponent with
            | Rock when player = Scissor -> Loose
            | Paper when player = Rock -> Loose
            | Scissor when player = Paper -> Loose
            | _ when opponent = player -> Draw
            | _ -> Win

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
