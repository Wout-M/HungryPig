using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase.Actions
{
    public class UpdateLevelAction
    {
        public Level Level { get; }

        public UpdateLevelAction(Level level)
        {
            Level = level;
        }
    }
}
