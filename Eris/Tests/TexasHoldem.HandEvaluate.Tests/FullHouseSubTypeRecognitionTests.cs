namespace TexasHoldem.HandEvaluate.Tests
{
    using System.Collections.Generic;
    using ErisHU.BaseStrategyPlayer.HandEvaluate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Cards;
    // using global::HandEvaluate;

    [TestClass]
    public class FullHouseSubTypeRecognitionTests
    {
        [TestMethod]
        public void TestFullHouseWithoutMyCardsWithDifferentCardsInMyHand()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.King);
            var mySecondCard = new Card(CardSuit.Club, CardType.Two);

            var card1 = new Card(CardSuit.Diamond, CardType.Five);
            var card2 = new Card(CardSuit.Club, CardType.Five);
            var card3 = new Card(CardSuit.Heart, CardType.Five);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseWithoutMyCards, result);
        }

        [TestMethod]
        public void TestFullHouseWithoutMyCardsWithPairOnTheBoardCardEqualOneMyCard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.King);
            var mySecondCard = new Card(CardSuit.Club, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Club, CardType.Queen);
            var card3 = new Card(CardSuit.Heart, CardType.Nine);
            var card4 = new Card(CardSuit.Spade, CardType.Nine);
            var card5 = new Card(CardSuit.Heart, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseWithoutMyCards, result);
        }

        [TestMethod]
        public void TestFullHouseWithoutMyCardsWithSmallestPairInMyHand()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Club, CardType.Seven);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Club, CardType.Queen);
            var card3 = new Card(CardSuit.Heart, CardType.Nine);
            var card4 = new Card(CardSuit.Spade, CardType.Nine);
            var card5 = new Card(CardSuit.Heart, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseWithoutMyCards, result);
        }

        [TestMethod]
        public void TestFullHouseImprovedPair()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.King);
            var mySecondCard = new Card(CardSuit.Club, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Queen);
            var card2 = new Card(CardSuit.Club, CardType.Queen);
            var card3 = new Card(CardSuit.Heart, CardType.Nine);
            var card4 = new Card(CardSuit.Spade, CardType.Nine);
            var card5 = new Card(CardSuit.Heart, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseImprovedPair, result);
        }

        [TestMethod]
        public void TestFullHouseImprovedTrips()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Three);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Diamond, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Ten);
            var card3 = new Card(CardSuit.Heart, CardType.Jack);
            var card4 = new Card(CardSuit.Spade, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseImprovedTrips, result);
        }

        [TestMethod]
        public void TestFullHouseTripsOnTheBoardAndOverPair()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Diamond, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Ten);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Heart, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTripsOnTheBoardAndOverPair, result);
        }

        [TestMethod]
        public void TestFullHouseTripsOnTheBoardImprovedTrips()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Four);
            var mySecondCard = new Card(CardSuit.Club, CardType.Four);

            var card1 = new Card(CardSuit.Diamond, CardType.Three);
            var card2 = new Card(CardSuit.Club, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Three);
            var card5 = new Card(CardSuit.Heart, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTripsOnTheBoardReplacedWithBetter, result);
        }

        [TestMethod]
        public void TestFullHouseTripsOnTheBoardAndOneMyCardForBestPair()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Diamond, CardType.Three);
            var card2 = new Card(CardSuit.Club, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Three);
            var card4 = new Card(CardSuit.Spade, CardType.Jack);
            var card5 = new Card(CardSuit.Heart, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForBestPair, result);
        }

        [TestMethod]
        public void TestFullHouseTripsOnTheBoardAndOneMyCardForSmallPairWithSmallestBoardKickerForPair()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Club, CardType.Three);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Heart, CardType.Three);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForSmallPair, result);
        }

        [TestMethod]
        public void TestFullHouseTripsOnTheBoardAndOneMyCardForSmallPairWithMiddlePairHand()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Five);
            var mySecondCard = new Card(CardSuit.Club, CardType.Five);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Six);
            var card5 = new Card(CardSuit.Heart, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForSmallPair, result);
        }

        [TestMethod]
        public void TestFullHouseTripsOnTheBoardAndOneMyCardForSmallPairWithSmallestPairHand()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Two);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForSmallPair, result);
        }

        [TestMethod]
        public void TestFullHouseTripsOnTheBoardAndOneMyCardForSmallPairWithSmallestBoardKickerForPairWithPairInMyHand()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Four);
            var mySecondCard = new Card(CardSuit.Club, CardType.Four);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTripsOnTheBoardAndOneMyCardForSmallPair, result);
        }

        [TestMethod]
        public void TestFullHouseTwoPairsOnTheBoardAndOneMyCardForBestTrips()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ten);

            var card1 = new Card(CardSuit.Diamond, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTwoPairsOnTheBoardAndOneMyCardForBestTrips, result);
        }

        [TestMethod]
        public void TestFullHouseTwoPairsOnTheBoardAndOneMyCardForBestTripsWithCardForSmallAndBigTripsInMyHand()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ten);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTwoPairsOnTheBoardAndOneMyCardForBestTrips, result);
        }

        [TestMethod]
        public void TestFullHouseTwoPairsOnTheBoardAndOneMyCardForSmallTrips()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Club, CardType.Seven);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTwoPairsOnTheBoardAndOneMyCardForSmallTrips, result);
        }

        [TestMethod]
        public void TestFullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeBestSet()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Club, CardType.Jack);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Jack);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeBestSet, result);
        }

        [TestMethod]
        public void TestFullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeSmallestSet()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Five);
            var mySecondCard = new Card(CardSuit.Club, CardType.Five);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeSmallestSet, result);
        }

        [TestMethod]
        public void TestFullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeMiddleSet()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Club, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Eight);
            var card3 = new Card(CardSuit.Heart, CardType.Ten);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FullHouseSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeMiddleSet, result);
        }
    }
}
