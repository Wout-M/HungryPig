using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase.Actions
{
    public class UpdateLevelAction
    {
        public SymbLevel Level { get; }

        public UpdateLevelAction(SymbLevel level)
        {
            Level = level;
        }
    }
}
