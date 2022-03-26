using HungryPig.Shared;

namespace HungryPig.Store.DotGameUseCase.Actions
{
    public class UpdateDotLevelAction
    {
        public DotLevel Level { get; }

        public UpdateDotLevelAction(DotLevel level)
        {
            Level = level;
        }
    }
}
