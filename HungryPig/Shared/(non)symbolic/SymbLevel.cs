using System.ComponentModel;

namespace HungryPig.Shared
{
    public class SymbLevel
    {
        public string Name { get; set; }
        public bool Subetizing { get => !(Left > 3 && Right > 3); }
        public int Left { get; set; }
        public int Right { get; set; }

        public long? ReactionTime { get; set; }
        public Side? SideSelected { get; set; }
        public bool? Correct { get; set; }
    }

    public enum Side
    {
        [Description("Links")]
        Left,
        [Description("Rechts")]
        Right
    }
}
