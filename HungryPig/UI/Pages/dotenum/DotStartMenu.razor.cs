using Fluxor;
using HungryPig.Store.DotGameUseCase.Actions;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Pages.dotenum
{
    partial class DotStartMenu
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        private string Name { get; set; } = string.Empty;
        private string ImageURL { get; } = "images/dog.png";
        private string Description { get; } = "Help jij mij om het juiste aantal bolletjes te vinden?";

        private void StartButtonClicked()
        {
            Dispatcher.Dispatch(new InitDotGameAction(Name));
            NavigationManager.NavigateTo("dotgame/explanation");
        }
    }
}
