using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.SymbGameUseCase;
using HungryPig.Store.SymbGameUseCase.Actions;
using HungryPig.UI.Components._non_symbolic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics;

namespace HungryPig.UI.Pages._non_symbolic
{
    partial class Game
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IState<SymbGameState> GameState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        [CascadingParameter] public EventCallback<(bool Enabled, bool IsSymb)> EnableStopButton { get; set; }

        private SymbLevel CurrentLevel { get; set; }
        private SymbMode Mode { get; set; }
        private bool NextAllowed { get; set; }
        private bool LevelSet { get; set; }
        private bool LevelFinished { get; set; }
        private Stopwatch Stopwatch { get; set; } = new();

        private GameField GameFieldLeft { get; set; }
        private GameField GameFieldRight { get; set; }

        private ElementReference KeyDiv { get; set; }

        protected override async void OnInitialized()
        {
            CurrentLevel = GameState.Value.Game.Levels[GameState.Value.Game.CurrentLevelId];
            NextAllowed = false;
            Mode = GameState.Value.Game.Mode;

            await Task.Delay(100);
            await SetNewLevel();
            await EnableStopButton.InvokeAsync((true, true));
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await KeyDiv.FocusAsync();
        }

        private async void HandleKeyDown(KeyboardEventArgs e)
        {
            if (LevelSet)
            {
                switch (e.Key.ToLower())
                {
                    case "l":
                        SideSelected(CurrentLevel.Right > CurrentLevel.Left, Side.Right);
                        break;
                    case "s":
                        SideSelected(CurrentLevel.Left > CurrentLevel.Right, Side.Left);
                        break;
                    default:
                        break;
                }
            }

            if (LevelFinished && NextAllowed)
            {
                if (e.Key.ToLower() == "v")
                {
                    await NextClicked();
                }
            }
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
            if (GameState.Value.Game.CurrentLevelId == GameState.Value.Game.Levels.Count)
            {
                await EnableStopButton.InvokeAsync((false, true));
                NavigationManager.NavigateTo("symbgame/postgame");
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
