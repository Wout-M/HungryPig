using HungryPig.Shared;

namespace HungryPig.Store.DotGameUseCase.Actions
{
    public class InitDotGameResultAction
    {
        public DotGame Game { get; }

        public InitDotGameResultAction(DotGame game)
        {
            Game = game;
        }
    }
}
