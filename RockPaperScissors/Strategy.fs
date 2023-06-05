namespace RockPaperScissors.Strategy

open RockPaperScissors.Actions

type StrategyCombination(opponentsChoice: Action, playerChoice: Action) =
    member this.OpponentsChoice = opponentsChoice
    member this.PlayerChoice = playerChoice
    static member fromString(input: string) : StrategyCombination =
        let values = input.Split " "

        if (values.Length <> 2) then
            failwith "invalid"

        let opponent = Action.parseOpponent values[0]
        let player = Action.parsePlayer values[1]
        StrategyCombination(opponent, player)
