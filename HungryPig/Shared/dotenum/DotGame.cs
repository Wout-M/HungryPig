namespace HungryPig.Shared
{
    public class DotGame
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int CurrentLevelId { get; set; }
        public DotLevel TutorialLevel { get; set; }
        public List<DotLevel> Levels { get; set; }
    }
}
