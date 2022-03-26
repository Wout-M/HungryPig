using Fluxor;
using HungryPig.Shared;

namespace HungryPig.Store.SymbGameUseCase
{
    [FeatureState]
    public class SymbGameState
    {
        public SymbGame Game { get; }

        private SymbGameState() { }

        public SymbGameState(SymbGame game)
        {
            Game = game;
        }
    }
}
