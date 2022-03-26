using Fluxor;
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
            //var action = new InitGameAction(Mode, Name);
            //Dispatcher.Dispatch(action);
            NavigationManager.NavigateTo("dotgame/tutorial");
        }
    }
}
