using System.ComponentModel;

namespace HungryPig.Shared
{
    public class Game
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Mode Mode { get; set; }
        public int CurrentLevelId { get; set; }
        public Level TutorialLevel1 { get; set; }
        public Level TutorialLevel2 { get; set; }
        public List<Level> Levels { get; set; }
    }

    public enum Mode
    {
        [Description("Hongerig varkentje")]
        Pig,
        [Description("Cijferworm")]
        Numbers
    }
}
