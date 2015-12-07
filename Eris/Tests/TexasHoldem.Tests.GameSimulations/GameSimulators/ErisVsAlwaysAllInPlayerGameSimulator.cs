namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using ErisHU.BaseStrategyPlayer;
    using TexasHoldem.AI.DummyPlayer;
    using TexasHoldem.Logic.Players;

    internal class ErisVsAlwaysAllInPlayerGameSimulator : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new BaseStrategyPlayer();

        private readonly IPlayer secondPlayer = new AlwaysAllInDummyPlayer();

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
