using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.GameUseCase;
using HungryPig.Store.GameUseCase.Actions;
using HungryPig.UI.Components;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace HungryPig.UI.Pages
{
    partial class Game
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IState<GameState> GameState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        private Level CurrentLevel { get; set; }
        private Mode Mode { get; set; }
        private bool NextAllowed { get; set; }
        private bool LevelSet { get; set; }
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

                Dispatcher.Dispatch(new UpdateLevelAction(CurrentLevel));

                NextAllowed = true;
                LevelSet = false;
                CurrentLevel = GameState.Value.Game.Levels[GameState.Value.Game.CurrentLevelId];
                StateHasChanged();
            }
        }

        private async Task NextClicked()
        {
            NextAllowed = false;
            if (GameState.Value.Game.CurrentLevelId == (GameState.Value.Game.Levels.Count / 2 - 1))
            {
                NavigationManager.NavigateTo("pause");
            }
            else if (GameState.Value.Game.CurrentLevelId == GameState.Value.Game.Levels.Count - 1)
            {
                NavigationManager.NavigateTo("end");
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
            await Task.Delay(1000);
            GameFieldLeft?.ResetImage();
            GameFieldRight?.ResetImage();
            StateHasChanged();

            Stopwatch.Start();
            LevelSet = true;
            
        }
    }
}
