namespace ErisHU.BaseStrategy
{
    using StackStageStrategies;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Players;

    public static class BaseStrategy
    {
        public static PlayerAction GetPlayerAction(GetActionContext contex)
        {
            switch (contex.CurrentGameStackStage)
            {
                case GameStackStage.PushFoldStack:
                    switch (contex.RoundType)
                    {
                        case GameRoundType.PreFlop: return PushFoldStackStrategy.GetPreflopAction(contex);
                        case GameRoundType.Flop: return PushFoldStackStrategy.GetFlopAction(contex);
                        case GameRoundType.Turn: return PushFoldStackStrategy.GetTurnAction(contex);
                        case GameRoundType.River: return PushFoldStackStrategy.GetRiverAction(contex);
                        default: break;
                    }

                    break;
                case GameStackStage.ShortStack:
                    switch (contex.RoundType)
                    {
                        case GameRoundType.PreFlop: return ShortStackStrategy.GetPreflopAction(contex);
                        case GameRoundType.Flop: return ShortStackStrategy.GetFlopAction(contex);
                        case GameRoundType.Turn: return ShortStackStrategy.GetTurnAction(contex);
                        case GameRoundType.River: return ShortStackStrategy.GetRiverAction(contex);
                        default: break;
                    }

                    break;
                case GameStackStage.MiddleStack:
                    switch (contex.RoundType)
                    {
                        case GameRoundType.PreFlop: return MiddleStackStrategy.GetPreflopAction(contex);
                        case GameRoundType.Flop: return MiddleStackStrategy.GetFlopAction(contex);
                        case GameRoundType.Turn: return MiddleStackStrategy.GetTurnAction(contex);
                        case GameRoundType.River: return MiddleStackStrategy.GetRiverAction(contex);
                        default: break;
                    }

                    break;
                case GameStackStage.DeepStack:
                    switch (contex.RoundType)
                    {
                        case GameRoundType.PreFlop: return DeepStackStrategy.GetPreflopAction(contex);
                        case GameRoundType.Flop: return DeepStackStrategy.GetFlopAction(contex);
                        case GameRoundType.Turn: return DeepStackStrategy.GetTurnAction(contex);
                        case GameRoundType.River: return DeepStackStrategy.GetRiverAction(contex);
                        default: break;
                    }

                    break;
                default:
                    break;
            }

            throw new System.Exception("GameStackStage Error !!");
        }
    }
}
