namespace TexasHoldem.AI.ErisHUBaseStrategy.StackStageStrategies
{
    using System.Linq;

    using TexasHoldem.HandEvaluate;
    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public static class ShortStackStrategy
    {
        private const int MaxCardTypeValue = 14;

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
            { 12, 12, 12, 10, 10, 10, 10, 10, 9, 9, 9,  9,  9 },  // K
            { 12, 12, 12, 10, 10, 10, 10, 9,  9, 9, 9,  9,  9 },  // Q
            { 12, 10, 10, 8,  10, 10, 9,  9,  9, 9, 9,  0,  0 },  // J
            { 12, 10, 10, 10, 8,  10, 9,  9,  9, 9, 0,  0,  0 },  // T
            { 8,  10, 10, 9,  9,  8,  9,  9,  9, 9, 0,  0,  0 },  // 9
            { 8,  9,  9,  9,  9,  9,  8,  9,  9, 9, 9,  0,  0 },  // 8
            { 8,  9,  9,  9,  9,  9,  9,  8,  9, 9, 9,  0,  0 },  // 7
            { 10, 9,  9,  9,  9,  0,  0,  9,  8, 9, 9,  0,  0 },  // 6
            { 10, 9,  9,  0,  0,  0,  0,  0,  0, 8, 9,  0,  0 },  // 5
            { 10, 9,  0,  0,  0,  0,  0,  0,  0, 0, 8,  0,  0 },  // 4
            { 10, 9,  0,  0,  0,  0,  0,  0,  0, 0, 0,  8,  0 },  // 3
            { 10, 9,  0,  0,  0,  0,  0,  0,  0, 0, 0,  0,  8 },  // 2
        };

        private static readonly byte[,] BigBlindMatrixWhenSmallBlindLimp =
       {   // A  K   Q   J   T   9   8   7   6   5   4   3   2
            { 7, 7,  7,  7,  7,  7,  7,  6,  6,  6,  6,  6,  6 },  // A
            { 7, 7,  7,  6,  6,  6,  6,  13, 13, 13, 13, 13, 13 }, // K
            { 7, 7,  7,  6,  6,  6,  6,  13, 13, 13, 13, 13, 13 }, // Q
            { 7, 6,  6,  7,  6,  6,  6,  13, 13, 13, 13, 13, 13 }, // J
            { 7, 6,  6,  6,  7,  6,  13, 13, 13, 13, 13, 13, 13 }, // T
            { 7, 5,  5,  5,  5,  7,  6,  13, 13, 13, 13, 13, 13 }, // 9
            { 6, 13, 13, 13, 13, 13, 7,  13, 13, 13, 13, 13, 13 }, // 8
            { 6, 13, 13, 13, 13, 13, 13, 7,  13, 13, 13, 13, 13 }, // 7
            { 6, 13, 13, 13, 13, 13, 13, 13, 7,  13, 13, 13, 13 }, // 6
            { 6, 13, 13, 13, 13, 13, 13, 13, 13, 7,  13, 13, 13 }, // 5
            { 6, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13 }, // 4
            { 6, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13 }, // 3
            { 6, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13 }, // 2
        };

        #region PlayerGameType hands
        private static readonly HandStrengthType[] BluffGameHands =
            {
            };

        private static readonly HandStrengthType[] MaxValueGameHands =
            {
                HandStrengthType.TwoPairsWithoutPairsOnDryBoard,
                HandStrengthType.TripsWithDryBoard,
                HandStrengthType.SetOnDryBoard,
                HandStrengthType.StraightWithTwoMyCardsOnDryBoard,
                HandStrengthType.StraightWithOneMyHighCardOnDryBoard,
                HandStrengthType.FlushOnTheBoardImprovedToTop,
                HandStrengthType.TopFlushWithFourSuitedCardsOnTheBoard,
                HandStrengthType.BigFlushWithThreeSuitedCardsOnDryBoard,
                HandStrengthType.SmallFlushWithThreeSuitedCardsOnDryBoard,
                HandStrengthType.FullHouseImprovedTrips,
                HandStrengthType.FullHouseImprovedPair,
                HandStrengthType.FullHouseTripsOnTheBoardAndOverPair,
                HandStrengthType.FullHouseTripsOnTheBoardReplacedWithBetter,
                HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForBestPair,
                HandStrengthType.FullHouseTwoPairsOnTheBoardAndOneMyCardForBestTrips,
                HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeBestSet,
                HandStrengthType.FullHouseWithOnePairOnTheTable,
                HandStrengthType.FourOfAKindWithMyCards,
                HandStrengthType.FourOfAKindImprovedToTopKicker,
                HandStrengthType.FourOfAkindWithTopKickerWithoutMyCards,
                HandStrengthType.StraightFlush,
                HandStrengthType.TopOnePairOnDryBoardWithTopKicker,
                HandStrengthType.OverPairOnDryBoard,
                HandStrengthType.SetOnNotVeryWetBoard,
                HandStrengthType.StraightWithOneMyMiddleCardOnDryBoard,
                HandStrengthType.TopOnePairOnDryBoardWithMiddleKicker,
                HandStrengthType.TopOnePairOnDryBoardWithSmallKicker,
                HandStrengthType.TopOnePairOnNotVeryWetBoardWithTopKicker,
                HandStrengthType.OverPairOnNotVeryWetBoard,
                HandStrengthType.TwoPairsOnePairOnDryBoardAndTopPairWithMyCard,
                HandStrengthType.TwoPairsWithoutPairsOnNotVeryWetBoard,
                HandStrengthType.TripsWithNotVeryWetBoard,
                HandStrengthType.StraightWithOneMyLowerCardOnDryBoard,
                HandStrengthType.FlushOnTheBoardMiddleImproved,
                HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeMiddleSet,
                HandStrengthType.FullHouseTwoPairsOnTheBoardAndOneMyCardForSmallTrips,
                HandStrengthType.FourOfAKindImprovedKicker,
                HandStrengthType.MiddleFlushWithFourSuitedCardsOnTheBoard,

            };

        private static readonly HandStrengthType[] SmallValueGameHands =
            {
                 HandStrengthType.MiddleOnePairOnDryBoardWithMiddleKicker,
                 HandStrengthType.MiddleOnePairOnDryBoardWithTopKicker,
                 HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithMiddleKicker,
                 HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithTopKicker,
                 HandStrengthType.TopOnePairOnNotVeryWetBoardWithSmallKicker,
                 HandStrengthType.TopOnePairOnNotVeryWetBoardWithMiddleKicker,
                 HandStrengthType.TwoPairsOnePairOnDryBoardAndMiddlePairWithMyCard,
                 HandStrengthType.TwoPairsOnePairOnDryBoardAndOverPairWithMyCards,
                 HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndTopPairWithMyCard,
                 HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndOverPairWithMyCards,
                 HandStrengthType.FlushOnTheBoardLittleImproved,
                 HandStrengthType.SmallFlushWithFourSuitedCardsOnTheBoard,
                 HandStrengthType.FlushWithThreeSuitedCardsOnWetBoard,
                 HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForSmallPair,
                 HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeSmallestSet,
                 HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker,
                 HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithSmallKicker,
                 HandStrengthType.TwoPairsImprovedWithOverPair,
                 HandStrengthType.TwoPairsImprovedToTopKicker,
                 HandStrengthType.TwoPairsOnePairOnDryBoardAndMiddlePairWithMyCard,
                 HandStrengthType.StraightWithTwoMyCardsOnWetBoard,
                 HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCard,
                 HandStrengthType.TwoPairsOnePairOnDryBoardAndSmallestPairWithMyCard,

            };

        private static readonly HandStrengthType[] CheckCallSmallGameHands =
            {
                 HandStrengthType.SmallOnePairOnDryBoardWithMiddleKicker,
                 HandStrengthType.SmallOnePairOnDryBoardWithTopKicker,
                 HandStrengthType.SmallOnePairOnNotVeryWetBoardWithMiddleKicker,
                 HandStrengthType.SmallOnePairOnNotVeryWetBoardWithTopKicker,
                 HandStrengthType.MiddleOnePairOnWetBoardWithTopKicker,
                 HandStrengthType.TopOnePairOnWetBoardWithSmallKicker,
                 HandStrengthType.TopOnePairOnWetBoardWithMiddleKicker,
                 HandStrengthType.TopOnePairOnWetBoardWithTopKicker,
                 HandStrengthType.OverPairOnWetBoard,
                 HandStrengthType.TwoPairsOnePairOnWetBoardAndOverPairWithMyCards,
                 HandStrengthType.TwoPairsWithoutPairsOnWetBoard,
                 HandStrengthType.TwoPairsOnePairOnWetBoardAndTopPairWithMyCard,
                 HandStrengthType.TripsWithWetBoard,
                 HandStrengthType.SetOnWetBoard,
                 HandStrengthType.StraightOnTheBoardWithoutMyCardsOnDryBoard,
                 HandStrengthType.StraightWithOneMyHighCardOnWetBoard,
                 HandStrengthType.StraightWithOneMyMiddleCardOnWetBoard,
                 HandStrengthType.FlushOnTheBoardWithoutMyCards,
                 HandStrengthType.FullHouseWithoutMyCards,
                 HandStrengthType.MiddleOnePairOnWetBoardWithSmallKicker,
                 HandStrengthType.MiddleOnePairOnWetBoardWithMiddleKicker,
                 HandStrengthType.TwoPairsWithTopKickerWitoutMyCards,
                 HandStrengthType.TwoPairsOnePairOnWetBoardAndSmallestPairWithMyCard,
                 HandStrengthType.TwoPairsOnePairOnWetBoardAndMiddlePairWithMyCard,
                 HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCard,
                 HandStrengthType.StraightWithOneMyLowerCardOnWetBoard,
                 HandStrengthType.SmallOnePairOnWetBoardWithTopKicker
            };

        private static readonly HandStrengthType[] CheckFoldGameHands =
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
                 HandStrengthType.SmallOnePairOnWetBoardWithSmallKicker,
                 HandStrengthType.SmallOnePairOnWetBoardWithMiddleKicker,
                 HandStrengthType.SmallOnePairOnNotVeryWetBoardWithSmallKicker,
                 HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker,
                 HandStrengthType.TwoPairsImprovedKicker,
                 HandStrengthType.TwoPairsWithoutMyCards,
                 HandStrengthType.TripsOnTheBoard,
                 HandStrengthType.StraightOnTheBoardWithoutMyCardsOnWetBoard,
                 HandStrengthType.FourOfAKindWithoutMyCards,
            };
        #endregion

        private static byte behaviourValue;

        public static PlayerAction GetPreflopAction(GetActionContext context)
        {
            PlayerAction action;


            if (context.PreviousRoundActions.Count == 2)
            {
                behaviourValue = GetBehaviourValue(context.FirstCard, context.SecondCard, SmallBlindMatrix);

                action = RecognitionFirstAction(context);
                return action;
            }

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
            if (context.CurrentPot / 3 > context.MyMoney)
            {
                return PlayerAction.Raise(context.MyMoney);
            }
            var playerGameType = RecognitionPlayerGameType(context);
            switch (playerGameType)
            {
                case PlayerGameType.CheckFold:
                    if (context.CanCheck || context.MyMoney == 0)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        return PlayerAction.Fold();
                    }

                case PlayerGameType.CheckCallSmall:
                    if (context.CanCheck || context.MyMoney == 0)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        if (context.PreviousRoundActions.LastOrDefault().Action.Money <= context.CurrentPot / 2 || context.MyMoney == 0)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            return PlayerAction.Fold();
                        }
                    }

                case PlayerGameType.SmallValue:
                    if (context.CanCheck)
                    {
                        return PlayerAction.Raise(context.CurrentPot / 3);
                    }
                    else
                    {
                        var lastMyAction = context.PreviousRoundActions.LastOrDefault(x => x.PlayerName == context.Name);

                        if (lastMyAction.Action != null && lastMyAction.Action.Type == PlayerActionType.Raise && context.PreviousRoundActions.LastOrDefault().Action.Money >= lastMyAction.Action.Money)
                        {
                            return PlayerAction.Fold();
                        }

                        if (context.PreviousRoundActions.LastOrDefault().Action.Money <= context.CurrentPot / 2 || context.MyMoney == 0)
                        {
                            return PlayerAction.CheckOrCall();
                        }
                        else
                        {
                            return PlayerAction.Fold();
                        }
                    }

                case PlayerGameType.MaxValue: return PlayerAction.Raise(context.CurrentPot / 3);

                case PlayerGameType.Bluff: throw new System.NotImplementedException("Bluff");

                default: throw new System.ArgumentException("PlayerGameType Error !!");
            }
        }

        public static PlayerAction GetTurnAction(GetActionContext context)
        {
            if (context.CurrentPot / 3 > context.MyMoney)
            {
                return PlayerAction.Raise(context.MyMoney);
            }
            var playerGameType = RecognitionPlayerGameType(context);

            return GetFlopAction(context);
        }

        public static PlayerAction GetRiverAction(GetActionContext context)
        {
            if (context.CurrentPot / 3 > context.MyMoney)
            {
                return PlayerAction.Raise(context.MyMoney);
            }

            var playerGameType = RecognitionPlayerGameType(context);

            return GetFlopAction(context);
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
            var lastAction = context.PreviousRoundActions.LastOrDefault();
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
            var lastAction = context.PreviousRoundActions.LastOrDefault();
            int lastActionMoney = lastAction.Action.Money;
            var lastMyAction = context.PreviousRoundActions.LastOrDefault(x => x.PlayerName == context.Name);
            int lastMyActionMoney = lastAction.Action.Money;

            switch (behaviourValue)
            {
                case 1:
                    if (lastActionMoney < bigBlind)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        return PlayerAction.Fold();
                    }

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
                case 5:
                    if (lastActionMoney <= bigBlind)
                    {
                        return PlayerAction.CheckOrCall();
                    }
                    else
                    {
                        return PlayerAction.Fold();
                    }

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

        private static PlayerGameType RecognitionPlayerGameType(GetActionContext context)
        {
            var handStrength = HandEvaluator.Evaluate(context.FirstCard, context.SecondCard, context.CommunityCards);

            if (CheckFoldGameHands.Contains(handStrength))
            {
                return PlayerGameType.CheckFold;
            }

            if (BluffGameHands.Contains(handStrength))
            {
                return PlayerGameType.Bluff;
            }

            if (SmallValueGameHands.Contains(handStrength))
            {
                return PlayerGameType.SmallValue;
            }

            if (MaxValueGameHands.Contains(handStrength))
            {
                return PlayerGameType.MaxValue;
            }

            if (CheckCallSmallGameHands.Contains(handStrength))
            {
                return PlayerGameType.CheckCallSmall;
            }

            throw new System.ArgumentException("PlayerGameType Error !!");
        }
    }
}
