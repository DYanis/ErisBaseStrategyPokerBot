namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using ErisHU.BaseStrategyPlayer;
    using TexasHoldem.AI.SmartPlayer;
    using TexasHoldem.Logic.Players;

    public class ErisVsSmartPlayerGameSimulation : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new BaseStrategyPlayer();
        private readonly IPlayer secondPlayer = new SmartPlayerOld();

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
