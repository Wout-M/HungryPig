namespace HungryPig.Shared
{
    public class Game
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Mode Mode { get; set; }
        public List<Level> Levels { get; set; }
    }

    public enum Mode
    {
        Pig,
        Numbers
    }
}
