using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.GameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Components
{
    partial class TutorialField : ComponentBase
    {
        [Parameter] public Level CurrentToturialLevel { get; set; }
        [Parameter] public bool Left { get; set; }
        [Parameter] public Mode Mode { get; set; }

        private string BorderColor { get; set; } = string.Empty;

    }
}
