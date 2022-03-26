using Fluxor;
using HungryPig.Services;
using HungryPig.Store.DotGameUseCase.Actions;

namespace HungryPig.Store.DotGameUseCase
{
    public class DotGameEffects
    {
        private readonly IGameService _gameservice;

        public DotGameEffects(IGameService gameservice)
        {
            _gameservice = gameservice;
        }

        [EffectMethod]
        public Task HandleInitDotGameAction(InitDotGameAction action, IDispatcher dispatcher)
        {
            var game = _gameservice.InitDotGame(action.Name);
            dispatcher.Dispatch(new InitDotGameResultAction(game));
            return Task.CompletedTask;
        }
    }
}
