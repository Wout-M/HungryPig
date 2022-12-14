using HungryPig.Shared;
using Microsoft.AspNetCore.Components;

namespace HungryPig.UI.Components.dotenum
{
    partial class DotGameField : ComponentBase
    {
        [Parameter] public DotLevel CurrentLevel { get; set; }

        private string ImageName { get; set; }

        protected override void OnInitialized()
        {
            SetImage();
        }

        public void SetImage() => ImageName = CurrentLevel?.Name ?? string.Empty;

        public void ResetImage() => ImageName = string.Empty;
    }
}
