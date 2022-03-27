using Fluxor;
using HungryPig.Helpers;
using HungryPig.Shared;
using HungryPig.Store.SymbGameUseCase.Actions;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages._non_symbolic
{
    partial class StartMenu 
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        private SymbMode Mode { get; set; } = SymbMode.Pig;
        private string Name { get; set; } = string.Empty;

        private string Title { get => Mode.GetDescription(); }
        private string ImageURL { get => Mode == SymbMode.Pig ? "images/pig-happy.png" : "images/worm1.jpg"; }
        private string Description 
        { 
            get
            {
                return Mode == SymbMode.Pig
                    ? "Ik heb enorm grote honger, kan jij me helpen zo veel mogelijk eten te verzamelen?"
                    : "Ik ben Jules, de cijferworm, en ik hou van cijfers! Kan jij me helpen zo veel mogelijk cijfers met de meeste waarde te verzamelen?";
            }
        }


        private void StartButtonClicked()
        {
            Dispatcher.Dispatch(new InitSymbGameAction(Mode, Name));
            NavigationManager.NavigateTo("symbgame/explanation");
        }
    }
}
