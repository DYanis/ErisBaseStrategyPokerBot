namespace TexasHoldem.HandEvaluate.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Cards;

    [TestClass]
    public class StraightSubTypeRecognitionTests
    {
        [TestMethod]
        public void TestStraightOnTheBoardWithoutMyCardsOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightOnTheBoardWithoutMyCardsOnDryBoard, result);
        }

        [TestMethod]
        public void TestStraightOnTheBoardWithoutMyCardsOnWetBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Club, CardType.Nine);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Club, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightOnTheBoardWithoutMyCardsOnWetBoard, result);
        }

        [TestMethod]
        public void TestStraightWithOneMyMiddleCardOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ten);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Nine);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Club, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightWithOneMyMiddleCardOnDryBoard, result);
        }

        [TestMethod]
        public void TestStraightWithOneMyMiddleCardOnWetBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ten);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Heart, CardType.Jack);
            var card4 = new Card(CardSuit.Club, CardType.Jack);
            var card5 = new Card(CardSuit.Club, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightWithOneMyMiddleCardOnWetBoard, result);
        }

        [TestMethod]
        public void TestStraightWithOneMyLowerCardOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ace);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Heart, CardType.Ten);
            var card4 = new Card(CardSuit.Club, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightWithOneMyLowerCardOnDryBoard, result);
        }

        [TestMethod]
        public void TestStraightWithOneMyLowerCardOnWetBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ace);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Club, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightWithOneMyLowerCardOnWetBoard, result);
        }

        [TestMethod]
        public void TestStraightWithOneMyHighCardOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Diamond, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightWithOneMyHighCardOnDryBoard, result);
        }

        [TestMethod]
        public void TestStraightWithOneMyHighCardOnWetBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Six);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Diamond, CardType.King);
            var card5 = new Card(CardSuit.Club, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightWithOneMyHighCardOnWetBoard, result);
        }

        [TestMethod]
        public void TestStraightWithTwoMyCardsOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Diamond, CardType.King);
            var card5 = new Card(CardSuit.Spade, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightWithTwoMyCardsOnDryBoard, result);
        }

        [TestMethod]
        public void TestStraightWithTwoMyCardsOnWetBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Club, CardType.Ten);
            var card4 = new Card(CardSuit.Diamond, CardType.King);
            var card5 = new Card(CardSuit.Club, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.StraightSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.StraightWithTwoMyCardsOnWetBoard, result);
        }
    }
}
