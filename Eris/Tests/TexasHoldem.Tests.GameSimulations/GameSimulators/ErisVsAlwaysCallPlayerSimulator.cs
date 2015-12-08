namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using AI.DummyPlayer;
    using AI.ErisHU;
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
