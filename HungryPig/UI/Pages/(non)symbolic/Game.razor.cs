using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.SymbGameUseCase;
using HungryPig.Store.SymbGameUseCase.Actions;
using HungryPig.UI.Components._non_symbolic;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace HungryPig.UI.Pages._non_symbolic
{
    partial class Game
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IState<SymbGameState> GameState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        private SymbLevel CurrentLevel { get; set; }
        private SymbMode Mode { get; set; }
        private bool NextAllowed { get; set; }
        private bool LevelSet { get; set; }
        private bool LevelFinished { get; set; }
        private Stopwatch Stopwatch { get; set; } = new();

        private GameField GameFieldLeft { get; set; }
        private GameField GameFieldRight { get; set; }

        protected override async void OnInitialized()
        {
            CurrentLevel = GameState.Value.Game.Levels[GameState.Value.Game.CurrentLevelId];
            NextAllowed = false;
            Mode = GameState.Value.Game.Mode;

            await Task.Delay(100);
            await SetNewLevel();
        }


        private void SideSelected(bool correct, Side side)
        {
            if (LevelSet)
            {
                Stopwatch.Stop();
                var time = Stopwatch.ElapsedMilliseconds;

                CurrentLevel.SideSelected = side;
                CurrentLevel.Correct = correct;
                CurrentLevel.ReactionTime = time;

                Dispatcher.Dispatch(new UpdateSymbLevelAction(CurrentLevel));
                
                NextAllowed = true;
                LevelSet = false;
               
                Stopwatch.Reset();

                if (GameState.Value.Game.CurrentLevelId < GameState.Value.Game.Levels.Count)
                    CurrentLevel = GameState.Value.Game.Levels[GameState.Value.Game.CurrentLevelId];
                StateHasChanged();
            }
        }

        private async Task NextClicked()
        {
            NextAllowed = false;
            LevelFinished = false;
            if (GameState.Value.Game.CurrentLevelId == (GameState.Value.Game.Levels.Count / 2))
            {
                NavigationManager.NavigateTo("symbgame/pause");
            }
            else if (GameState.Value.Game.CurrentLevelId == GameState.Value.Game.Levels.Count)
            {
                NavigationManager.NavigateTo("symbgame/end");
            }
            else
            {
                await SetNewLevel();
            }
        }

        private async Task SetNewLevel()
        {
            GameFieldLeft?.SetImage();
            GameFieldRight?.SetImage();
            LevelSet = true;
            Stopwatch.Start();
            
            await Task.Delay(1000);
            GameFieldLeft?.ResetImage();
            GameFieldRight?.ResetImage();
            LevelFinished = true;
            StateHasChanged();
        }
    }
}
