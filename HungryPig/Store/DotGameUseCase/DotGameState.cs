using Fluxor;
using HungryPig.Shared;

namespace HungryPig.Store.DotGameUseCase
{
    [FeatureState]
    public class DotGameState
    {
        public DotGame Game { get; }

        private DotGameState() { }

        public DotGameState(DotGame game)
        {
            Game = game;
        }
    }
}
