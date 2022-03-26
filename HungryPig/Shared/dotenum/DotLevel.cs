namespace HungryPig.Shared
{
    public class DotLevel
    {
        public string Name { get; set; }
        public bool Subetizing { get => Amount < 3; }
        public int Amount { get; set; }

        public long ReactionTime { get; set; }
    }
}
