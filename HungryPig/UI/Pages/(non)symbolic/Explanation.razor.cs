using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.SymbGameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages._non_symbolic
{
    partial class Explanation
    {
        [Inject] private IState<SymbGameState> GameState { get; set; }

        private SymbMode Mode { get; set; } = SymbMode.Pig;
        private bool ShowStep2 { get; set; }
        
        private string Description
        {
            get
            {
                return Mode == SymbMode.Pig
                    ? "Zo meteen ga je aan 2 kanten bolletjes te zien krijgen. Het is de bedoeling dat jij zo snel mogelijk de kant (links of rechts) aanklikt met het meeste bolletjes. Zo kan je mij helpen en zo veel mogelijk eten voor mij verzamelen! Eerst zullen we enkele keren oefenen"
                    : "Zo meteen ga je aan 2 kanten cijfers te zien krijgen. Het is de bedoeling dat jij zo snel mogelijk de kant (links of rechts) aanklikt met het grootste cijfer. Dit betekent het cijfer met de meeste waarde. Zo kan je mij helpen en zo veel mogelijk cijfers voor mij verzamelen! Eerst zullen we enkele keren oefenen";
            }
        }
        private string DescriptionStep1 { get; } = "Hier zie je alle cijfers op volgorde van kleinste of minste waarde tot grootste of meeste waarde. Ken jij al deze cijfers?";


        protected override void OnInitialized()
        {
            Mode = GameState.Value.Game.Mode;
            ShowStep2 = Mode == SymbMode.Pig ? true : false;
        }
    }
}
