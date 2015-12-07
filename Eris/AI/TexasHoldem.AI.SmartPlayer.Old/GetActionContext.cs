namespace ErisHU.BaseStrategy
{
    using System.Collections.Generic;

    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public class GetActionContext
    {
        public GameStackStage CurrentGameStackStage { get; private set; }

        public GameRoundType RoundType { get; private set; }

        public int SmallBlind { get; private set; }

        public int MyMoney { get; private set; }

        public int OpponentStack { get; private set; }

        public int CurrentPot { get; private set; }

        public string Name { get; private set; }

        public double MyStackBB
        {
            get
            {
                return this.MyMoney / (this.SmallBlind * 2);
            }
        }

        public Card FirstCard { get; private set; }

        public Card SecondCard { get; private set; }

        public bool CanCheck { get; private set; }

        public IReadOnlyCollection<Card> CommunityCards { get; private set; }

        public IReadOnlyCollection<PlayerActionAndName> PreviousRoundActions { get; private set; }

        public List<IReadOnlyCollection<PlayerActionAndName>> RoundsActions { get; private set; }

        public GetActionContext(
            IReadOnlyCollection<PlayerActionAndName> previousRoundActions,
            GameStackStage currentGameStackStage,
            List<IReadOnlyCollection<PlayerActionAndName>> roundsActions,
            GameRoundType roundType,
            Card firstCard,
            Card secondCard,
            IReadOnlyCollection<Card> communityCards,
            int smallBlind,
            int myMoney,
            int opponentStack,
            int currentPot,
            bool canCheck,
            string name)
        {
            this.PreviousRoundActions = previousRoundActions;
            this.CurrentGameStackStage = currentGameStackStage;
            this.RoundsActions = roundsActions;
            this.RoundType = roundType;
            this.FirstCard = firstCard;
            this.SecondCard = secondCard;
            this.CommunityCards = communityCards;
            this.SmallBlind = smallBlind;
            this.MyMoney = myMoney;
            this.OpponentStack = opponentStack;
            this.CurrentPot = currentPot;
            this.CanCheck = canCheck;
            this.Name = name;
        }
    }
}
