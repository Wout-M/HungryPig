using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase.Actions
{
    public class InitGameResultAction
    {
        public SymbGame Game { get; }

        public InitGameResultAction(SymbGame game)
        {
            Game = game;
        }
    }
}
