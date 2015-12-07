namespace TexasHoldem.HandEvaluate.Tests
{
    using System.Collections.Generic;
    using ErisHU.BaseStrategyPlayer.HandEvaluate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Cards;
    //using global::HandEvaluate;

    [TestClass]
    public class ThreeOfAKindSubTypeRecognitionTests
    {
        [TestMethod]
        public void TestSetOnNotVeryWetBoardWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Two);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Three);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SetOnNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestSetOnNotVeryWetBoardWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Jack);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Diamond, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SetOnNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestSetOnWetBoardWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Jack);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Diamond, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Ten);
            var card4 = new Card(CardSuit.Diamond, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SetOnWetBoard, result);
        }

        [TestMethod]
        public void TestSetOnWetBoardWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Club, CardType.Queen);
            var card3 = new Card(CardSuit.Spade, CardType.King);
            var card4 = new Card(CardSuit.Heart, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SetOnWetBoard, result);
        }

        [TestMethod]
        public void TestSetOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Two);
            var mySecondCard = new Card(CardSuit.Heart, CardType.Two);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Club, CardType.Four);
            var card3 = new Card(CardSuit.Spade, CardType.King);
            var card4 = new Card(CardSuit.Heart, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SetOnDryBoard, result);
        }

        [TestMethod]
        public void TestTripsWithDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Diamond, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Club, CardType.Four);
            var card3 = new Card(CardSuit.Spade, CardType.King);
            var card4 = new Card(CardSuit.Heart, CardType.King);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TripsWithDryBoard, result);
        }

        [TestMethod]
        public void TestTripsWithNotVeryWetBoardWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Diamond, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Heart, CardType.Four);
            var card3 = new Card(CardSuit.Spade, CardType.King);
            var card4 = new Card(CardSuit.Heart, CardType.King);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TripsWithNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestTripsWithNotVeryWetBoardWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Diamond, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Two);
            var card2 = new Card(CardSuit.Spade, CardType.Three);
            var card3 = new Card(CardSuit.Spade, CardType.King);
            var card4 = new Card(CardSuit.Heart, CardType.King);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TripsWithNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestTripsWithWetBoardWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Three);
            var mySecondCard = new Card(CardSuit.Diamond, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Spade, CardType.Jack);
            var card3 = new Card(CardSuit.Spade, CardType.King);
            var card4 = new Card(CardSuit.Heart, CardType.King);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TripsWithWetBoard, result);
        }

        [TestMethod]
        public void TripsWithWetBoardWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Diamond, CardType.King);

            var card1 = new Card(CardSuit.Spade, CardType.Queen);
            var card2 = new Card(CardSuit.Spade, CardType.Nine);
            var card3 = new Card(CardSuit.Spade, CardType.King);
            var card4 = new Card(CardSuit.Heart, CardType.King);
            var card5 = new Card(CardSuit.Spade, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.ThreeOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TripsWithWetBoard, result);
        }
    }
}
