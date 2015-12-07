namespace HandEvaluate
{
    public enum HandStrengthType
    {
        // TODO:
        // High card and draws
        HighCard = 10,
        TopHighCard = 20,
        StraightDraw = 30,
        FlushDraw = 40,
        StraighAndFlushDraw = 50,

        // One pair
        OnePairOnDryBoardWithoutMyCards = 700, // Ts4s7cAcTd || 3s2d
        OnePairOnNotVeryWetBoardWithoutMyCards = 800, // Ts4s7sAcTd || 3s2d
        OnePairOnWetBoardWithoutMyCards = 900, // Ts4s7sAsTd || 3h2d
        OnePairOnDryBoardWithSamllImprovedKicker = 1000, // Ts4s7cAcTd || 3h9d
        OnePairOnDryBoardWithBigImprovedKicker = 1100, // Ts4s7cAcTd || 3hJd
        OnePairOnNotVeryWetBoardWithSamllImprovedKicker = 1200,
        OnePairOnNotVeryWetBoardWithBigImprovedKicker = 1300,
        OnePairOnWetBoardWithSamllImprovedKicker = 1400,
        OnePairOnWetBoardWithBigImprovedKicker = 1500,
        SmallOnePairOnDryBoardWithSmallKicker = 1600,
        SmallOnePairOnDryBoardWithMiddleKicker = 1700,
        SmallOnePairOnDryBoardWithTopKicker = 1800,
        SmallOnePairOnNotVeryWetBoardWithSmallKicker = 1900,
        SmallOnePairOnNotVeryWetBoardWithMiddleKicker = 2000,
        SmallOnePairOnNotVeryWetBoardWithTopKicker = 2100,
        SmallOnePairOnWetBoardWithSmallKicker = 2200,
        SmallOnePairOnWetBoardWithMiddleKicker = 2300,
        SmallOnePairOnWetBoardWithTopKicker = 2400,
        MiddleOnePairOnDryBoardWithSmallKicker = 2500,
        MiddleOnePairOnDryBoardWithMiddleKicker = 2600,
        MiddleOnePairOnDryBoardWithTopKicker = 2700,
        MiddleOnePairOnNotVeryWetBoardWithSmallKicker = 2800,
        MiddleOnePairOnNotVeryWetBoardWithMiddleKicker = 2900,
        MiddleOnePairOnNotVeryWetBoardWithTopKicker = 3000,
        MiddleOnePairOnWetBoardWithSmallKicker = 3100,
        MiddleOnePairOnWetBoardWithMiddleKicker = 3200,
        MiddleOnePairOnWetBoardWithTopKicker = 3300,
        TopOnePairOnDryBoardWithSmallKicker = 3400,
        TopOnePairOnDryBoardWithMiddleKicker = 3500,
        TopOnePairOnDryBoardWithTopKicker = 3600,
        TopOnePairOnNotVeryWetBoardWithSmallKicker = 3700,
        TopOnePairOnNotVeryWetBoardWithMiddleKicker = 3800,
        TopOnePairOnNotVeryWetBoardWithTopKicker = 3900,
        TopOnePairOnWetBoardWithSmallKicker = 4000,
        TopOnePairOnWetBoardWithMiddleKicker = 4100,
        TopOnePairOnWetBoardWithTopKicker = 4200,
        OverPairOnDryBoard = 4300,
        OverPairOnNotVeryWetBoard = 4400,
        OverPairOnWetBoard = 4500,

        // Two pairs
        TwoPairsWithoutMyCards = 4600,
        TwoPairsImprovedToTopKicker = 4700,
        TwoPairsImprovedKicker = 4800,
        TwoPairsWithTopKickerWitoutMyCards = 4900,
        TwoPairsImprovedWithOverPair = 5000,
        TwoPairsOnePairOnDryBoardAndSmallestPairWithMyCard = 5100,
        TwoPairsOnePairOnDryBoardAndMiddlePairWithMyCard = 5200,
        TwoPairsOnePairOnDryBoardAndTopPairWithMyCard = 5300,
        TwoPairsOnePairOnDryBoardAndOverPairWithMyCards = 5400,
        TwoPairsOnePairOnWetBoardAndSmallestPairWithMyCard = 5500,
        TwoPairsOnePairOnWetBoardAndMiddlePairWithMyCard = 5600,
        TwoPairsOnePairOnWetBoardAndTopPairWithMyCard = 5700,
        TwoPairsOnePairOnWetBoardAndOverPairWithMyCards = 5800,
        TwoPairsOnePairOnNotVeryWetBoardAndSmallestPairWithMyCard = 5900,
        TwoPairsOnePairOnNotVeryWetBoardAndMiddlePairWithMyCard = 6000,
        TwoPairsOnePairOnNotVeryWetBoardAndTopPairWithMyCard = 6100,
        TwoPairsOnePairOnNotVeryWetBoardAndOverPairWithMyCards = 6200,
        TwoPairsWithoutPairsOnDryBoard = 6300,
        TwoPairsWithoutPairsOnNotVeryWetBoard = 6400,
        TwoPairsWithoutPairsOnWetBoard = 6500,

        // Three of a kind
        TripsOnTheBoard = 6600,
        TripsWithDryBoard = 6700,
        TripsWithNotVeryWetBoard = 6800,
        TripsWithWetBoard = 6900,
        SetOnDryBoard = 7000, // Q45TK-44 or 8s6sAcKc3h || 3c3s
        SetOnNotVeryWetBoard = 7100, // 345TK-44 or 8s6sAsKc3h || 3c3s
        SetOnWetBoard = 7200, // 3456K-44 or 8s6sAsKs3h || 3c3c

        // Straights
        StraightOnTheBoardWithoutMyCardsOnDryBoard = 7300,
        StraightOnTheBoardWithoutMyCardsOnWetBoard = 7400,
        StraightWithOneMyLowerCardOnDryBoard = 7500,
        StraightWithOneMyLowerCardOnWetBoard = 7600,
        StraightWithOneMyHighCardOnDryBoard = 7700,
        StraightWithOneMyHighCardOnWetBoard = 7800,
        StraightWithOneMyMiddleCardOnDryBoard = 7900,
        StraightWithOneMyMiddleCardOnWetBoard = 8000,
        StraightWithTwoMyCardsOnDryBoard = 8100,
        StraightWithTwoMyCardsOnWetBoard = 8200,

        // Flushes
        FlushOnTheBoardWithoutMyCards = 8300, // 3s-4s-5s-Ts-Js || 5c6c  or  // 8s-9s-5s-Ts-Js || 4s3s
        FlushOnTheBoardLittleImproved = 8400, // 3s-4s-5s-Ts-Js || 5c7s
        FlushOnTheBoardMiddleImproved = 8500, // 3s-4s-5s-Ts-Js || 5cQs
        FlushOnTheBoardImprovedToTop = 8600,  // As-4s-5s-Ts-Js || 5cKs
        TopFlushWithFourSuitedCardsOnTheBoard = 8700, // 3s-4s-5s-Ts-Jd || 5cAs
        MiddleFlushWithFourSuitedCardsOnTheBoard = 8800, // 3s-4s-5s-Ts-Jd || 5cKs
        SmallFlushWithFourSuitedCardsOnTheBoard = 8900, // 3s-4s-5s-Ts-Jd || 5c8s
        SmallFlushWithThreeSuitedCardsOnDryBoard = 9000, // 3s-4s-5s-Td-Jd || Ts8s
        BigFlushWithThreeSuitedCardsOnDryBoard = 9100, // Ks-4s-5s-Td-Tc || Js8s
        FlushWithThreeSuitedCardsOnWetBoard = 9200, // 3s-5c-5s-Td-Ts || Js8s

        // Full houses
        FullHouseWithoutMyCards = 9300, // 77999-A3 or 77999-A7 or KK333-58 or 333KK-55
        FullHouseImprovedTrips = 9400, // TTTJJ-JQ
        FullHouseImprovedPair = 9500, // TTTJJ-QQ
        FullHouseTripsOnTheBoardAndOverPair = 9600, // AAA28-99
        FullHouseTripsOnTheBoardReplacedWithBetter = 9700, // 33348-44
        FullHouseTripsOnTheBoardAndOneMyCardForBestPair = 9800, // 88843-T4
        FullHouseTripsOnTheBoardAndOneMyCardForSmallPair = 9900, // 88843-T3 or 88864-55 or 888T4-22 or 888T4-44
        FullHouseTwoPairsOnTheBoardAndOneMyCardForBestTrips = 10000, // 88TT4-TK or 88TT4-8T
        FullHouseTwoPairsOnTheBoardAndOneMyCardForSmallTrips = 10100, // 55339-34
        FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeBestSet = 10200, // 55339-99
        FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeMiddleSet = 10300, // 55334-44
        FullHouseTwoPairsOnTheBoardWithPairInMyHandWhichMakeSmallestSet = 10400, // 55332-22
        FullHouseWithOnePairOnTheTable = 10500, // 445T6-4T

        // Four of a kinds
        FourOfAKindWithoutMyCards = 10600, // JJJJT-42
        FourOfAKindWithMyCards = 10700, // 335A9-33 or 333KJ-38
        FourOfAKindImprovedKicker = 10800, // 88889-3T
        FourOfAKindImprovedToTopKicker = 10900, // 9999K-A2 or AAAA5-K7
        FourOfAkindWithTopKickerWithoutMyCards = 11000, // 9999A-75 or AAAAK-QJ

        StraightFlush = 11100,
    }
}
