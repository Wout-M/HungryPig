using Fluxor;
using HungryPig.Store.GameUseCase.Actions;

namespace HungryPig.Store.GameUseCase
{
    public class GameReducers
    {
        [ReducerMethod()]
        public static GameState InitGameAction(InitGameResultAction action, GameState state) => new GameState(action.Game);
    }
}
