using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.DotGameUseCase;
using HungryPig.Store.DotGameUseCase.Actions;
using HungryPig.UI.Components.dotenum;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace HungryPig.UI.Pages.dotenum
{
    partial class DotTutorial
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IState<DotGameState> GameState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        private DotLevel CurrentTutorialLevel { get; set; }
        private bool NextAllowed { get; set; }
        private Stopwatch Stopwatch { get; set; } = new();

        private string ImageURL { get; } = "images/dog.png";

        private DotGameField TutorialField { get; set; }
        private DotSideTip DotSideTip { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CurrentTutorialLevel = GameState.Value.Game.TutorialLevel;

            await Task.Delay(100);
            TutorialField?.SetImage();
            Stopwatch.Start();
        }

        private void SideSelected()
        {
            if (!NextAllowed)
            {
                Stopwatch.Stop();
                CurrentTutorialLevel.ReactionTime = Stopwatch.ElapsedMilliseconds;

                TutorialField?.ResetImage();
                DotSideTip?.SetText(CurrentTutorialLevel.Color); 

                Dispatcher.Dispatch(new UpdateDotTutorialLevelAction(CurrentTutorialLevel));

                NextAllowed = true;
                StateHasChanged();
            }
        }

        private void NextClicked()
        {
            NextAllowed = false;
            DotSideTip?.ResetText();
            NavigationManager.NavigateTo("dotgame/pregame");
        }
    }
}
