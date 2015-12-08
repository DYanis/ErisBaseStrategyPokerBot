namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using AI.DummyPlayer;
    using AI.ErisHU;
    using TexasHoldem.Logic.Players;

    public class ErisVsAllwayRiseGameSimulatior : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new BaseStrategyPlayer();
        private readonly IPlayer secondPlayer = new AlwaysRaiseDummyPlayer();

        protected override IPlayer GetFirstPlayer()
        {
            return this.firstPlayer;
        }

        protected override IPlayer GetSecondPlayer()
        {
            return this.secondPlayer;
        }
    }
}
