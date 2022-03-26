using HungryPig.Shared;

namespace HungryPig.Store.SymbGameUseCase.Actions
{
    public class InitSymbGameResultAction
    {
        public SymbGame Game { get; }

        public InitSymbGameResultAction(SymbGame game)
        {
            Game = game;
        }
    }
}
