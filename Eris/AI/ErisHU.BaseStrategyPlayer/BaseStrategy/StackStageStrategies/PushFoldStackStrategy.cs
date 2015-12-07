namespace ErisHU.BaseStrategyPlayer.BaseStrategy.StackStageStrategies
{
    using System.Linq;
    using ErisHU.BaseStrategyPlayer.HandEvaluate;
    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public static class PushFoldStackStrategy
    {
        private const int MaxCardTypeValue = 14;
        private const int InitialStack = 990;

        private static readonly double[,] PushFoldMatrix =
          {    // A   K    Q     J    T    9     8    7     6    5     4     3     2
                { 99, 99,  99,   99,  99,  99,   99,  99,   99,  99,   99,   99,   99 },   // A
                { 99, 99,  99,   99,  99,  99,   99,  99,   99,  99,   99,   99,   99 },   // K
                { 99, 99,  99,   99,  99,  99,   99,  99,   99,  99,   99,   99,   99 },   // Q
                { 99, 99,  99,   99,  99,  99,   99,  99,   99,  99,   99,   10.6, 8.5 },  // J
                { 99, 99,  99,   99,  99,  99,   99,  99,   99,  11.9, 10.5, 7.7,  6.5 },  // T
                { 99, 99,  99,   99,  99,  99,   99,  99,   99,  99,   6.9,  4.9,  3.7 },  // 9
                { 99, 99,  99,   99,  99,  99,   99,  99,   99,  99,   10.1, 2.7,  2.5 },  // 8
                { 99, 99,  10.3, 8.5, 9,   10.8, 99,  99,   99,  99,   99,   2.5,  2.1 },  // 7
                { 99, 99,  9.6,  6.5, 5.7, 5.2,  7,   10.7, 99,  99,   99,   4.8,  2 },    // 6
                { 99, 99,  8.9,  6,   4.1, 3.5,  3,   2.6,  2.4, 99,   99,   6.3,  2 },    // 5
                { 99, 99,  7.9,  5.4, 3.8, 2.7,  2.3, 2.1,  2,   2.1,  99,   5.7,  1.8 },  // 4
                { 99, 99,  7.5,  5,   3.4, 2.5,  1.9, 1.8,  1.7, 1.8,  1.6,  99,   1.7 },  // 3
                { 99, 11.6,7.0,  4.6, 2.9, 2.2,  1.8, 1.6,  1.5, 1.5,  1.4,  1.4,  99 },   // 2
            };

        private static readonly double[,] CallFoldMatrix =
          {    // A   K     Q     J    T    9     8     7     6    5    4    3     2
                { 99, 99,   99,   99,  99,  99,   99,   99,   99,  99,  99,  99,   99 },   // A
                { 99, 99,   99,   99,  99,  99,   99,   99,   99,  99,  99,  11.4, 10.7 }, // K
                { 99, 99,   99,   99,  99,  99,   99,   10.5, 9.9, 8.9, 8.4, 7.8,  7.2 },  // Q
                { 99, 99,   99,   99,  99,  99,   10.6, 8.8,  7,   6.9, 6.1, 5.8,  5.6 },  // J
                { 99, 99,   99,   99,  99,  11.5, 9.3,  7.4,  6.3, 5.2, 5.2, 4.8,  4.5 },  // T
                { 99, 99,   11.7, 9.5, 8.4, 99,   8.2,  7,    5.8, 5,   4.3, 4.1,  3.9 },  // 9
                { 99, 99,   9.7,  7.6, 6.6, 6,    99,   6.5,  5.6, 4.8, 4.1, 3.6,  3.5 },  // 8
                { 99, 99,   8,    6.4, 5.5, 5,    4.7,  99,   5.4, 4.8, 4.1, 3.6,  3.3 },  // 7
                { 99, 11,   7.3,  5.4, 4.6, 4.2,  4.1,  4,    99,  4.9, 4.3, 3.8,  3.3 },  // 6
                { 99, 10.2, 6.8,  5.1, 4,   3.7,  3.6,  3.6,  3.7, 99,  4.6, 4,    3.6 },  // 5
                { 99, 9.1,  6.2,  4.7, 3.8, 3.3,  3.2,  3.2,  3.3, 3.5, 99,  3.8,  3.4 },  // 4
                { 99, 8.7,  5.9,  4.5, 3.6, 3.1,  2.9,  2.9,  2.9, 3.1, 3,   99,   3.3 },  // 3
                { 99, 8.1,  5.6,  4.2, 3.5, 3,    2.8,  2.6,  2.7, 2.8, 2.7, 2.6,  99 },   // 2
            };

        private static readonly HandStrengthType[] CheckFoldHands =
            {
                HandStrengthType.HighCard,
                HandStrengthType.OnePairOnDryBoardWithoutMyCards,
                HandStrengthType.OnePairOnNotVeryWetBoardWithoutMyCards,
                HandStrengthType.OnePairOnWetBoardWithoutMyCards,
                HandStrengthType.OnePairOnDryBoardWithSamllImprovedKicker,
                HandStrengthType.OnePairOnDryBoardWithBigImprovedKicker,
                HandStrengthType.OnePairOnNotVeryWetBoardWithSamllImprovedKicker,
                HandStrengthType.OnePairOnNotVeryWetBoardWithBigImprovedKicker,
                HandStrengthType.OnePairOnWetBoardWithSamllImprovedKicker,
                HandStrengthType.OnePairOnWetBoardWithBigImprovedKicker,
                HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker,
                HandStrengthType.SmallOnePairOnDryBoardWithMiddleKicker,
                HandStrengthType.SmallOnePairOnDryBoardWithTopKicker,
                HandStrengthType.SmallOnePairOnNotVeryWetBoardWithSmallKicker,
                HandStrengthType.SmallOnePairOnNotVeryWetBoardWithMiddleKicker,
                HandStrengthType.SmallOnePairOnNotVeryWetBoardWithTopKicker,
                HandStrengthType.SmallOnePairOnWetBoardWithSmallKicker,
                HandStrengthType.SmallOnePairOnWetBoardWithMiddleKicker,
                HandStrengthType.SmallOnePairOnWetBoardWithTopKicker,
                HandStrengthType.TwoPairsWithoutMyCards,
            };

        public static PlayerAction GetPreflopAction(GetActionContext context)
        {
            double value;
            var absDiffrent = System.Math.Abs(context.OpponentStack - context.MyMoney);
            var maxlossMoneyBB = (((InitialStack * 2) - absDiffrent) / 2) / (context.SmallBlind * 2);

            if (context.PreviousRoundActions.Count == 2)
            {
                value = GetCurrentHandPushStack(context.FirstCard, context.SecondCard, PushFoldMatrix);
            }
            else
            {
                value = GetCurrentHandPushStack(context.FirstCard, context.SecondCard, CallFoldMatrix); // TODO: test play with push fold matrix
            }
            
            if (value >= maxlossMoneyBB)
            {
                if (maxlossMoneyBB < 0)
                {
                    // TODO: why?
                }

                return PlayerAction.Raise(context.MyMoney);
            }
            else
            {
                return PlayerAction.Fold();
            }
        }

        public static PlayerAction GetFlopAction(GetActionContext context)
        {
            if (context.CurrentPot / 2 > context.MyMoney)
            {
                return PlayerAction.Raise(context.MyMoney);
            }

            var handStrength = HandEvaluator.Evaluate(context.FirstCard, context.SecondCard, context.CommunityCards);

            if (CheckFoldHands.Any(h => h == handStrength))
            {
                return PlayerAction.Fold();
            }

            return PlayerAction.Raise(context.OpponentStack);
        }

        public static PlayerAction GetTurnAction(GetActionContext context)
        {
            if (context.CurrentPot / 2 > context.MyMoney)
            {
                return PlayerAction.Raise(context.MyMoney);
            }

            var handStrength = HandEvaluator.Evaluate(context.FirstCard, context.SecondCard, context.CommunityCards);

            if (CheckFoldHands.Any(h => h == handStrength))
            {
                return PlayerAction.Fold();
            }

            return PlayerAction.Raise(context.OpponentStack);
        }

        public static PlayerAction GetRiverAction(GetActionContext context)
        {
            if (context.CurrentPot / 2 > context.MyMoney)
            {
                return PlayerAction.Raise(context.MyMoney);
            }

            var handStrength = HandEvaluator.Evaluate(context.FirstCard, context.SecondCard, context.CommunityCards);

            if (CheckFoldHands.Any(h => h == handStrength))
            {
                return PlayerAction.Fold();
            }

            return PlayerAction.Raise(context.OpponentStack);
        }

        private static double GetCurrentHandPushStack(Card firstCard, Card secondCard, double[,] matrix)
        {
            var value = firstCard.Suit == secondCard.Suit
                          ? (firstCard.Type > secondCard.Type
                                 ? matrix[MaxCardTypeValue - (int)firstCard.Type, MaxCardTypeValue - (int)secondCard.Type]
                                 : matrix[MaxCardTypeValue - (int)secondCard.Type, MaxCardTypeValue - (int)firstCard.Type])
                          : (firstCard.Type > secondCard.Type
                                 ? matrix[MaxCardTypeValue - (int)secondCard.Type, MaxCardTypeValue - (int)firstCard.Type]
                                 : matrix[MaxCardTypeValue - (int)firstCard.Type, MaxCardTypeValue - (int)secondCard.Type]);

            return value;
        }
    }
}
