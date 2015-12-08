namespace TexasHoldem.HandEvaluate.Tests
{
    using System.Collections.Generic;

    using Logic.Cards;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TwoPairsSubTypeRecognitionWithFiveBoardCardsTests
    {
        // Two pairs on the board

        [TestMethod]
        public void TestTwoPairsWithoutMyCards()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Four);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Jack);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithoutMyCards, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedKickerWithKing()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Jack);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsImprovedKicker, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedKickerWithSix()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Six);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.King);
            var card3 = new Card(CardSuit.Diamond, CardType.King);
            var card4 = new Card(CardSuit.Spade, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsImprovedKicker, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedWithOverPairAces()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Ace);

            var card1 = new Card(CardSuit.Club, CardType.King);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Six);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsImprovedWithOverPair, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedWithOverPairSevens()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.King);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Five);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Six);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsImprovedWithOverPair, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedToTopKickerWithKickerQueen()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.King);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithTopKickerWitoutMyCards, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedToTopKickerWithKickerKing()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Five);

            var card1 = new Card(CardSuit.Club, CardType.King);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Six);
            var card4 = new Card(CardSuit.Spade, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithTopKickerWitoutMyCards, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedToTopKickerWithKickerAce()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Two);

            var card1 = new Card(CardSuit.Club, CardType.Ten);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Six);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithTopKickerWitoutMyCards, result);
        }

        [TestMethod]
        public void TestWithAreNotEqualTwoPairsImprovedToTopKickerWithKickerKing()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Two);

            var card1 = new Card(CardSuit.Club, CardType.Ten);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Six);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreNotEqual(HandStrengthType.TwoPairsWithTopKickerWitoutMyCards, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedToTopKickerAce()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ace);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Jack);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsImprovedToTopKicker, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedToTopKickerKing()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Heart, CardType.Jack);
            var card3 = new Card(CardSuit.Diamond, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsImprovedToTopKicker, result);
        }

        [TestMethod]
        public void TestTwoPairsImprovedToTopKickerQueen()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsImprovedToTopKicker, result);
        }

        [TestMethod]
        public void TestWithAreNotEqualTwoPairsImprovedToTopKickerJack()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreNotEqual(HandStrengthType.TwoPairsImprovedToTopKicker, result);
        }

        // One pair on the board

        // Smallest pair
        [TestMethod]
        public void TestTwoPairsOnePairOnDryBoardAndSmallestPairWithMyCard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Four);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Heart, CardType.Eight);
            var card3 = new Card(CardSuit.Diamond, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnDryBoardAndSmallestPairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCardWithThreeStraightCards()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Four);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Heart, CardType.Queen);
            var card3 = new Card(CardSuit.Diamond, CardType.Six);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCard, result);
        }

        [TestMethod]
        public void TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCardWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Four);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Diamond, CardType.Queen);
            var card3 = new Card(CardSuit.Diamond, CardType.Six);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCard, result);
        }

        [TestMethod]
        public void TwoPairsOnePairOnWetBoardAndSmallestPairWithMyCardWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Four);

            var card1 = new Card(CardSuit.Diamond, CardType.Nine);
            var card2 = new Card(CardSuit.Diamond, CardType.Queen);
            var card3 = new Card(CardSuit.Diamond, CardType.Six);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndSmallestPairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnWetBoardAndSmallestPairWithMyCardWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Eight);

            var card1 = new Card(CardSuit.Diamond, CardType.Nine);
            var card2 = new Card(CardSuit.Club, CardType.Ten);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Seven);
            var card5 = new Card(CardSuit.Diamond, CardType.Seven);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndSmallestPairWithMyCard, result);
        }

        // Middle pair
        [TestMethod]
        public void TestTwoPairsOnePairOnDryBoardAndMiddlePairWithMyCard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ten);

            var card1 = new Card(CardSuit.Diamond, CardType.Jack);
            var card2 = new Card(CardSuit.Club, CardType.Ten);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Three);
            var card5 = new Card(CardSuit.Diamond, CardType.Three);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnDryBoardAndMiddlePairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCardWithOnePairOnBoardAndTwoMiddlePairsWithMycards()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Six);

            var card1 = new Card(CardSuit.Diamond, CardType.Five);
            var card2 = new Card(CardSuit.Club, CardType.Five);
            var card3 = new Card(CardSuit.Heart, CardType.Ten);
            var card4 = new Card(CardSuit.Diamond, CardType.Six);
            var card5 = new Card(CardSuit.Spade, CardType.Seven);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCardWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Three);
            var card2 = new Card(CardSuit.Club, CardType.Ten);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Three);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCardWithThreeStraightCardsOnTheBoardAndThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Three);
            var card2 = new Card(CardSuit.Club, CardType.Ten);
            var card3 = new Card(CardSuit.Diamond, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Three);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnWetBoardAndMiddlePairWithMyCardWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Three);
            var card2 = new Card(CardSuit.Diamond, CardType.Ten);
            var card3 = new Card(CardSuit.Diamond, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Three);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndMiddlePairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnWetBoardAndMiddlePairWithMyCardFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Jack);
            var card2 = new Card(CardSuit.Club, CardType.Ten);
            var card3 = new Card(CardSuit.Spade, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Jack);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndMiddlePairWithMyCard, result);
        }

        // Top pair
        [TestMethod]
        public void TestTwoPairsOnePairOnDryBoardAndTopPairWithMyCard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Ace);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Spade, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Queen);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnDryBoardAndTopPairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndTopPairWithMyCardWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Ace);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Spade, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Queen);
            var card5 = new Card(CardSuit.Diamond, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndTopPairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndTopPairWithMyCardWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Ace);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Heart, CardType.Four);
            var card3 = new Card(CardSuit.Spade, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Queen);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndTopPairWithMyCard, result);
        }

        [TestMethod]
        public void TwoPairsOnePairOnWetBoardAndTopPairWithMyCardWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Seven);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Spade, CardType.Four);
            var card3 = new Card(CardSuit.Spade, CardType.Seven);
            var card4 = new Card(CardSuit.Spade, CardType.Queen);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndTopPairWithMyCard, result);
        }

        [TestMethod]
        public void TwoPairsOnePairOnWetBoardAndTopPairWithMyCardWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Seven);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Heart, CardType.Nine);
            var card3 = new Card(CardSuit.Spade, CardType.Jack);
            var card4 = new Card(CardSuit.Club, CardType.Queen);
            var card5 = new Card(CardSuit.Spade, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndTopPairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnWetBoardAndTopPairWithMyCardImprovedAndPairOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Ten);

            var card1 = new Card(CardSuit.Diamond, CardType.Ace);
            var card2 = new Card(CardSuit.Diamond, CardType.Four);
            var card3 = new Card(CardSuit.Spade, CardType.Four);
            var card4 = new Card(CardSuit.Diamond, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndTopPairWithMyCard, result);
        }

        // Over pair
        [TestMethod]
        public void TestTwoPairsOnePairOnDryBoardAndOverPairWithMyCards()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.King);
            var mySecondCard = new Card(CardSuit.Heart, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Heart, CardType.Nine);
            var card3 = new Card(CardSuit.Spade, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Queen);
            var card5 = new Card(CardSuit.Spade, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnDryBoardAndOverPairWithMyCards, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndOverPairWithMyCardsWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.King);
            var mySecondCard = new Card(CardSuit.Heart, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Spade, CardType.Nine);
            var card3 = new Card(CardSuit.Spade, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Queen);
            var card5 = new Card(CardSuit.Spade, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndOverPairWithMyCards, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndOverPairWithMyCardsWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Eight);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Five);
            var card3 = new Card(CardSuit.Club, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Seven);
            var card5 = new Card(CardSuit.Spade, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndOverPairWithMyCards, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnWetBoardAndOverPairWithMyCardsWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Ten);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Spade, CardType.Five);
            var card3 = new Card(CardSuit.Club, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Two);
            var card5 = new Card(CardSuit.Spade, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndOverPairWithMyCards, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnWetBoardAndOverPairWithMyCardsWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Diamond, CardType.Eight);
            var card3 = new Card(CardSuit.Diamond, CardType.Four);
            var card4 = new Card(CardSuit.Diamond, CardType.Six);
            var card5 = new Card(CardSuit.Spade, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndOverPairWithMyCards, result);
        }

        // Without pairs on the board

        [TestMethod]
        public void TestTwoPairsWithoutPairsOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Six);

            var card1 = new Card(CardSuit.Heart, CardType.Two);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Diamond, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.Six);
            var card5 = new Card(CardSuit.Spade, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithoutPairsOnDryBoard, result);
        }

        [TestMethod]
        public void TestTwoPairsWithoutPairsOnNotVeryWetBoardWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Six);

            var card1 = new Card(CardSuit.Heart, CardType.Two);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.Six);
            var card5 = new Card(CardSuit.Spade, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithoutPairsOnNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestTwoPairsWithoutPairsOnNotVeryWetBoardWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Six);

            var card1 = new Card(CardSuit.Heart, CardType.Five);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.Six);
            var card5 = new Card(CardSuit.Spade, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithoutPairsOnNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestTwoPairsWithoutPairsOnNotVeryWetBoardWithThreeStraightAndSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Six);

            var card1 = new Card(CardSuit.Heart, CardType.Five);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Club, CardType.Six);
            var card5 = new Card(CardSuit.Spade, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithoutPairsOnNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestTwoPairsWithoutPairsOnWetBoardWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Heart, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Five);

            var card1 = new Card(CardSuit.Heart, CardType.Five);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Club, CardType.Six);
            var card5 = new Card(CardSuit.Club, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithoutPairsOnWetBoard, result);
        }

        [TestMethod]
        public void TestTwoPairsWithoutPairsOnWetBoardWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Heart, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Heart, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Club, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsWithoutPairsOnWetBoard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnWetBoardAndSmallestPairWithMyCard()
        {
            var myFirstCard = new Card(CardSuit.Heart, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Five);

            var card1 = new Card(CardSuit.Heart, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Club, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndSmallestPairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnWetBoardAndMiddlePairWithMyCard()
        {
            var myFirstCard = new Card(CardSuit.Heart, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Six);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Club, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnWetBoardAndMiddlePairWithMyCard, result);
        }
    }
}
