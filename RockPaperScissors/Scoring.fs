namespace RockPaperScissors.Scoring

open RockPaperScissors.Actions
open RockPaperScissors.Strategy
open RockPaperScissors.Outcome
module Score =
    let asInteger score =
        match score with
        | Win -> 6
        | Draw -> 3
        | Loose -> 0

type Score(outcome: Outcome, playerAction: Action) =
    member this.Value = (Score.asInteger outcome) + (Action.asInteger playerAction)

    static member judgeFromStrategy(strat: StrategyCombination) =
        let outcome = Action.decide strat.OpponentsChoice strat.PlayerChoice
        Score(outcome, strat.PlayerChoice)
