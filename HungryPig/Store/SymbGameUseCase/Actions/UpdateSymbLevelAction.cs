using HungryPig.Shared;

namespace HungryPig.Store.SymbGameUseCase.Actions
{
    public class UpdateSymbLevelAction
    {
        public SymbLevel Level { get; }

        public UpdateSymbLevelAction(SymbLevel level)
        {
            Level = level;
        }
    }
}
