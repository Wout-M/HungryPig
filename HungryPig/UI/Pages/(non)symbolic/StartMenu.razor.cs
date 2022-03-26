using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.GameUseCase.Actions;
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
            var action = new InitGameAction(Mode, Name);
            Dispatcher.Dispatch(action);
            NavigationManager.NavigateTo("symbgame/tutorial");
        }
    }
}
