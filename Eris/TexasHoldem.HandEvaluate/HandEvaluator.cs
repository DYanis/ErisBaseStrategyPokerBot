namespace TexasHoldem.HandEvaluate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TexasHoldem.Logic.Cards;

    public static class HandEvaluator
    {
        private const int ComparableCards = 5;

        private const byte MinimumSuitedCardsOnTheBoardForFlush = 3;

        public static HandStrengthType Evaluate(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            var allCards = new List<Card>();
            allCards.AddRange(board);
            allCards.Add(firstCard);
            allCards.Add(secondCard);

            var generalHandEvaluator = new TexasHoldem.Logic.Helpers.HandEvaluator();
            var generalHandType = generalHandEvaluator.GetBestHand(allCards).RankType;

            if (generalHandType == TexasHoldem.Logic.HandRankType.HighCard)
            {
                return HandStrengthType.HighCard;
            }

            if (generalHandType == TexasHoldem.Logic.HandRankType.Pair)
            {
                return OnePairSubTypeRecognition(firstCard, secondCard, board);
            }

            if (generalHandType == TexasHoldem.Logic.HandRankType.TwoPairs)
            {
                return TwoPairsSubTypeRecognition(firstCard, secondCard, board);
            }

            if (generalHandType == TexasHoldem.Logic.HandRankType.ThreeOfAKind)
            {
                return ThreeOfAKindSubTypeRecognition(firstCard, secondCard, board);
            }

            if (generalHandType == TexasHoldem.Logic.HandRankType.Straight)
            {
                return StraightSubTypeRecognition(firstCard, secondCard, board);
            }

            if (generalHandType == TexasHoldem.Logic.HandRankType.Flush)
            {
                return FlushSubTypeRecognition(firstCard, secondCard, board);
            }

            if (generalHandType == TexasHoldem.Logic.HandRankType.FullHouse)
            {
                return FullHouseSubTypeRecognition(firstCard, secondCard, board);
            }

            if (generalHandType == TexasHoldem.Logic.HandRankType.FourOfAKind)
            {
                return FourOfAKindSubTypeRecognition(firstCard, secondCard, board);
            }

            if (generalHandType == TexasHoldem.Logic.HandRankType.StraightFlush)
            {
                return HandStrengthType.StraightFlush;
            }

            throw new ArgumentException("Hand Evaluator error !!");
        }

        public static HandStrengthType FourOfAKindSubTypeRecognition(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            if (board.Any(x => board.Count(y => y.Type == x.Type) == 4))
            {
                var fourOfAKindCard = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 4);

                if (board.Count == 4)
                {
                    if (fourOfAKindCard.Type == CardType.Ace && (firstCard.Type == CardType.Ace || secondCard.Type == CardType.Ace))
                    {
                        return HandStrengthType.FourOfAKindImprovedToTopKicker;
                    }

                    return HandStrengthType.FourOfAKindImprovedKicker;
                }

                var kickerOnTheBoard = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 1);

                if (kickerOnTheBoard.Type >= firstCard.Type && kickerOnTheBoard.Type >= secondCard.Type)
                {
                    if ((fourOfAKindCard.Type < CardType.Ace && kickerOnTheBoard.Type == CardType.Ace)
                        || (fourOfAKindCard.Type == CardType.Ace && kickerOnTheBoard.Type == CardType.King))
                    {
                        return HandStrengthType.FourOfAkindWithTopKickerWithoutMyCards;
                    }

                    return HandStrengthType.FourOfAKindWithoutMyCards;
                }
                else if (kickerOnTheBoard.Type < firstCard.Type || kickerOnTheBoard.Type < secondCard.Type)
                {
                    if (((int)fourOfAKindCard.Type < (int)CardType.Ace && (firstCard.Type == CardType.Ace || secondCard.Type == CardType.Ace))
                        || (fourOfAKindCard.Type == CardType.Ace
                        && (firstCard.Type == CardType.King || secondCard.Type == CardType.King)))
                    {
                        return HandStrengthType.FourOfAKindImprovedToTopKicker;
                    }

                    return HandStrengthType.FourOfAKindImprovedKicker;
                }

                throw new Exception("Four of a kind");
            }
            else
            {
                return HandStrengthType.FourOfAKindWithMyCards;
            }
        }

        public static HandStrengthType FullHouseSubTypeRecognition(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            bool haveTripsOnTheBoard = board.Any(x => board.Count(y => y.Type == x.Type) == 3);
            int pairsOnBoard = board.Count(x => board.Count(y => y.Type == x.Type) == 2) / 2;
            bool myCardsAreEqual = firstCard.Type == secondCard.Type;

            // full house on the board
            if (haveTripsOnTheBoard && pairsOnBoard == 1)
            {
                var tripsCard = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 3);
                var pairCard = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 2);

                // TTTJJ-JQ
                if (pairCard.Type > tripsCard.Type && (firstCard.Type == pairCard.Type || secondCard.Type == pairCard.Type))
                {
                    return HandStrengthType.FullHouseImprovedTrips;
                }

                // TTTJJ-QQ
                if (myCardsAreEqual && pairCard.Type < firstCard.Type)
                {
                    return HandStrengthType.FullHouseImprovedPair;
                }

                // 77999-A3 or 77999-A7 or KK333-58 or 333KK-55
                return HandStrengthType.FullHouseWithoutMyCards;
            }

            // 3 equal cards on the board
            if (haveTripsOnTheBoard && pairsOnBoard == 0)
            {
                if (board.Count == 3)
                {
                    return HandStrengthType.FullHouseTripsOnTheBoardAndOverPair;
                }

                var firstKicker = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 1);
                var secondKicker = board.LastOrDefault(x => board.Count(y => y.Type == x.Type) == 1);
                var tripsCard = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 3);

                // AAA28-99
                if (myCardsAreEqual && (firstKicker.Type < firstCard.Type && secondKicker.Type < firstCard.Type))
                {
                    return HandStrengthType.FullHouseTripsOnTheBoardAndOverPair;
                }

                // 33348-44
                if (myCardsAreEqual && tripsCard.Type < firstCard.Type &&
                    (firstKicker.Type == firstCard.Type || secondKicker.Type == firstCard.Type))
                {
                    return HandStrengthType.FullHouseTripsOnTheBoardReplacedWithBetter;
                }

                // 88843-T4
                var biggestKicker = firstKicker.Type > secondKicker.Type ? firstKicker : secondKicker;
                if (!myCardsAreEqual && (biggestKicker.Type == firstCard.Type || biggestKicker.Type == secondCard.Type))
                {
                    return HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForBestPair;
                }

                // 88843-T3 or 88864-55 or 888T4-22 or 888T4-44
                return HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForSmallPair;
            }

            // 2 pairs on the board
            if (pairsOnBoard == 2)
            {
                var firstPairCard = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 2);
                var secondPairCard = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type && firstPairCard.Type != x.Type) == 2);
                var bigPairCard = firstPairCard.Type > secondPairCard.Type ? firstPairCard : secondPairCard;
                var smallPairCard = firstPairCard.Type < secondPairCard.Type ? firstPairCard : secondPairCard;

                // 88TT4-TK
                if (firstCard.Type == bigPairCard.Type || secondCard.Type == bigPairCard.Type)
                {
                    return HandStrengthType.FullHouseTwoPairsOnTheBoardAndOneMyCardForBestTrips;
                }

                // 55339-34
                if (firstCard.Type == smallPairCard.Type || secondCard.Type == smallPairCard.Type)
                {
                    return HandStrengthType.FullHouseTwoPairsOnTheBoardAndOneMyCardForSmallTrips;
                }

                // 55339-99
                if (myCardsAreEqual && firstCard.Type > bigPairCard.Type)
                {
                    return HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeBestSet;
                }

                // 55332-22
                if (myCardsAreEqual && firstCard.Type < smallPairCard.Type)
                {
                    return HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeSmallestSet;
                }

                // 55334-44
                return HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeMiddleSet;
            }

            // only 1 pair on the board
            if (pairsOnBoard == 1 && !haveTripsOnTheBoard)
            {
                return HandStrengthType.FullHouseWithOnePairOnTheTable;
            }

            throw new Exception("Full house");
        }

        public static HandStrengthType FlushSubTypeRecognition(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            var flushSuit = board.FirstOrDefault(x => board.Count(y => y.Suit == x.Suit) >= MinimumSuitedCardsOnTheBoardForFlush).Suit;
            int flushSuitCardsOnTheBoard = board.Count(x => x.Suit == flushSuit);
            var allCardTypes = new List<CardType>
            {
                CardType.Two, CardType.Three, CardType.Four, CardType.Five, CardType.Six, CardType.Seven,
                CardType.Eight, CardType.Nine, CardType.Ten, CardType.Jack, CardType.Queen, CardType.King, CardType.Ace
            };

            foreach (var card in board)
            {
                if (card.Suit == flushSuit)
                {
                    allCardTypes.Remove(card.Type);
                }
            }

            // 3s-4s-5s-Ts-Js || 5c6c
            if (firstCard.Suit != flushSuit && secondCard.Suit != flushSuit)
            {
                return HandStrengthType.FlushOnTheBoardWithoutMyCards;
            }

            var myBestCardForFlush = firstCard.Suit == flushSuit && secondCard.Suit == flushSuit
                ? firstCard.Type > secondCard.Type ? firstCard : secondCard
                : firstCard.Suit == flushSuit ? firstCard : secondCard;

            // 5 Equal Suit cards on the board
            if (flushSuitCardsOnTheBoard == 5)
            {
                // 8s-9s-5s-Ts-Js || 4s3s
                if (!board.Any(c => c.Type < myBestCardForFlush.Type))
                {
                    return HandStrengthType.FlushOnTheBoardWithoutMyCards;
                }

                var minBoardCardType = board.Min(x => x.Type);
                allCardTypes.RemoveAll(x => x < minBoardCardType);

                int indexOfMyBestCardForFlush = allCardTypes.IndexOf(myBestCardForFlush.Type);

                // As-4s-5s-Ts-Js || 5cKs
                if (indexOfMyBestCardForFlush == allCardTypes.Count - 1)
                {
                    return HandStrengthType.FlushOnTheBoardImprovedToTop;
                }

                // 3s-4s-5s-Ts-Js || 5cQs
                if (indexOfMyBestCardForFlush > (allCardTypes.Count / 2) - 1)
                {
                    return HandStrengthType.FlushOnTheBoardMiddleImproved;
                }
                else
                {
                    // 3s-4s-5s-Ts-Js || 5c7s
                    return HandStrengthType.FlushOnTheBoardLittleImproved;
                }
            }

            // 4 Equal Suit cards on the board
            if (flushSuitCardsOnTheBoard == 4)
            {
                int indexOfMyBestCardForFlush = allCardTypes.IndexOf(myBestCardForFlush.Type);

                // 3s-4s-5s-Ts-Jd || 5cAs
                if (indexOfMyBestCardForFlush == allCardTypes.Count - 1)
                {
                    return HandStrengthType.TopFlushWithFourSuitedCardsOnTheBoard;
                }

                // 3s-4s-5s-Ts-Jd || 5cKs
                if (indexOfMyBestCardForFlush > (allCardTypes.Count / 2) - 1)
                {
                    return HandStrengthType.MiddleFlushWithFourSuitedCardsOnTheBoard;
                }
                else
                {
                    // 3s-4s-5s-Ts-Jd || 5c8s
                    return HandStrengthType.SmallFlushWithFourSuitedCardsOnTheBoard;
                }
            }

            // 3 Equal Suit cards on the board
            if (flushSuitCardsOnTheBoard == 3)
            {
                int indexOfMyBestCardForFlush = allCardTypes.IndexOf(myBestCardForFlush.Type);
                bool isDryBoard = false;
                bool haveTripsOnTheBoard = board.Any(x => board.Count(y => y.Type == x.Type) == 3);
                int pairsOnBoard = board.Count(x => board.Count(y => y.Type == x.Type) == 2) / 2;

                if (!haveTripsOnTheBoard && pairsOnBoard < 2)
                {
                    isDryBoard = true;
                }

                // 3s-5c-5s-Td-Ts || Js8s
                if (!isDryBoard)
                {
                    return HandStrengthType.FlushWithThreeSuitedCardsOnWetBoard;
                }

                // Ks-4s-5s-Td-Tc || Js8s
                if (indexOfMyBestCardForFlush > (allCardTypes.Count / 2))
                {
                    return HandStrengthType.BigFlushWithThreeSuitedCardsOnDryBoard;
                }
                else
                {
                    // 3s-4s-5s-Td-Jd || Ts8s
                    return HandStrengthType.SmallFlushWithThreeSuitedCardsOnDryBoard;
                }
            }

            throw new Exception("Flush");
        }

        public static HandStrengthType StraightSubTypeRecognition(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            bool haveTripsOnTheBoard = board.Any(x => board.Count(y => y.Type == x.Type) == 3);
            int pairsOnBoard = board.Count(x => board.Count(y => y.Type == x.Type) == 2) / 2;
            bool haveFourSuitedCardsOnTheBoard = board.Any(x => board.Count(y => y.Suit == x.Suit) >= 4);
            bool isDryBoard = true;

            if (haveTripsOnTheBoard || pairsOnBoard == 2 || haveFourSuitedCardsOnTheBoard)
            {
                isDryBoard = false;
            }

            var cardTypeCounts = new int[(int)CardType.Ace + 1];
            cardTypeCounts[(int)firstCard.Type]++;
            cardTypeCounts[(int)secondCard.Type]++;

            foreach (var card in board)
            {
                cardTypeCounts[(int)card.Type]++;
            }

            var bestStraight = GetStraightCards(cardTypeCounts);
            int numberOfBestStraightCardsOneTheBoard = 0;

            foreach (var cardType in bestStraight)
            {
                if (board.Any(x => x.Type == cardType))
                {
                    numberOfBestStraightCardsOneTheBoard++;
                }
            }

            if (numberOfBestStraightCardsOneTheBoard == 5 && isDryBoard)
            {

                return HandStrengthType.StraightOnTheBoardWithoutMyCardsOnDryBoard;
            }

            if (numberOfBestStraightCardsOneTheBoard == 5 && !isDryBoard)
            {
                return HandStrengthType.StraightOnTheBoardWithoutMyCardsOnWetBoard;
            }

            if (numberOfBestStraightCardsOneTheBoard == 4)
            {
                var myStraightCard = bestStraight.FirstOrDefault(c => !board.Any(x => x.Type == c));
                var minStraightCard = bestStraight.Min();
                var maxStraightcard = bestStraight.Max();

                if (isDryBoard)
                {
                    if (myStraightCard < maxStraightcard && myStraightCard > minStraightCard)
                    {
                        return HandStrengthType.StraightWithOneMyMiddleCardOnDryBoard;
                    }

                    if (myStraightCard == maxStraightcard)
                    {
                        return HandStrengthType.StraightWithOneMyHighCardOnDryBoard;
                    }
                    else
                    {
                        return HandStrengthType.StraightWithOneMyLowerCardOnDryBoard;
                    }
                }
                else
                {
                    if (myStraightCard < maxStraightcard && myStraightCard > minStraightCard)
                    {
                        return HandStrengthType.StraightWithOneMyMiddleCardOnWetBoard;
                    }

                    if (myStraightCard == maxStraightcard)
                    {
                        return HandStrengthType.StraightWithOneMyHighCardOnWetBoard;
                    }
                    else
                    {
                        return HandStrengthType.StraightWithOneMyLowerCardOnWetBoard;
                    }
                }
            }

            if (numberOfBestStraightCardsOneTheBoard == 3 && isDryBoard)
            {
                return HandStrengthType.StraightWithTwoMyCardsOnDryBoard;
            }

            if (numberOfBestStraightCardsOneTheBoard == 3 && !isDryBoard)
            {
                return HandStrengthType.StraightWithTwoMyCardsOnWetBoard;
            }

            throw new NotImplementedException("Straight");
        }

        public static HandStrengthType ThreeOfAKindSubTypeRecognition(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            bool haveTripsOnTheBoard = board.Any(x => board.Count(y => y.Type == x.Type) == 3);
            if (haveTripsOnTheBoard)
            {
                return HandStrengthType.TripsOnTheBoard;
            }

            int pairsOnBoard = board.Count(x => board.Count(y => y.Type == x.Type) == 2) / 2;

            BoardType boardType = BoardTypeRecognition(board);

            if (pairsOnBoard == 1)
            {
                if (boardType == BoardType.Wet)
                {
                    return HandStrengthType.TripsWithWetBoard;
                }

                if (boardType == BoardType.NotVeryWet)
                {
                    return HandStrengthType.TripsWithNotVeryWetBoard;
                }

                return HandStrengthType.TripsWithDryBoard;
            }

            if (boardType == BoardType.Wet)
            {
                return HandStrengthType.SetOnWetBoard;
            }

            if (boardType == BoardType.NotVeryWet)
            {
                return HandStrengthType.SetOnNotVeryWetBoard;
            }

            return HandStrengthType.SetOnDryBoard;
        }

        public static HandStrengthType TwoPairsSubTypeRecognition(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            int pairsOnBoard = board.Count(x => board.Count(y => y.Type == x.Type) == 2) / 2;

            if (pairsOnBoard == 2)
            {
                var myBigestCard = firstCard.Type > secondCard.Type ? firstCard : secondCard;
                Card kickerOnTheBoard = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 1);
                var firstPairType = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 2).Type;
                var secondPairType = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type && firstPairType != x.Type) == 2).Type;

                if (firstCard.Type == secondCard.Type && (firstCard.Type > firstPairType || firstCard.Type > secondPairType))
                {
                    return HandStrengthType.TwoPairsImprovedWithOverPair;
                }

                if ((kickerOnTheBoard != null && (firstPairType == CardType.Ace || secondPairType == CardType.Ace)
                    && (firstPairType == CardType.King || secondPairType == CardType.King)
                    && kickerOnTheBoard.Type == CardType.Queen))
                {
                    return HandStrengthType.TwoPairsWithTopKickerWitoutMyCards;
                }

                if ((kickerOnTheBoard != null && (firstPairType == CardType.Ace || secondPairType == CardType.Ace) && kickerOnTheBoard.Type == CardType.King))
                {
                    return HandStrengthType.TwoPairsWithTopKickerWitoutMyCards;
                }

                if (kickerOnTheBoard != null && kickerOnTheBoard.Type == CardType.Ace)
                {
                    return HandStrengthType.TwoPairsWithTopKickerWitoutMyCards;
                }

                if ((firstPairType == CardType.Ace || secondPairType == CardType.Ace)
                    && (firstPairType == CardType.King || secondPairType == CardType.King)
                    && myBigestCard.Type == CardType.Queen)
                {
                    return HandStrengthType.TwoPairsImprovedToTopKicker;
                }

                if ((firstPairType == CardType.Ace || secondPairType == CardType.Ace) && myBigestCard.Type == CardType.King)
                {
                    return HandStrengthType.TwoPairsImprovedToTopKicker;
                }

                if (myBigestCard.Type == CardType.Ace)
                {
                    return HandStrengthType.TwoPairsImprovedToTopKicker;
                }

                if (kickerOnTheBoard != null && (kickerOnTheBoard.Type < firstCard.Type || kickerOnTheBoard.Type < secondCard.Type))
                {
                    return HandStrengthType.TwoPairsImprovedKicker;
                }

                return HandStrengthType.TwoPairsWithoutMyCards;
            }

            if (pairsOnBoard == 1)
            {
                bool myCardsAreEqual = firstCard.Type == secondCard.Type;
                var pairType = board.FirstOrDefault(x => board.Count(y => y.Type == x.Type) == 2).Type;
                var boardKickers = board.Where(x => x.Type != pairType);
                var smallestKicker = boardKickers.Min(x => x.Type);
                var topKicker = boardKickers.Max(x => x.Type);
                Card middleKicker = boardKickers.FirstOrDefault(x => x.Type != smallestKicker && x.Type != topKicker);

                BoardType boardType = BoardTypeRecognition(board);

                if (boardType == BoardType.NotVeryWet)
                {
                    if (myCardsAreEqual)
                    {
                        if (firstCard.Type > pairType)
                        {
                            return HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndOverPairWithMyCards;
                        }

                        if (firstCard.Type < smallestKicker)
                        {
                            return HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCard;
                        }

                        if (firstCard.Type > smallestKicker)
                        {
                            return HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCard;
                        }
                    }

                    if (firstCard.Type == topKicker || secondCard.Type == topKicker)
                    {
                        return HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndTopPairWithMyCard;
                    }

                    if (middleKicker != null && (firstCard.Type == middleKicker.Type || secondCard.Type == middleKicker.Type))
                    {
                        return HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCard;
                    }

                    if (firstCard.Type == smallestKicker || secondCard.Type == smallestKicker)
                    {
                        return HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCard;
                    }
                }

                if (boardType == BoardType.Dry)
                {
                    if (myCardsAreEqual)
                    {
                        if (firstCard.Type > pairType)
                        {
                            return HandStrengthType.TwoPairsOnePairOnDryBoardAndOverPairWithMyCards;
                        }

                        if (firstCard.Type < smallestKicker)
                        {
                            return HandStrengthType.TwoPairsOnePairOnDryBoardAndSmallestPairWithMyCard;
                        }

                        if (firstCard.Type > smallestKicker)
                        {
                            return HandStrengthType.TwoPairsOnePairOnDryBoardAndMiddlePairWithMyCard;
                        }
                    }

                    if (firstCard.Type == topKicker || secondCard.Type == topKicker)
                    {
                        return HandStrengthType.TwoPairsOnePairOnDryBoardAndTopPairWithMyCard;
                    }

                    if (middleKicker != null && (firstCard.Type == middleKicker.Type || secondCard.Type == middleKicker.Type))
                    {
                        return HandStrengthType.TwoPairsOnePairOnDryBoardAndMiddlePairWithMyCard;
                    }

                    if (firstCard.Type == smallestKicker || secondCard.Type == smallestKicker)
                    {
                        return HandStrengthType.TwoPairsOnePairOnDryBoardAndSmallestPairWithMyCard;
                    }
                }
                else
                {
                    if (myCardsAreEqual)
                    {
                        if (firstCard.Type > pairType)
                        {
                            return HandStrengthType.TwoPairsOnePairOnWetBoardAndOverPairWithMyCards;
                        }

                        if (firstCard.Type < smallestKicker)
                        {
                            return HandStrengthType.TwoPairsOnePairOnWetBoardAndSmallestPairWithMyCard;
                        }

                        if (firstCard.Type > smallestKicker)
                        {
                            return HandStrengthType.TwoPairsOnePairOnWetBoardAndMiddlePairWithMyCard;
                        }
                    }

                    if (firstCard.Type == topKicker || secondCard.Type == topKicker)
                    {
                        return HandStrengthType.TwoPairsOnePairOnWetBoardAndTopPairWithMyCard;
                    }

                    if (middleKicker != null && (firstCard.Type == middleKicker.Type || secondCard.Type == middleKicker.Type))
                    {
                        return HandStrengthType.TwoPairsOnePairOnWetBoardAndMiddlePairWithMyCard;
                    }

                    if (firstCard.Type == smallestKicker || secondCard.Type == smallestKicker)
                    {
                        return HandStrengthType.TwoPairsOnePairOnWetBoardAndSmallestPairWithMyCard;
                    }
                }
            }

            if (pairsOnBoard == 0)
            {
                BoardType boardType = BoardTypeRecognition(board);

                if (boardType == BoardType.NotVeryWet)
                {
                    return HandStrengthType.TwoPairsWithoutPairsOnNotVeryWetBoard;
                }

                if (boardType == BoardType.Dry)
                {
                    return HandStrengthType.TwoPairsWithoutPairsOnDryBoard;
                }
                else
                {
                    return HandStrengthType.TwoPairsWithoutPairsOnWetBoard;
                }
            }

            throw new ArgumentException("Two pairs");
        }

        public static HandStrengthType OnePairSubTypeRecognition(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            int pairsOnBoard = board.Count(x => board.Count(y => y.Type == x.Type) == 2) / 2;
            BoardType boardType = BoardTypeRecognition(board);

            if (pairsOnBoard == 1)
            {
                var minBoardCardType = board.Min(x => x.Type);
                var myBestCard = firstCard.Type > secondCard.Type ? firstCard : secondCard;
                bool haveAnySmallerCardOnTheBoardThanMyBestCard = board.Any(c => c.Type < myBestCard.Type);

                if (haveAnySmallerCardOnTheBoardThanMyBestCard)
                {
                    var allCardTypes = new List<CardType>
                    {
                        CardType.Two, CardType.Three, CardType.Four, CardType.Five, CardType.Six, CardType.Seven,
                        CardType.Eight, CardType.Nine, CardType.Ten, CardType.Jack, CardType.Queen, CardType.King, CardType.Ace
                    };

                    foreach (var card in board)
                    {
                        allCardTypes.Remove(card.Type);
                    }

                    allCardTypes.RemoveAll(c => c < minBoardCardType);

                    int indexOfMyBestCard = allCardTypes.IndexOf(myBestCard.Type);
                    bool isBigKicker = false;

                    if (indexOfMyBestCard >= allCardTypes.Count / 2)
                    {
                        isBigKicker = true;
                    }

                    if (boardType == BoardType.NotVeryWet)
                    {
                        if (isBigKicker)
                        {
                            return HandStrengthType.OnePairOnNotVeryWetBoardWithBigImprovedKicker;
                        }
                        else
                        {
                            return HandStrengthType.OnePairOnNotVeryWetBoardWithSamllImprovedKicker;
                        }
                    }

                    if (boardType == BoardType.Dry)
                    {
                        if (isBigKicker)
                        {
                            return HandStrengthType.OnePairOnDryBoardWithBigImprovedKicker;
                        }
                        else
                        {
                            return HandStrengthType.OnePairOnDryBoardWithSamllImprovedKicker;
                        }
                    }
                    else
                    {
                        if (isBigKicker)
                        {
                            return HandStrengthType.OnePairOnWetBoardWithBigImprovedKicker;
                        }
                        else
                        {
                            return HandStrengthType.OnePairOnWetBoardWithSamllImprovedKicker;
                        }
                    }
                }
                else
                {
                    if (boardType == BoardType.NotVeryWet)
                    {
                        return HandStrengthType.OnePairOnNotVeryWetBoardWithoutMyCards;
                    }

                    if (boardType == BoardType.Dry)
                    {
                        return HandStrengthType.OnePairOnDryBoardWithoutMyCards;
                    }
                    else
                    {
                        return HandStrengthType.OnePairOnWetBoardWithoutMyCards;
                    }
                }
            }

            if (pairsOnBoard == 0)
            {
                // pair in my hand
                if (firstCard.Type == secondCard.Type)
                {
                    var topBoardCardType = board.Max(x => x.Type);
                    var minBoardCardType = board.Min(x => x.Type);
                    var orderedBoard = board.OrderBy(x => x.Type).ToArray();
                    var smallBoardCards = new List<Card>();

                    if (board.Count == 5)
                    {
                        smallBoardCards.Add(orderedBoard[0]);
                        smallBoardCards.Add(orderedBoard[1]);
                        smallBoardCards.Add(orderedBoard[2]);
                    }

                    if (board.Count == 4)
                    {
                        smallBoardCards.Add(orderedBoard[0]);
                        smallBoardCards.Add(orderedBoard[1]);
                    }

                    if (board.Count == 3)
                    {
                        smallBoardCards.Add(orderedBoard[0]);
                    }

                    // over pair
                    if (firstCard.Type > topBoardCardType)
                    {
                        if (boardType == BoardType.NotVeryWet)
                        {
                            return HandStrengthType.OverPairOnNotVeryWetBoard;
                        }

                        if (boardType == BoardType.Dry)
                        {
                            return HandStrengthType.OverPairOnDryBoard;
                        }
                        else
                        {
                            return HandStrengthType.OverPairOnWetBoard;
                        }
                    }

                    // smallest pair
                    if (smallBoardCards.Any(x => x.Type > firstCard.Type))
                    {
                        if (boardType == BoardType.NotVeryWet)
                        {
                            return HandStrengthType.SmallOnePairOnNotVeryWetBoardWithSmallKicker;
                        }

                        if (boardType == BoardType.Dry)
                        {
                            return HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker;
                        }
                        else
                        {
                            return HandStrengthType.SmallOnePairOnWetBoardWithSmallKicker;
                        }
                    }
                    else
                    {// middle pair
                        if (boardType == BoardType.NotVeryWet)
                        {
                            return HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithSmallKicker;
                        }

                        if (boardType == BoardType.Dry)
                        {
                            return HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker;
                        }
                        else
                        {
                            return HandStrengthType.MiddleOnePairOnWetBoardWithSmallKicker;
                        }
                    }
                }
                else
                {
                    var pairCard = board.FirstOrDefault(c => c.Type == firstCard.Type || c.Type == secondCard.Type);
                    var orderedBoard = board.OrderBy(x => x.Type).ToArray();
                    var topBoardCard = orderedBoard[orderedBoard.Length - 1];
                    var minBoardCard = orderedBoard[0];
                    var smallBoardCards = new List<Card>();
                    var middleBoardCards = new List<Card>();

                    if (board.Count == 5)
                    {
                        smallBoardCards.Add(orderedBoard[0]);
                        smallBoardCards.Add(orderedBoard[1]);
                        middleBoardCards.Add(orderedBoard[2]);
                        middleBoardCards.Add(orderedBoard[3]);
                    }

                    if (board.Count == 4)
                    {
                        smallBoardCards.Add(orderedBoard[0]);
                        smallBoardCards.Add(orderedBoard[1]);
                        middleBoardCards.Add(orderedBoard[2]);
                    }

                    if (board.Count == 3)
                    {
                        smallBoardCards.Add(orderedBoard[0]);
                        middleBoardCards.Add(orderedBoard[1]);
                    }

                    var kickerType = OnePairKickerTypeRecognition(firstCard, secondCard, board);

                    if (boardType == BoardType.NotVeryWet)
                    {
                        if (topBoardCard.Type == pairCard.Type) // top pair power
                        {
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.TopOnePairOnNotVeryWetBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.TopOnePairOnNotVeryWetBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.TopOnePairOnNotVeryWetBoardWithMiddleKicker;
                            }
                        }

                        if (smallBoardCards.Any(c => c.Type == pairCard.Type)) // small pair power
                        {
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.SmallOnePairOnNotVeryWetBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.SmallOnePairOnNotVeryWetBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.SmallOnePairOnNotVeryWetBoardWithMiddleKicker;
                            }
                        }
                        else
                        {
                            // middle pair power
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithMiddleKicker;
                            }
                        }
                    }

                    if (boardType == BoardType.Dry)
                    {
                        if (topBoardCard.Type == pairCard.Type) // top pair power
                        {
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.TopOnePairOnDryBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.TopOnePairOnDryBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.TopOnePairOnDryBoardWithMiddleKicker;
                            }
                        }

                        if (smallBoardCards.Any(c => c.Type == pairCard.Type)) // small pair power
                        {
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.SmallOnePairOnDryBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.SmallOnePairOnDryBoardWithMiddleKicker;
                            }
                        }
                        else
                        {
                            // middle pair power
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.MiddleOnePairOnDryBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.MiddleOnePairOnDryBoardWithMiddleKicker;
                            }
                        }
                    }
                    else
                    {
                        if (topBoardCard.Type == pairCard.Type) // top pair power
                        {
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.TopOnePairOnWetBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.TopOnePairOnWetBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.TopOnePairOnWetBoardWithMiddleKicker;
                            }
                        }

                        if (smallBoardCards.Any(c => c.Type == pairCard.Type)) // small pair power
                        {
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.SmallOnePairOnWetBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.SmallOnePairOnWetBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.SmallOnePairOnWetBoardWithMiddleKicker;
                            }
                        }
                        else
                        {
                            // middle pair power
                            if (kickerType == KickerType.TopKicker)
                            {
                                return HandStrengthType.MiddleOnePairOnWetBoardWithTopKicker;
                            }

                            if (kickerType == KickerType.SmallKicker)
                            {
                                return HandStrengthType.MiddleOnePairOnWetBoardWithSmallKicker;
                            }
                            else
                            {
                                // middle kicker
                                return HandStrengthType.MiddleOnePairOnWetBoardWithMiddleKicker;
                            }
                        }
                    }
                }
            }

            throw new ArgumentException("One pair");
        }

        private static int FindLongestIncreasingSequenceLength(HashSet<int> cardsType)
        {
            if (cardsType.Any(x => x == 14))
            {
                cardsType.Add(1);
            }

            var sortedArr = cardsType.OrderBy(x => x).ToArray();
            int currentLongSequenceLenght = 1;
            int maxLongSequenceLenght = 1;

            for (int i = 1; i < sortedArr.Count(); i++)
            {
                if (sortedArr[i] == sortedArr[i - 1] + 1)
                {
                    currentLongSequenceLenght++;
                }
                else
                {
                    currentLongSequenceLenght = 1;
                    continue;
                }

                if (maxLongSequenceLenght < currentLongSequenceLenght)
                {
                    maxLongSequenceLenght = currentLongSequenceLenght;
                }
            }

            return maxLongSequenceLenght;
        }

        private static ICollection<CardType> GetStraightCards(int[] cardTypeCounts)
        {
            var lastCardType = cardTypeCounts.Length;
            var straightLength = 0;
            for (var i = cardTypeCounts.Length - 1; i >= 1; i--)
            {
                var hasCardsOfType = cardTypeCounts[i] > 0 || (i == 1 && cardTypeCounts[(int)CardType.Ace] > 0);
                if (hasCardsOfType && i == lastCardType - 1)
                {
                    straightLength++;
                    if (straightLength == ComparableCards)
                    {
                        var bestStraight = new List<CardType>(ComparableCards);
                        for (var j = i; j <= i + ComparableCards - 1; j++)
                        {
                            if (j == 1)
                            {
                                bestStraight.Add(CardType.Ace);
                            }
                            else
                            {
                                bestStraight.Add((CardType)j);
                            }
                        }

                        return bestStraight;
                    }
                }
                else
                {
                    straightLength = 0;
                }

                lastCardType = i;
            }

            return null;
        }

        private static BoardType BoardTypeRecognition(IReadOnlyCollection<Card> board)
        { // used for trips, one pair and two pairs board.
            bool haveFourSuitedCardsOnTheBoard = board.Any(x => board.Count(y => y.Suit == x.Suit) == 4);
            bool haveThreeSuitedCardsOnTheBoard = board.Any(x => board.Count(y => y.Suit == x.Suit) == 3);

            var cardsType = new HashSet<int>();
            foreach (var card in board)
            {
                cardsType.Add((int)card.Type);
            }

            int longIncreasingSequenceLength = FindLongestIncreasingSequenceLength(cardsType);

            if (longIncreasingSequenceLength == 4 || haveFourSuitedCardsOnTheBoard)
            {
                return BoardType.Wet;
            }

            if (longIncreasingSequenceLength == 3 || haveThreeSuitedCardsOnTheBoard)
            {
                return BoardType.NotVeryWet;
            }

            return BoardType.Dry;
        }

        private static KickerType OnePairKickerTypeRecognition(Card firstCard, Card secondCard, IReadOnlyCollection<Card> board)
        {
            var pairCard = board.FirstOrDefault(c => c.Type == firstCard.Type || c.Type == secondCard.Type);
            var minCardWithoutPairCard = board.Where(c => c.Type != pairCard.Type).Min(x => x.Type);
            var minBoardKickerCardType = board.Where(c => c.Type != pairCard.Type && c.Type != minCardWithoutPairCard).Min(x => x.Type);
            var myKickerCard = pairCard.Type == firstCard.Type ? secondCard : firstCard;
            var allCardTypes = new List<CardType>
                    {
                        CardType.Two, CardType.Three, CardType.Four, CardType.Five, CardType.Six, CardType.Seven,
                        CardType.Eight, CardType.Nine, CardType.Ten, CardType.Jack, CardType.Queen, CardType.King, CardType.Ace
                    };

            foreach (var card in board)
            {
                allCardTypes.Remove(card.Type);
            }

            allCardTypes.RemoveAll(c => c < minBoardKickerCardType);
            int indexOfMyBestCard = allCardTypes.IndexOf(myKickerCard.Type);

            if (indexOfMyBestCard == allCardTypes.Count - 1)
            {
                return KickerType.TopKicker;
            }

            if (indexOfMyBestCard < (allCardTypes.Count / 2))
            {
                return KickerType.SmallKicker;
            }

            return KickerType.MiddleKicker;
        }
    }
}
