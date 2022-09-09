using HungryPig.Shared;

namespace HungryPig.Store.SymbGameUseCase.Actions
{
    public class InitSymbGameAction
    {
        public SymbMode Mode { get; }
        public bool IsLong { get; }
        public string Name { get; }

        public InitSymbGameAction(SymbMode mode, string name, bool isLong)
        {
            Mode = mode;
            Name = name;
            IsLong = isLong;
        }
    }
}
