namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using AI.ErisHU;
    using AI.TestPlayers.DummyPlayer;
    using TexasHoldem.Logic.Players;

    public class ErisVsAlwaysCallPlayerSimulator : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new BaseStrategyPlayer();
        private readonly IPlayer secondPlayer = new AlwaysCallDummyPlayer();

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
