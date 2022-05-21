using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.DotGameUseCase;
using HungryPig.Store.DotGameUseCase.Actions;
using HungryPig.UI.Components.dotenum;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace HungryPig.UI.Pages.dotenum
{
    partial class DotGame
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IState<DotGameState> GameState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        [CascadingParameter] public EventCallback<(bool Enabled, bool IsSymb)> EnableStopButton { get; set; }

        private DotLevel CurrentLevel { get; set; }
        private bool NextAllowed { get; set; }
        private Stopwatch Stopwatch { get; set; } = new();

        private string ImageURL { get; } = "images/dog.png";

        private DotGameField GameField { get; set; }
        private DotSideTip DotSideTip { get; set; }

        protected override async void OnInitialized()
        {
            CurrentLevel = GameState.Value.Game.Levels[GameState.Value.Game.CurrentLevelId];
            NextAllowed = false;

            await Task.Delay(100);
            SetNewLevel();
            await EnableStopButton.InvokeAsync((true, false));
        }


        private void SideSelected()
        {
            if (!NextAllowed)
            {
                Stopwatch.Stop();
                CurrentLevel.ReactionTime = Stopwatch.ElapsedMilliseconds;

                GameField?.ResetImage();
                DotSideTip?.SetText(CurrentLevel.Color);

                Dispatcher.Dispatch(new UpdateDotLevelAction(CurrentLevel));

                NextAllowed = true;
                Stopwatch.Reset();

                if (GameState.Value.Game.CurrentLevelId < GameState.Value.Game.Levels.Count)
                    CurrentLevel = GameState.Value.Game.Levels[GameState.Value.Game.CurrentLevelId];
                StateHasChanged();
            }
        }

        private async Task NextClicked()
        {
            NextAllowed = false;
            DotSideTip?.ResetText();
            if (GameState.Value.Game.CurrentLevelId == GameState.Value.Game.Levels.Count)
            {
                await EnableStopButton.InvokeAsync((false, false));
                NavigationManager.NavigateTo("dotgame/postgame");
            }
            else
            {
                SetNewLevel();
            }
        }

        private void SetNewLevel()
        {
            GameField?.SetImage();
            Stopwatch.Start();
            StateHasChanged();
        }
    }
}
