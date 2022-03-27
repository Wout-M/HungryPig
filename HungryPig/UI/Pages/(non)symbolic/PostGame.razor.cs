using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.SymbGameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages._non_symbolic
{
    partial class PostGame
    {
        [Inject] private IState<SymbGameState> GameState { get; set; }

        private SymbMode Mode { get; set; } = SymbMode.Pig;

        private string Description
        {
            get
            {
                return Mode == SymbMode.Pig
                    ? "Dat heeft gesmaakt! Heel erg bedankt dat jij zo veel eten voor mij hebt verzameld."
                    : "Kijk hoeveel cijfers je voor mij hebt verzameld! Heel erg bedankt voor je hulp.";
            }
        }


        protected override void OnInitialized()
        {
            Mode = GameState.Value.Game.Mode;
        }
    }
}
