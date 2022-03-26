using HungryPig.Shared;

namespace HungryPig.Store.DotGameUseCase.Actions
{
    public class InitDotGameAction
    {
        public string Name { get; }

        public InitDotGameAction(string name)
        {
            Name = name;
        }
    }
}
