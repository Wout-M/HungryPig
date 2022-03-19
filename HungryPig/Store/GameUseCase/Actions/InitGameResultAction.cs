using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase.Actions
{
    public class InitGameResultAction
    {
        public Game Game { get; }

        public InitGameResultAction(Game game)
        {
            Game = game;
        }
    }
}
