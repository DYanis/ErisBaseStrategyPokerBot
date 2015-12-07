namespace ErisHU.BaseStrategyPlayer
{
    using System;
    using System.Collections.Generic;

    using BaseStrategy;
    using TexasHoldem.Logic.Players;

    public class PushFoldPlayer : BasePlayer, IPlayer
    {
        private readonly string name = "PushFoldPlayer" + Guid.NewGuid();

        private GameStackStage currentGameStackStage;

        private int startGameMoney;

        private List<IReadOnlyCollection<PlayerActionAndName>> roundsActions = new List<IReadOnlyCollection<PlayerActionAndName>>();

        public override string Name
        {
            get
            {
                return this.name;
            }
        }

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            int opponentMoney = (this.startGameMoney * 2) - context.MyMoneyInTheRound - context.MoneyLeft;// ?

            var getActionContext = new GetActionContext(
                context.PreviousRoundActions,
                this.currentGameStackStage,
                this.roundsActions,
                context.RoundType,
                this.FirstCard,
                this.SecondCard,
                this.CommunityCards,
                context.SmallBlind,
                context.MoneyLeft,
                opponentMoney,
                context.CurrentPot,
                context.CanCheck,
                this.Name);

            var action = BaseStrategy.GetPlayerAction(getActionContext);

            if (action.Type == PlayerActionType.Fold && context.CanCheck)
            {
                return PlayerAction.CheckOrCall();
            }

            return action;
        }

        public override void StartRound(StartRoundContext context)
        {
            base.StartRound(context);
        }

        public override void StartHand(StartHandContext context)
        {
            base.StartHand(context);
            int opponentMoney = (this.startGameMoney * 2) - context.MoneyLeft;
            int smallestMoney = Math.Min(context.MoneyLeft, opponentMoney);
            this.currentGameStackStage = this.CalculateCurrentGameStackStage(context.SmallBlind, smallestMoney);
            this.roundsActions.Clear();
        }

        public override void StartGame(StartGameContext context)
        {
            base.StartGame(context);
            this.startGameMoney = context.StartMoney;
        }

        public override void EndRound(EndRoundContext context)
        {
            this.roundsActions.Add(context.RoundActions);
            base.EndRound(context);
        }

        public override void EndHand(EndHandContext context)
        {
            base.EndHand(context);
        }

        public override void EndGame(EndGameContext context)
        {
            base.EndGame(context);
        }

        private GameStackStage CalculateCurrentGameStackStage(int smallBlind, int moneyLeft)
        {
            int stackBB = moneyLeft / (smallBlind * 2);

            if (stackBB >= 0 && stackBB <= (int)GameStackStage.PushFoldStack)
            {
                return GameStackStage.PushFoldStack;
            }

            if (stackBB > (int)GameStackStage.PushFoldStack && stackBB <= (int)GameStackStage.ShortStack)
            {
                return GameStackStage.ShortStack;
            }

            if (stackBB > (int)GameStackStage.ShortStack && stackBB <= (int)GameStackStage.MiddleStack)
            {
                return GameStackStage.MiddleStack;
            }

            if (stackBB > (int)GameStackStage.MiddleStack && stackBB <= (int)GameStackStage.DeepStack)
            {
                return GameStackStage.DeepStack;
            }

            throw new ArgumentException("GameStackStage Error !!");
        }
    }
}
