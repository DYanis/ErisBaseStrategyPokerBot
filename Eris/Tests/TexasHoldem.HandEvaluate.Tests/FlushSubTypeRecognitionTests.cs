namespace TexasHoldem.HandEvaluate.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Cards;

    [TestClass]
    public class FlushSubTypeRecognitionTests
    {
        [TestMethod]
        public void TestFlushOnTheBoardWithoutMyCardsWithTwoDifferentSuitCards()
        {
            var myFirstCard = new Card(CardSuit.Heart, CardType.Two);
            var mySecondCard = new Card(CardSuit.Heart, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Six);
            var card2 = new Card(CardSuit.Diamond, CardType.Eight);
            var card3 = new Card(CardSuit.Diamond, CardType.Ten);
            var card4 = new Card(CardSuit.Diamond, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardWithoutMyCards, result);
        }

        [TestMethod]
        public void TestFlushOnTheBoardWithoutMyCardsWithOneSameSuitCardSmallerThanOther()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Queen);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Six);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardWithoutMyCards, result);
        }

        [TestMethod]
        public void TestFlushOnTheBoardWithoutMyCardsWithTwoSameSuitCardsSmallerThanOther()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Six);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardWithoutMyCards, result);
        }

        [TestMethod]
        public void TestFlushOnTheBoardImprovedToTopWithAce()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Six);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardImprovedToTop, result);
        }

        [TestMethod]
        public void TestFlushOnTheBoardImprovedToTopWithQueen()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Queen);
            var mySecondCard = new Card(CardSuit.Diamond, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Six);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ace);
            var card5 = new Card(CardSuit.Spade, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardImprovedToTop, result);
        }

        [TestMethod]
        public void TestFlushOnTheBoardMiddleImprovedWithKing()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Six);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Jack);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardMiddleImproved, result);
        }

        [TestMethod]
        public void TestFlushOnTheBoardMiddleImprovedWithQueen()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Queen);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Five);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Jack);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardMiddleImproved, result);
        }

        [TestMethod]
        public void FlushOnTheBoardLittleImprovedWithFive()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Spade, CardType.Three);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardLittleImproved, result);
        }

        [TestMethod]
        public void TestFlushOnTheBoardLittleImprovedWithJack()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushOnTheBoardLittleImproved, result);
        }

        [TestMethod]
        public void TestTopFlushWithFourSuitedCardsOnTheBoardWithAce()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Club, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopFlushWithFourSuitedCardsOnTheBoard, result);
        }

        [TestMethod]
        public void TestTopFlushWithFourSuitedCardsOnTheBoardWithAceWithKing()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ace);
            var card5 = new Card(CardSuit.Club, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopFlushWithFourSuitedCardsOnTheBoard, result);
        }

        [TestMethod]
        public void MiddleFlushWithFourSuitedCardsOnTheBoardWithQueen()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Club, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleFlushWithFourSuitedCardsOnTheBoard, result);
        }

        [TestMethod]
        public void TestMiddleFlushWithFourSuitedCardsOnTheBoardWithQueen()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Queen);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Club, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleFlushWithFourSuitedCardsOnTheBoard, result);
        }

        [TestMethod]
        public void TestSmallFlushWithFourSuitedCardsOnTheBoardWithSix()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Six);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Club, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallFlushWithFourSuitedCardsOnTheBoard, result);
        }

        [TestMethod]
        public void TestSmallFlushWithFourSuitedCardsOnTheBoardWithNine()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Spade, CardType.Three);
            var card3 = new Card(CardSuit.Spade, CardType.Five);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Club, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallFlushWithFourSuitedCardsOnTheBoard, result);
        }

        [TestMethod]
        public void TestFlushWithThreeSuitedCardsOnWetBoardWithTwoPairsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Diamond, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushWithThreeSuitedCardsOnWetBoard, result);
        }

        [TestMethod]
        public void TestFlushWithThreeSuitedCardsOnWetBoardWithTripsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Diamond, CardType.Nine);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FlushWithThreeSuitedCardsOnWetBoard, result);
        }

        [TestMethod]
        public void TestBigFlushWithThreeSuitedCardsOnDryBoardWithAllDifferentCardsOnTheBoardWithQueen()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Diamond, CardType.Three);
            var card5 = new Card(CardSuit.Spade, CardType.Six);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.BigFlushWithThreeSuitedCardsOnDryBoard, result);
        }

        [TestMethod]
        public void TestBigFlushWithThreeSuitedCardsOnDryBoardWithOnePairOnTheBoardWithJack()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.King);
            var card2 = new Card(CardSuit.Club, CardType.Four);
            var card3 = new Card(CardSuit.Club, CardType.Five);
            var card4 = new Card(CardSuit.Diamond, CardType.Jack);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.BigFlushWithThreeSuitedCardsOnDryBoard, result);
        }

        [TestMethod]
        public void TestSmallFlushWithThreeSuitedCardsOnDryBoardWithSeven()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Diamond, CardType.Jack);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallFlushWithThreeSuitedCardsOnDryBoard, result);
        }

        [TestMethod]
        public void TestSmallFlushWithThreeSuitedCardsOnDryBoardWithTen()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ten);

            var card1 = new Card(CardSuit.Club, CardType.Three);
            var card2 = new Card(CardSuit.Club, CardType.Five);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Diamond, CardType.Jack);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FlushSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallFlushWithThreeSuitedCardsOnDryBoard, result);
        }
    }
}
