using Fluxor;
using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase
{
    [FeatureState]
    public class GameState
    {
        public Game Game { get; }

        private GameState() { }

        public GameState(Game game)
        {
            Game = game;
        }
    }
}
