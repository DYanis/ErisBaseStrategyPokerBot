namespace TexasHoldem.AI.ErisHU
{
    using System;
    using System.Collections.Generic;

    using ErisHUBaseStrategy;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Players;
    using ErisHUBaseStrategy.StackStageStrategies;

    public class BaseStrategyPlayer : BasePlayer, IPlayer
    {
        private readonly string name = "TilT_ZevS" + Guid.NewGuid();

        private GameStackStage currentGameStackStage;

        private int startGameMoney;

        private int bigBlind;

        private int lastMyPushMoney;

        private GameRoundType currentRoundType;

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
            int opponentMoney = (this.startGameMoney * 2) - context.MyMoneyInTheRound - context.MoneyLeft;

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

            PlayerAction action = null;

            if (action == null)
            {
                action = BaseStrategy.GetPlayerAction(getActionContext);
            }

            if (action.Type == PlayerActionType.Raise && action.Money == context.MoneyLeft)
            {
                this.lastMyPushMoney = context.MoneyLeft - context.MyMoneyInTheRound;
            }

            return action;
        }

        public override void StartRound(StartRoundContext context)
        {
            base.StartRound(context);
            this.currentRoundType = context.RoundType;
        }

        public override void StartHand(StartHandContext context)
        {
            base.StartHand(context);
            this.bigBlind = context.SmallBlind * 2;
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
            if (this.currentRoundType == GameRoundType.Flop && this.currentGameStackStage == GameStackStage.DeepStack)
            {
                DeepStackStrategy.FlopActions.AddRange(context.RoundActions);
            }

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
