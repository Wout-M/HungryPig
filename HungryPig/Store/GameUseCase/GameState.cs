using Fluxor;
using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase
{
    [FeatureState]
    public class GameState
    {
        public SymbGame Game { get; }

        private GameState() { }

        public GameState(SymbGame game)
        {
            Game = game;
        }
    }
}
