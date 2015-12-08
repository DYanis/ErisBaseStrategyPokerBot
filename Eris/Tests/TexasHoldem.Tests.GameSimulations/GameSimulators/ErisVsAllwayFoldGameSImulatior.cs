namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using AI.ErisHU;
    using AI.TestPlayers.DummyPlayer;
    using TexasHoldem.Logic.Players;

    public class ErisVsAllwayFoldGameSimulatior : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new BaseStrategyPlayer();
        private readonly IPlayer secondPlayer = new AlwaysFoldDummyPlayer();

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
