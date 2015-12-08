namespace TexasHoldem.HandEvaluate.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Cards;

    [TestClass]
    public class FourOfAKindSubTypeRecognitionTests
    {
        [TestMethod]
        public void TestWithFourOfAKindWithoutMyCards()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Four);

            var card1 = new Card(CardSuit.Club, CardType.Five);
            var card2 = new Card(CardSuit.Heart, CardType.Five);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FourOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FourOfAKindWithoutMyCards, result);
        }

        [TestMethod]
        public void TestWithFourOfAKindImprovedKicker()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Five);
            var card2 = new Card(CardSuit.Heart, CardType.Five);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FourOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FourOfAKindImprovedKicker, result);
        }

        [TestMethod]
        public void TestWithFourOfAKindImprovedToTopKickerAce()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Ace);

            var card1 = new Card(CardSuit.Club, CardType.Five);
            var card2 = new Card(CardSuit.Heart, CardType.Five);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FourOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FourOfAKindImprovedToTopKicker, result);
        }

        [TestMethod]
        public void TestWithFourOfAKindImprovedToTopKickerrKing()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Two);
            var card4 = new Card(CardSuit.Spade, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FourOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FourOfAKindImprovedToTopKicker, result);
        }

        [TestMethod]
        public void TestWithFourOfAkindWithTopKickerWithoutMyCardsWithKickerAce()
        {
            var myFirstCard = new Card(CardSuit.Club, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Five);
            var card2 = new Card(CardSuit.Heart, CardType.Five);
            var card3 = new Card(CardSuit.Diamond, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Five);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FourOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FourOfAkindWithTopKickerWithoutMyCards, result);
        }

        [TestMethod]
        public void TestWithFourOfAkindWithTopKickerWithoutMyCardsWithKickerKing()
        {
            var myFirstCard = new Card(CardSuit.Heart, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Club, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Ace);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FourOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FourOfAkindWithTopKickerWithoutMyCards, result);
        }

        [TestMethod]
        public void TestWithFourOfAKindWithMyCardsWithOneMyCard()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Two);
            var mySecondCard = new Card(CardSuit.Club, CardType.Eight);

            var card1 = new Card(CardSuit.Club, CardType.Two);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Heart, CardType.Two);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FourOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FourOfAKindWithMyCards, result);
        }

        [TestMethod]
        public void TestWithFourOfAKindWithMyCardsWithTwoMyCards()
        {
            var myFirstCard = new Card(CardSuit.Spade, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Club, CardType.Eight);

            var card1 = new Card(CardSuit.Club, CardType.Jack);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Heart, CardType.Eight);
            var card4 = new Card(CardSuit.Spade, CardType.King);
            var card5 = new Card(CardSuit.Diamond, CardType.Eight);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.FourOfAKindSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.FourOfAKindWithMyCards, result);
        }
    }
}
