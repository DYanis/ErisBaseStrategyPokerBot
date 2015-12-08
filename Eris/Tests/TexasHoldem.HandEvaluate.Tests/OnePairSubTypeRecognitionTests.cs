namespace TexasHoldem.HandEvaluate.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Cards;

    [TestClass]
    public class OnePairSubTypeRecognitionTests
    {
        // Without my cards
        [TestMethod]
        public void TestOnePairOnDryBoardWithoutMyCards()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Two);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Spade, CardType.Four);
            var card3 = new Card(CardSuit.Club, CardType.Seven);
            var card4 = new Card(CardSuit.Club, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnDryBoardWithoutMyCards, result);
        }

        [TestMethod]
        public void TestOnePairOnNotVeryWetBoardWithoutMyCardsWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.King);
            var card3 = new Card(CardSuit.Club, CardType.Jack);
            var card4 = new Card(CardSuit.Club, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnNotVeryWetBoardWithoutMyCards, result);
        }

        [TestMethod]
        public void TestOnePairOnNotVeryWetBoardWithoutMyCardsWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.King);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Club, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnNotVeryWetBoardWithoutMyCards, result);
        }

        [TestMethod]
        public void TestOnePairOnWetBoardWithoutMyCardsWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.King);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Club, CardType.Nine);
            var card5 = new Card(CardSuit.Club, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnWetBoardWithoutMyCards, result);
        }

        [TestMethod]
        public void TestOnePairOnWetBoardWithoutMyCardsWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Heart, CardType.Queen);
            var card2 = new Card(CardSuit.Club, CardType.Jack);
            var card3 = new Card(CardSuit.Spade, CardType.Queen);
            var card4 = new Card(CardSuit.Club, CardType.Nine);
            var card5 = new Card(CardSuit.Club, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnWetBoardWithoutMyCards, result);
        }

        // improved kicker
        [TestMethod]
        public void TestOnePairOnDryBoardWithSamllImprovedKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Spade, CardType.Four);
            var card3 = new Card(CardSuit.Club, CardType.Seven);
            var card4 = new Card(CardSuit.Club, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnDryBoardWithSamllImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnDryBoardWithBigImprovedKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Spade, CardType.Four);
            var card3 = new Card(CardSuit.Club, CardType.Seven);
            var card4 = new Card(CardSuit.Club, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnDryBoardWithBigImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnNotVeryWetBoardWithSamllImprovedKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Club, CardType.King);
            var card4 = new Card(CardSuit.Club, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnNotVeryWetBoardWithSamllImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnNotVeryWetBoardWithSamllImprovedKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Club, CardType.Jack);
            var card4 = new Card(CardSuit.Diamond, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnNotVeryWetBoardWithSamllImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnNotVeryWetBoardWithBigImprovedKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Queen);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Ten);
            var card2 = new Card(CardSuit.Club, CardType.Nine);
            var card3 = new Card(CardSuit.Club, CardType.King);
            var card4 = new Card(CardSuit.Club, CardType.Ace);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnNotVeryWetBoardWithBigImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnNotVeryWetBoardWithBigImprovedKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Jack);
            var card3 = new Card(CardSuit.Club, CardType.King);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnNotVeryWetBoardWithBigImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnWetBoardWithSamllImprovedKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Jack);
            var card3 = new Card(CardSuit.Club, CardType.King);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnWetBoardWithSamllImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnWetBoardWithSamllImprovedKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Five);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnWetBoardWithSamllImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnWetBoardWithBigImprovedKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Five);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnWetBoardWithBigImprovedKicker, result);
        }

        [TestMethod]
        public void TestOnePairOnWetBoardWithBigImprovedKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Six);
            var card3 = new Card(CardSuit.Club, CardType.Five);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Four);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OnePairOnWetBoardWithBigImprovedKicker, result);
        }

        // over pair
        [TestMethod]
        public void TestOverPairOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Nine);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OverPairOnDryBoard, result);
        }

        [TestMethod]
        public void TestOverPairOnNotVeryWetBoardWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Nine);
            var card4 = new Card(CardSuit.Diamond, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OverPairOnNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestOverPairOnNotVeryWetBoardWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ten);

            var card1 = new Card(CardSuit.Club, CardType.Two);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Nine);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OverPairOnNotVeryWetBoard, result);
        }

        [TestMethod]
        public void TestOverPairOnWetBoardWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ten);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Nine);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Five);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OverPairOnWetBoard, result);
        }

        [TestMethod]
        public void TestOverPairOnWetBoardWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Heart, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Heart, CardType.Nine);
            var card4 = new Card(CardSuit.Heart, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.OverPairOnWetBoard, result);
        }

        [TestMethod]
        public void TestAreNotEqualOverPairOnDryBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Queen);
            var card2 = new Card(CardSuit.Heart, CardType.Six);
            var card3 = new Card(CardSuit.Diamond, CardType.Nine);
            var card4 = new Card(CardSuit.Club, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Ten);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreNotEqual(HandStrengthType.OverPairOnDryBoard, result);
        }

        // small pair with pair in my hand
        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithSmallKickerWithPairInMyHand()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Five);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Five);

            var card1 = new Card(CardSuit.Heart, CardType.Seven);
            var card2 = new Card(CardSuit.Diamond, CardType.Six);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnNotVeryWetBoardWithSmallKickerWithPairInMyHandAndThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Six);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Six);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Diamond, CardType.King);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnNotVeryWetBoardWithSmallKickerWithPairInMyHandAndThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Six);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Six);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Spade, CardType.King);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnWetBoardWithSmallKickerWithPairInMyHandAndFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Diamond, CardType.Eight);
            var card2 = new Card(CardSuit.Spade, CardType.Jack);
            var card3 = new Card(CardSuit.Club, CardType.Nine);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnWetBoardWithSmallKickerWithPairInMyHandAndFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Three);

            var card1 = new Card(CardSuit.Club, CardType.Eight);
            var card2 = new Card(CardSuit.Spade, CardType.Jack);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Club, CardType.Ten);
            var card5 = new Card(CardSuit.Club, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnWetBoardWithSmallKicker, result);
        }

        // middle pair with pair in my hand
        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithSmallKickerWithPairQueensInMyHand()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Queen);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Eight);
            var card2 = new Card(CardSuit.Spade, CardType.Jack);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Diamond, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithSmallKickerWithPairKingsInMyHand()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Eight);
            var card2 = new Card(CardSuit.Spade, CardType.Jack);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Diamond, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnNotVeryWetBoardWithSmallKickerWithPairInMyHandAndThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Eight);
            var card2 = new Card(CardSuit.Club, CardType.Jack);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Diamond, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnNotVeryWetBoardWithSmallKickerWithPairInMyHandAndThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Heart, CardType.Nine);
            var card2 = new Card(CardSuit.Club, CardType.Jack);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Diamond, CardType.Ten);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnWetBoardWithSmallKickerWithPairInMyHandAndFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Heart, CardType.Nine);
            var card2 = new Card(CardSuit.Club, CardType.Three);
            var card3 = new Card(CardSuit.Club, CardType.Four);
            var card4 = new Card(CardSuit.Diamond, CardType.Two);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnWetBoardWithSmallKickerWithPairInMyHandAndFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Eight);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Four);
            var card4 = new Card(CardSuit.Heart, CardType.Two);
            var card5 = new Card(CardSuit.Heart, CardType.Ace);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnWetBoardWithSmallKicker, result);
        }

        // pair with one my card 
        // small pair
        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Four);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithSmallKickerWithTwoPotentionImprovedBoardKickers()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithSmallKickerWithThreePotentionImprovedBoardKickers()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithSmallKickerWithSmallerThanBoardCardsKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Six);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithSmallKickerWithBiggerSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ten);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestAreNotEqualSmallOnePairOnDryBoardWithSmallKickerWithOneBiggerThanSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreNotEqual(HandStrengthType.SmallOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithMiddleKickerWithMaxMiddleKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithMiddleKickerWithMinMiddleKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithTopKickerWithKickerKing()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Three);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnDryBoardWithTopKickerWithKickerAce()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Heart, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnDryBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnNotVeryWetBoardWithSmallKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Diamond, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnNotVeryWetBoardWithSmallKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Four);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnNotVeryWetBoardWithMiddleKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnNotVeryWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnNotVeryWetBoardWithMiddleKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnNotVeryWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnNotVeryWetBoardWithTopKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnNotVeryWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnNotVeryWetBoardWithTopKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Heart, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnNotVeryWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnWetBoardWithSmallKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Spade, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Heart, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnWetBoardWithSmallKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnWetBoardWithMiddleKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnWetBoardWithMiddleKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnWetBoardWithTopKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestSmallOnePairOnWetBoardWithTopKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Two);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Spade, CardType.Ten);
            var card3 = new Card(CardSuit.Spade, CardType.Three);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.SmallOnePairOnWetBoardWithTopKicker, result);
        }

        // middle pair

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithSmallKickerWithTwoPotentionImprovedBoardKickers()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Queen);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithSmallKickerWithThreePotentionImprovedBoardKickers()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithSmallKickerWithSmallerThanBoardCardsKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Six);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithSmallKickerWithBiggerSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestAreNotEqualMiddleOnePairOnDryBoardWithSmallKickerWithOneBiggerThanSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreNotEqual(HandStrengthType.MiddleOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithMiddleKickerWithMaxMiddleKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithMiddleKickerWithMinMiddleKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithTopKickerWithKickerKing()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnDryBoardWithTopKickerWithKickerAce()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Heart, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnDryBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnNotVeryWetBoardWithSmallKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Two);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ten);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Diamond, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnNotVeryWetBoardWithSmallKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Four);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnNotVeryWetBoardWithMiddleKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnNotVeryWetBoardWithMiddleKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Queen);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnNotVeryWetBoardWithTopKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnNotVeryWetBoardWithTopKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Heart, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnNotVeryWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnWetBoardWithSmallKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Spade, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Heart, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnWetBoardWithSmallKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Four);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnWetBoardWithMiddleKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Four);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnWetBoardWithMiddleKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnWetBoardWithTopKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ten);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestMiddleOnePairOnWetBoardWithTopKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Nine);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Spade, CardType.Ten);
            var card3 = new Card(CardSuit.Spade, CardType.Three);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.MiddleOnePairOnWetBoardWithTopKicker, result);
        }

        // top pair

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Queen);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Four);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithSmallKickerWithTwoPotentionImprovedBoardKickers()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Queen);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithSmallKickerWithThreePotentionImprovedBoardKickers()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Seven);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithSmallKickerWithSmallerThanBoardCardsKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Six);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Ten);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithSmallKickerWithBiggerSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Eight);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestAreNotEqualTopOnePairOnDryBoardWithSmallKickerWithOneBiggerThanSmallKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreNotEqual(HandStrengthType.TopOnePairOnDryBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithMiddleKickerWithMaxMiddleKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Queen);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithMiddleKickerWithMinMiddleKicker()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithTopKickerWithKickerKing()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Three);
            var card3 = new Card(CardSuit.Heart, CardType.Ace);
            var card4 = new Card(CardSuit.Spade, CardType.Four);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnDryBoardWithTopKickerWithKickerAce()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Club, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Heart, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnDryBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnNotVeryWetBoardWithSmallKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Two);
            var mySecondCard = new Card(CardSuit.Spade, CardType.King);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Diamond, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.King);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnNotVeryWetBoardWithSmallKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Four);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnNotVeryWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnNotVeryWetBoardWithMiddleKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Diamond, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Diamond, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnNotVeryWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnNotVeryWetBoardWithMiddleKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Jack);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Nine);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnNotVeryWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnNotVeryWetBoardWithTopKickerWithThreeSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Queen);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnNotVeryWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnNotVeryWetBoardWithTopKickerWithThreeStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.King);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Spade, CardType.Seven);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Heart, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnNotVeryWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnWetBoardWithSmallKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Seven);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Spade, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Heart, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnWetBoardWithSmallKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Nine);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnWetBoardWithSmallKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnWetBoardWithMiddleKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Club, CardType.Ace);
            var card3 = new Card(CardSuit.Club, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnWetBoardWithMiddleKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ten);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ace);

            var card1 = new Card(CardSuit.Club, CardType.Four);
            var card2 = new Card(CardSuit.Heart, CardType.Ace);
            var card3 = new Card(CardSuit.Diamond, CardType.Three);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnWetBoardWithMiddleKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnWetBoardWithTopKickerWithFourStraightCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Jack);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Heart, CardType.Ten);
            var card3 = new Card(CardSuit.Diamond, CardType.Jack);
            var card4 = new Card(CardSuit.Club, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnWetBoardWithTopKicker, result);
        }

        [TestMethod]
        public void TestTopOnePairOnWetBoardWithTopKickerWithFourSuitedCardsOnTheBoard()
        {
            var myFirstCard = new Card(CardSuit.Diamond, CardType.Ace);
            var mySecondCard = new Card(CardSuit.Spade, CardType.Ten);

            var card1 = new Card(CardSuit.Club, CardType.Nine);
            var card2 = new Card(CardSuit.Spade, CardType.Ten);
            var card3 = new Card(CardSuit.Spade, CardType.Three);
            var card4 = new Card(CardSuit.Spade, CardType.Eight);
            var card5 = new Card(CardSuit.Spade, CardType.Two);
            var board = new List<Card> { card1, card2, card3, card4, card5 };

            var result = HandEvaluator.OnePairSubTypeRecognition(myFirstCard, mySecondCard, board);

            Assert.AreEqual(HandStrengthType.TopOnePairOnWetBoardWithTopKicker, result);
        }
    }
}
