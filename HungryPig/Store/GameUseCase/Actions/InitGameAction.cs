using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase.Actions
{
    public class InitGameAction
    {
        public Mode Mode { get; }
        public string Name { get; }

        public InitGameAction(Mode mode, string name)
        {
            Mode = mode;
            Name = name;
        }
    }
}
