using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.GameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages
{
    partial class Tutorial
    {
        [Inject] private IState<GameState> GameState { get; set; }

        private Level CurrentTutorialLevel { get; set; }
        private Mode Mode { get; set; }

        protected override void OnInitialized()
        {
            Mode = GameState.Value.Game.Mode;
            CurrentTutorialLevel = GameState.Value.Game.TutorialLevel1;
        }
    }
}
