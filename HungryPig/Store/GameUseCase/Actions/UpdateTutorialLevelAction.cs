using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase.Actions
{
    public class UpdateTutorialLevelAction
    {
        public Level TutorialLevel { get; }
        public bool First { get; }

        public UpdateTutorialLevelAction(Level tutorialLevel, bool first)
        {
            TutorialLevel = tutorialLevel;
            First = first;
        }
    }
}
