using Fluxor;
using HungryPig.Services;
using HungryPig.Shared;
using HungryPig.Store.GameUseCase;
using HungryPig.Store.GameUseCase.Actions;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages
{
    partial class StartMenu 
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        protected Mode Mode { get; set; } = Mode.Pig;
        protected string Name { get; set; } = string.Empty;

        private void StartButtonClicked()
        {
            var action = new InitGameAction(Mode, Name);
            Dispatcher.Dispatch(action);
            NavigationManager.NavigateTo("/tutorial");
        }
    }
}
