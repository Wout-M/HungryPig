using Fluxor;
using HungryPig.Store.SymbGameUseCase.Actions;

namespace HungryPig.Store.SymbGameUseCase
{
    public class SymbGameReducers
    {
        [ReducerMethod]
        public static SymbGameState InitSymbGameAction(SymbGameState state, InitSymbGameResultAction action) => new SymbGameState(action.Game);

        [ReducerMethod]
        public static SymbGameState UpdateSymbTutorialLevelAction(SymbGameState state, UpdateSymbTutorialLevelAction action)
        {
            var game = state.Game;
            if (action.First)
                game.TutorialLevel1 = action.TutorialLevel;
            else
                game.TutorialLevel2 = action.TutorialLevel;

            return new SymbGameState(game);
        }

        [ReducerMethod]
        public static SymbGameState UpdateSymbLevelAction(SymbGameState state, UpdateSymbLevelAction action)
        {
            var game = state.Game;
            
            game.Levels[game.CurrentLevelId] = action.Level;
            game.CurrentLevelId++;

            return new SymbGameState(game);
        }
    }
}
