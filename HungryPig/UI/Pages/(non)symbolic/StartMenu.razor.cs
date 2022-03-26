using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.SymbGameUseCase.Actions;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages._non_symbolic
{
    partial class StartMenu 
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        protected SymbMode Mode { get; set; } = SymbMode.Pig;
        protected string Name { get; set; } = string.Empty;

        private void StartButtonClicked()
        {
            Dispatcher.Dispatch(new InitSymbGameAction(Mode, Name));
            NavigationManager.NavigateTo("symbgame/tutorial");
        }
    }
}
