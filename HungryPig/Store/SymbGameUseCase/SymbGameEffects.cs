using Fluxor;
using HungryPig.Services;
using HungryPig.Store.SymbGameUseCase.Actions;

namespace HungryPig.Store.SymbGameUseCase
{
    public class SymbGameEffects
    {
        private readonly IGameService _gameservice;

        public SymbGameEffects(IGameService gameservice)
        {
            _gameservice = gameservice;
        }

        [EffectMethod]
        public Task HandleInitSymbGameAction(InitSymbGameAction action, IDispatcher dispatcher)
        {
            var game = _gameservice.InitGame(action.Mode, action.Name, action.IsLong);
            dispatcher.Dispatch(new InitSymbGameResultAction(game));
            return Task.CompletedTask;
        }
    }
}
