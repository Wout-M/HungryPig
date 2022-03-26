using HungryPig.Shared;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Components.dotenum
{
    partial class DotGameField : ComponentBase
    {
        [Parameter] public DotLevel CurrentLevel { get; set; }
        [Parameter] public Action SideSelected { get; set; }

        private string ImageName { get; set; }

        protected override void OnInitialized()
        {
            SetImage();
        }

        private void OnImageClicked() => SideSelected?.Invoke();

        public void SetImage() => ImageName = CurrentLevel?.Name ?? string.Empty;

        public void ResetImage() => ImageName = string.Empty;
    }
}
