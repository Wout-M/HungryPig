using System.ComponentModel;

namespace HungryPig.Shared
{
    public class SymbGame
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public SymbMode Mode { get; set; }
        public int CurrentLevelId { get; set; }
        public SymbLevel TutorialLevel1 { get; set; }
        public SymbLevel TutorialLevel2 { get; set; }
        public List<SymbLevel> Levels { get; set; }
    }

    public enum SymbMode
    {
        [Description("Hongerig varkentje")]
        Pig,
        [Description("Cijferworm")]
        Numbers
    }
}
