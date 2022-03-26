using HungryPig.Shared;

namespace HungryPig.Store.SymbGameUseCase.Actions
{
    public class InitSymbGameAction
    {
        public SymbMode Mode { get; }
        public string Name { get; }

        public InitSymbGameAction(SymbMode mode, string name)
        {
            Mode = mode;
            Name = name;
        }
    }
}
