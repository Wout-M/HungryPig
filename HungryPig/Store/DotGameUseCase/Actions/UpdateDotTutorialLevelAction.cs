using HungryPig.Shared;

namespace HungryPig.Store.DotGameUseCase.Actions
{
    public class UpdateDotTutorialLevelAction
    {
        public DotLevel TutorialLevel { get; }

        public UpdateDotTutorialLevelAction(DotLevel tutorialLevel)
        {
            TutorialLevel = tutorialLevel;
        }
    }
}
