namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using AI.ErisHU;
    using TexasHoldem.Logic.Players;

    public class ErisVsErisGameSimulator : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new BaseStrategyPlayer();
        private readonly IPlayer secondPlayer = new BaseStrategyPlayer();

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
