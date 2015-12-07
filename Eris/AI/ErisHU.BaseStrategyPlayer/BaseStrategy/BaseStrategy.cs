namespace ErisHU.BaseStrategyPlayer.BaseStrategy
{
    using StackStageStrategies;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Players;

    public static class BaseStrategy
    {
        public static PlayerAction GetPlayerAction(GetActionContext context)
        {
            PlayerAction action = PlayerAction.CheckOrCall();

            switch (context.CurrentGameStackStage)
            {
                case GameStackStage.PushFoldStack:
                    switch (context.RoundType)
                    {
                        case GameRoundType.PreFlop: action = PushFoldStackStrategy.GetPreflopAction(context); break;
                        case GameRoundType.Flop: action = PushFoldStackStrategy.GetFlopAction(context); break;
                        case GameRoundType.Turn: action = PushFoldStackStrategy.GetTurnAction(context); break;
                        case GameRoundType.River: action = PushFoldStackStrategy.GetRiverAction(context); break;
                        default: break;
                    }

                    break;
                case GameStackStage.ShortStack:
                    switch (context.RoundType)
                    {
                        case GameRoundType.PreFlop: action = ShortStackStrategy.GetPreflopAction(context); break;
                        case GameRoundType.Flop: action = ShortStackStrategy.GetFlopAction(context); break;
                        case GameRoundType.Turn: action = ShortStackStrategy.GetTurnAction(context); break;
                        case GameRoundType.River: action = ShortStackStrategy.GetRiverAction(context); break;
                        default: break;
                    }

                    break;
                case GameStackStage.MiddleStack:
                    switch (context.RoundType)
                    {
                        case GameRoundType.PreFlop: action = MiddleStackStrategy.GetPreflopAction(context); break;
                        case GameRoundType.Flop: action = MiddleStackStrategy.GetFlopAction(context); break;
                        case GameRoundType.Turn: action = MiddleStackStrategy.GetTurnAction(context); break;
                        case GameRoundType.River: action = MiddleStackStrategy.GetRiverAction(context); break;
                        default: break;
                    }

                    break;
                case GameStackStage.DeepStack:
                    switch (context.RoundType)
                    {
                        case GameRoundType.PreFlop: action = DeepStackStrategy.GetPreflopAction(context); break;
                        case GameRoundType.Flop: action = DeepStackStrategy.GetFlopAction(context); break;
                        case GameRoundType.Turn: action = DeepStackStrategy.GetTurnAction(context); break;
                        case GameRoundType.River: action = DeepStackStrategy.GetRiverAction(context); break;
                        default: break;
                    }

                    break;
                default:
                    break;
            }

            if (action.Type == PlayerActionType.Raise && action.Money < 2)
            {
                return PlayerAction.CheckOrCall();
            }

            if (action.Type == PlayerActionType.Fold && context.CanCheck)
            {
                return PlayerAction.CheckOrCall();
            }

            if (context.MyMoney <= 0)
            {
                return PlayerAction.CheckOrCall();
            }

            return action;

            throw new System.Exception("GameStackStage Error !!");
        }
    }
}
