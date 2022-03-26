using Fluxor;
using HungryPig.Store.DotGameUseCase.Actions;

namespace HungryPig.Store.DotGameUseCase
{
    public class DotGameReducers
    {
        [ReducerMethod]
        public static DotGameState InitSymbGameAction(DotGameState state, InitDotGameResultAction action) => new DotGameState(action.Game);

        [ReducerMethod]
        public static DotGameState UpdateSymbTutorialLevelAction(DotGameState state, UpdateDotTutorialLevelAction action)
        {
            var game = state.Game;
            game.TutorialLevel = action.TutorialLevel;

            return new DotGameState(game);
        }

        [ReducerMethod]
        public static DotGameState UpdateSymbLevelAction(DotGameState state, UpdateDotLevelAction action)
        {
            var game = state.Game;
            
            game.Levels[game.CurrentLevelId] = action.Level;
            game.CurrentLevelId++;

            return new DotGameState(game);
        }
    }
}
