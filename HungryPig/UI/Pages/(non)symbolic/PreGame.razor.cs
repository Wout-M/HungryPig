using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.SymbGameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages._non_symbolic
{
    partial class PreGame
    {
        [Inject] private IState<SymbGameState> GameState { get; set; }

        private SymbMode Mode { get; set; } = SymbMode.Pig;

        private string Description
        {
            get
            {
                return Mode == SymbMode.Pig
                    ? "Dit waren alle oefenitems, nu is het voor echt. Help jij mij zo veel mogelijk eten te verzamelen door telkens de kant met het meeste bolletjes aan te duiden?"
                    : "Dit waren alle oefenitems, nu is het voor echt. Help jij mij zo veel mogelijk cijfers te verzamelen door telkens de kant met het cijfer dat het meeste is aan te duiden?";
            }
        }


        protected override void OnInitialized()
        {
            Mode = GameState.Value.Game.Mode;
        }
    }
}
