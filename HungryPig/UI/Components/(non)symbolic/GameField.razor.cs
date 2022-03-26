using HungryPig.Helpers;
using HungryPig.Shared;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Components._non_symbolic
{
    partial class GameField : ComponentBase
    {
        [Parameter] public SymbLevel CurrentLevel { get; set; }
        [Parameter] public bool Left { get; set; }
        [Parameter] public SymbMode Mode { get; set; }
        [Parameter] public Action<bool, Side> SideSelected { get; set; }

        private string ImageName { get; set; }

        protected override void OnInitialized()
        {
            SetImage();
        }

        private void OnImageClicked(bool left)
        {
            bool correct = (left && CurrentLevel.Left > CurrentLevel.Right) ||
                          (!left && CurrentLevel.Right > CurrentLevel.Left);

            SideSelected?.Invoke(correct, left ? Side.Left : Side.Right);
        }

        public void SetImage() => ImageName = CurrentLevel?.Name ?? string.Empty;

        public void ResetImage() => ImageName = string.Empty;
    }
}
