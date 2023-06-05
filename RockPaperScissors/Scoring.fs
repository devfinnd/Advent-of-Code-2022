namespace RockPaperScissors.Scoring

open RockPaperScissors.Actions
open RockPaperScissors.Strategy

type Outcome =
    | Win
    | Draw
    | Loose

module Score =
    let asInteger score =
        match score with
        | Win -> 6
        | Draw -> 3
        | Loose -> 0

type Score(outcome: Outcome, playerAction: Action) =
    member this.Value =
        (Score.asInteger outcome) + (Action.asInteger playerAction)

    static member judge opponentChoice playerChoice =
        let outcome =
            match opponentChoice with
            | Rock when playerChoice = Scissor -> Win
            | Paper when playerChoice = Rock -> Win
            | Scissor when playerChoice = Paper -> Win
            | _ when opponentChoice = playerChoice -> Draw
            | _ -> Loose
        Score(outcome, playerChoice)

    static member Zero = 0
    static member judgeFromStrategy (strat: StrategyCombination) =
        Score.judge strat.OpponentsChoice strat.PlayerChoice

    static member (+) (x: Score, y: Score)  =
        x.Value + y.Value
