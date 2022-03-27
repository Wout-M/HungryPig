using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.SymbGameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages._non_symbolic
{
    partial class Pause
    {
        [Inject] private IState<SymbGameState> GameState { get; set; }

        private SymbMode Mode { get; set; } = SymbMode.Pig;

        private string Description
        {
            get
            {
                return Mode == SymbMode.Pig
                    ? "Wauw, jij hebt al veel eten voor mij verzameld! Laten we even een pauze nemen en zo meteen verder gaan."
                    : "Wauw, jij hebt al veel cijfers voor mij verzameld! Laten we even een pauze nemen en zo meteen verder gaan.";
            }
        }


        protected override void OnInitialized()
        {
            Mode = GameState.Value.Game.Mode;
        }
    }
}