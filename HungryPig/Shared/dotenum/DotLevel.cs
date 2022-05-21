using MudBlazor;
using System.ComponentModel;

namespace HungryPig.Shared
{
    public class DotLevel
    {
        public string Name { get; set; }
        public DotColor Color { get; set; }
        public bool Subetizing { get => Amount <= 3; }
        public int Amount { get; set; }

        public long? ReactionTime { get; set; }
    }

    public enum DotColor
    {
        [Description("zwarte")]
        Black,
        [Description("paarse")]
        Purple,
        [Description("blauwe")]
        Blue,
        [Description("groene")]
        Green,
        [Description("gele")]
        Yellow,
        [Description("oranje")]
        Orange,
        [Description("rode")]
        Red
    }
}
