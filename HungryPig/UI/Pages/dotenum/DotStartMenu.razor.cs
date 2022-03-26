using Fluxor;
using HungryPig.Store.DotGameUseCase.Actions;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages.dotenum
{
    partial class DotStartMenu
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        protected string Name { get; set; } = string.Empty;


        private void StartButtonClicked()
        {
            Dispatcher.Dispatch(new InitDotGameAction(Name));
            NavigationManager.NavigateTo("dotgame/tutorial");
        }
    }
}
