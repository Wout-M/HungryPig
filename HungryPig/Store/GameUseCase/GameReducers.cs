using Fluxor;
using HungryPig.Store.GameUseCase.Actions;

namespace HungryPig.Store.GameUseCase
{
    public class GameReducers
    {
        [ReducerMethod]
        public static GameState InitGameAction(GameState state, InitGameResultAction action) => new GameState(action.Game);
    }
}
