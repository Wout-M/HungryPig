﻿using Fluxor;
using HungryPig.Store.GameUseCase.Actions;

namespace HungryPig.Store.GameUseCase
{
    public class GameReducers
    {
        [ReducerMethod]
        public static GameState InitGameAction(GameState state, InitGameResultAction action) => new GameState(action.Game);

        [ReducerMethod]
        public static GameState UpdateTutorialLevelAction(GameState state, UpdateTutorialLevelAction action)
        {
            var game = state.Game;
            if (action.First)
                game.TutorialLevel1 = action.TutorialLevel;
            else
                game.TutorialLevel2 = action.TutorialLevel;

            return new GameState(game);
        }

        [ReducerMethod]
        public static GameState UpdateLevelAction(GameState state, UpdateLevelAction action)
        {
            var game = state.Game;
            
            game.Levels[game.CurrentLevelId] = action.Level;
            game.CurrentLevelId++;

            return new GameState(game);
        }
    }
}