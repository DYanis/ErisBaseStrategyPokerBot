namespace ErisHU.BaseStrategy.StackStageStrategies
{
    using System.Linq;

    using HandEvaluate;
    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public static class ShortStackStrategy
    {
        private const int MaxCardTypeValue = 14;
        private static byte behaviourValue;

        /*
        SmallBlindMatrix
        fold = 0
        push = 8
        limpFold = 1
        limpCallMin = 2
        limpCallRaiseToThreeBB = 3
        limpPush = 4
        raiseFold = 5
        raiseCall3betMyRaiseDouble = 6
        raisePush = 7
        callMin = 9
        callRaiseToThreeBB = 10
        3BetFold = 11
        3BetPush = 12
        check = 13
        */
        private static readonly byte[,] SmallBlindMatrix =
        {  // A  K  Q  J  T  9  8  7  6  5  4  3  2
            { 7, 7, 7, 7, 7, 7, 6, 6, 6, 6, 6, 6, 6 }, // A
            { 7, 7, 7, 7, 7, 6, 6, 6, 5, 5, 5, 5, 5 }, // K
            { 7, 7, 7, 7, 7, 6, 6, 5, 5, 5, 5, 5, 5 }, // Q
            { 7, 6, 6, 7, 6, 6, 6, 5, 5, 5, 5, 5, 5 }, // J
            { 7, 6, 6, 6, 8, 6, 6, 5, 5, 5, 5, 5, 5 }, // T
            { 6, 6, 5, 5, 5, 8, 5, 5, 5, 5, 1, 0, 0 }, // 9
            { 6, 5, 5, 5, 5, 5, 8, 5, 5, 5, 1, 0, 0 }, // 8
            { 6, 5, 5, 5, 5, 5, 5, 8, 5, 5, 5, 0, 0 }, // 7
            { 5, 5, 5, 2, 2, 2, 2, 5, 8, 5, 5, 0, 0 }, // 6
            { 5, 5, 5, 0, 0, 0, 0, 0, 0, 8, 5, 1, 0 }, // 5
            { 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0 }, // 4
            { 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 }, // 3
            { 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 }, // 2
        };

        private static readonly byte[,] BigBlindMatrixWhenSmallBlindRaise =
        {  // A   K   Q   J   T   9   8   7   6  5  4   3   2
            { 12, 12, 12, 12, 12, 8,  8,  8,  8, 8, 10, 10, 10 }, // A
            { 12, 12, 12, 10, 10, 10, 10, 10, 9, 9, 9,  9,  9 }, // K
            { 12, 12, 12, 10, 10, 10, 10, 9,  9, 9, 9,  9,  9 }, // Q
            { 12, 10, 10, 8,  10, 10, 9,  9,  9, 9, 9,  0,  0 }, // J
            { 12, 10, 10, 10, 8,  10, 9,  9,  9, 9, 0,  0,  0 }, // T
            { 8,  10, 10, 9,  9,  8,  9,  9,  9, 9, 0,  0,  0 }, // 9
            { 8,  9,  9,  9,  9,  9,  8,  9,  9, 9, 9,  0,  0 }, // 8
            { 8,  9,  9,  9,  9,  9,  9,  8,  9, 9, 9,  0,  0 }, // 7
            { 10, 9,  9,  9,  9,  0,  0,  9,  8, 9, 9,  0,  0 }, // 6
            { 10, 9,  9,  0,  0,  0,  0,  0,  0, 8, 9,  0,  0 }, // 5
            { 10, 9,  0,  0,  0,  0,  0,  0,  0, 0, 8,  0,  0 }, // 4
            { 10, 9,  0,  0,  0,  0,  0,  0,  0, 0, 0,  8,  0 }, // 3
            { 10, 9,  0,  0,  0,  0,  0,  0,  0, 0, 0,  0,  8 }, // 2
        };

        private static readonly byte[,] BigBlindMatrixWhenSmallBlindLimp =
       {   // A  K   Q   J   T   9   8   7   6   5   4   3   2
            { 7, 7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7,  7 }, // A
            { 7, 7,  7,  6,  6,  6,  6,  13, 13, 13, 13, 13, 13 }, // K
            { 7, 7,  7,  6,  6,  6,  6,  13, 13, 13, 13, 13, 13 }, // Q
            { 7, 6,  6,  7,  6,  6,  6,  13, 13, 13, 13, 13, 13 }, // J
            { 7, 6,  6,  6,  7,  6,  13, 13, 13, 13, 13, 13, 13 }, // T
            { 7, 5,  5,  5,  5,  7,  6,  13, 13, 13, 13, 13, 13 }, // 9
            { 7, 13, 13, 13, 13, 13, 7,  13, 13, 13, 13, 13, 13 }, // 8
            { 7, 13, 13, 13, 13, 13, 13, 7,  13, 13, 13, 13, 13 }, // 7
            { 7, 13, 13, 13, 13, 13, 13, 13, 7,  13, 13, 13, 13 }, // 6
            { 7, 13, 13, 13, 13, 13, 13, 13, 13, 7,  13, 13, 13 }, // 5
            { 7, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13 }, // 4
            { 7, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13 }, // 3
            { 7, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13 }, // 2
        };

        public static PlayerAction GetPreflopAction(GetActionContext context)
        {
            PlayerAction action;

            // player on the small blind
            if (context.PreviousRoundActions.Count == 2)
            {
                behaviourValue = GetBehaviourValue(context.FirstCard, context.SecondCard, SmallBlindMatrix);

                action = RecognitionFirstAction(context);
                return action;
            }

            // player on the big blin
            if (context.PreviousRoundActions.Count == 3)
            {
                if (context.CanCheck)
                {
                    behaviourValue = GetBehaviourValue(context.FirstCard, context.SecondCard, BigBlindMatrixWhenSmallBlindLimp);

                    action = RecognitionFirstAction(context);
                    return action;
                }
                else
                {
                    behaviourValue = GetBehaviourValue(context.FirstCard, context.SecondCard, BigBlindMatrixWhenSmallBlindRaise);

                    action = RecognitionFirstAction(context);
                    return action;
                }
            }
            else
            {
                action = RecognitionSecondAction(context);
                return action;
            }
        }

        public static PlayerAction GetFlopAction(GetActionContext context)
        {
            var handStrength = HandEvaluator.Evaluate(context.FirstCard, context.SecondCard, context.CommunityCards);
            if (CheckFoldHands.Any(h => h == handStrength))
            {
                return PlayerAction.Fold();
            }

            return PlayerAction.Raise(context.OpponentStack);
        }

        public static PlayerAction GetTurnAction(GetActionContext context)
        {
            var handStrength = HandEvaluator.Evaluate(context.FirstCard, context.SecondCard, context.CommunityCards);
            if (CheckFoldHands.Any(h => h == handStrength))
            {
                return PlayerAction.Fold();
            }

            return PlayerAction.Raise(context.OpponentStack);
        }

        public static PlayerAction GetRiverAction(GetActionContext context)
        {
            var handStrength = HandEvaluator.Evaluate(context.FirstCard, context.SecondCard, context.CommunityCards);
            if (CheckFoldHands.Any(h => h == handStrength))
            {
                return PlayerAction.Fold();
            }

            return PlayerAction.Raise(context.OpponentStack);
        }

        private static byte GetBehaviourValue(Card firstCard, Card secondCard, byte[,] matrix)
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

        private static PlayerAction RecognitionFirstAction(GetActionContext context)
        {
            int bigBlind = context.SmallBlind * 2;
            var lastAction = context.PreviousRoundActions.Last();
            int lastActionMoney = lastAction.Action.Money;

            switch (behaviourValue)
            {
                case 0: return PlayerAction.Fold();
                case 1: return PlayerAction.CheckOrCall();
                case 2: return PlayerAction.CheckOrCall();
                case 3: return PlayerAction.CheckOrCall();
                case 4: return PlayerAction.CheckOrCall();
                case 5: return PlayerAction.Raise(bigBlind);
                case 6: return PlayerAction.Raise(bigBlind);
                case 7: return PlayerAction.Raise(bigBlind);
                case 8: return PlayerAction.Raise(context.MyMoney);
                case 9:
                    if (lastActionMoney <= bigBlind)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        return PlayerAction.Fold();
                    }

                case 10:
                    if (lastActionMoney <= bigBlind * 2)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        return PlayerAction.Fold();
                    }

                case 11: return PlayerAction.Raise(lastActionMoney * 2);
                case 12: return PlayerAction.Raise(lastActionMoney * 2);
                case 13: return PlayerAction.CheckOrCall();

                default: throw new System.ArgumentException();
            }
        }

        private static PlayerAction RecognitionSecondAction(GetActionContext context)
        {
            int bigBlind = context.SmallBlind * 2;
            var lastAction = context.PreviousRoundActions.Last();
            int lastActionMoney = lastAction.Action.Money;
            var lastMyAction = context.PreviousRoundActions.Last(x => x.PlayerName == context.Name);
            int lastMyActionMoney = lastAction.Action.Money;

            switch (behaviourValue)
            {
                case 1: return PlayerAction.Fold();
                case 2:
                    if (lastActionMoney <= bigBlind)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        return PlayerAction.Fold();
                    }

                case 3:
                    if (lastActionMoney <= bigBlind * 2)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        return PlayerAction.Fold();
                    }

                case 4: return PlayerAction.Raise(context.MyMoney);
                case 5: return PlayerAction.Fold();
                case 6:
                    if (lastActionMoney <= lastMyActionMoney * 2)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        return PlayerAction.Fold();
                    }

                case 7: return PlayerAction.Raise(context.MyMoney);
                case 11: return PlayerAction.Fold();
                case 12: return PlayerAction.Raise(context.MyMoney);

                default: return PlayerAction.CheckOrCall();
            }
        }

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
    }
}
