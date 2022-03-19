using Fluxor;
using HungryPig.Services;
using HungryPig.Store.GameUseCase.Actions;

namespace HungryPig.Store.GameUseCase
{
    public class GameEffects
    {
        private readonly IGameService _gameservice;

        public GameEffects(IGameService gameservice)
        {
            _gameservice = gameservice;
        }

        [EffectMethod]
        public Task HandleInitGameAction(InitGameAction action, IDispatcher dispatcher)
        {
            var game = _gameservice.InitGame(action.Mode, action.Name);
            dispatcher.Dispatch(new InitGameResultAction(game));
            return Task.CompletedTask;
        }
    }
}
