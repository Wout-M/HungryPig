using Fluxor;
using HungryPig.Shared;
using HungryPig.Store.GameUseCase;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Components._non_symbolic
{
    partial class TutorialField : ComponentBase
    {
        [Parameter] public SymbLevel CurrentToturialLevel { get; set; }
        [Parameter] public bool Left { get; set; }
        [Parameter] public SymbMode Mode { get; set; }
        [Parameter] public Action<bool, Side> SideSelected { get; set; }

        private string BorderColor { get; set; } = string.Empty;

        private void OnImageClicked(bool left)
        {
            bool correct = (left && CurrentToturialLevel.Left > CurrentToturialLevel.Right) ||
                           (!left && CurrentToturialLevel.Right > CurrentToturialLevel.Left);
            
            SideSelected?.Invoke(correct, left ? Side.Left : Side.Right);
        }

        public void SetBorderColor(bool correct) 
        {
            BorderColor = correct ? "mud-border-tertiary" : "mud-border-secondary";
            StateHasChanged();
        }

        public void ResetBorderColor()
        {
            BorderColor = string.Empty;
        }
    }
}
