using MudBlazor;

namespace HungryPig.Shared
{
    public class DotLevel
    {
        public string Name { get; set; }
        public DotColor Color { get; set; }
        public bool Subetizing { get => Amount <= 3; }
        public int Amount { get; set; }

        public long ReactionTime { get; set; }
    }

    public enum DotColor
    {
        Black,
        Purple,
        Blue,
        Green,
        Yellow,
        Orange,
        Red
    }
}
