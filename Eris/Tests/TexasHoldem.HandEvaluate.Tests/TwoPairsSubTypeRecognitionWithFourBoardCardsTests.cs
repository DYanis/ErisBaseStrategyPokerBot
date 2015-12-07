namespace TexasHoldem.HandEvaluate.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Cards;
    using System.Collections.Generic;
    using ErisHU.BaseStrategyPlayer.HandEvaluate;
    //using global::HandEvaluate;

    [TestClass]
    public class TwoPairsSubTypeRecognitionWithFourBoardCardsTests
    {
        [TestMethod]
        public void TestTwoPairsOnePairOnDryBoardAndSmallestPairWithMyCardWithFourCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Heart, CardType.Ten);
            var card2 = new Card(CardSuit.Spade, CardType.Four);
            var card3 = new Card(CardSuit.Spade, CardType.Seven);
            var card4 = new Card(CardSuit.Club, CardType.Seven);
            var board = new List<Card> { card1, card2, card3, card4 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnDryBoardAndSmallestPairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCardWithFourCardsOnTheBoardAndThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Spade, CardType.Four);
            var card3 = new Card(CardSuit.Spade, CardType.Seven);
            var card4 = new Card(CardSuit.Club, CardType.Seven);
            var board = new List<Card> { card1, card2, card3, card4 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCard, result);
        }

        [TestMethod]
        public void TestTwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCardWithFourCardsOnTheBoardAndThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Spade, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Eight);
            var card3 = new Card(CardSuit.Spade, CardType.Seven);
            var card4 = new Card(CardSuit.Club, CardType.Seven);
            var board = new List<Card> { card1, card2, card3, card4 };

            var result = HandEvaluator.TwoPairsSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCard, result);
        }
    }
}
