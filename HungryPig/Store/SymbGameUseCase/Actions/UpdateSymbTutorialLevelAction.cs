using HungryPig.Shared;

namespace HungryPig.Store.SymbGameUseCase.Actions
{
    public class UpdateSymbTutorialLevelAction
    {
        public SymbLevel TutorialLevel { get; }
        public bool First { get; }

        public UpdateSymbTutorialLevelAction(SymbLevel tutorialLevel, bool first)
        {
            TutorialLevel = tutorialLevel;
            First = first;
        }
    }
}
