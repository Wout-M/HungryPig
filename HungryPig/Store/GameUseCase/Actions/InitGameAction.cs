using HungryPig.Shared;

namespace HungryPig.Store.GameUseCase.Actions
{
    public class InitGameAction
    {
        public SymbMode Mode { get; }
        public string Name { get; }

        public InitGameAction(SymbMode mode, string name)
        {
            Mode = mode;
            Name = name;
        }
    }
}
