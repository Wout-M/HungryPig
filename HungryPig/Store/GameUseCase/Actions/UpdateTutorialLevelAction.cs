using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase.Actions
{
    public class UpdateTutorialLevelAction
    {
        public SymbLevel TutorialLevel { get; }
        public bool First { get; }

        public UpdateTutorialLevelAction(SymbLevel tutorialLevel, bool first)
        {
            TutorialLevel = tutorialLevel;
            First = first;
        }
    }
}
