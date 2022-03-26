using HungryPig.Shared;

namespace HungryPig.Services
{
    public interface IGameService
    {
        DotGame InitDotGame(string name);
        SymbGame InitGame(SymbMode mode, string name);
    }

    public class GameService : IGameService
    {
        #region (non)symbolic

        private static readonly List<(int, int)> Combinations = new()
        {
            (1,5), (2,3), (2,4), (2,6), (3,2), (3,4), (3,5), (3,7), (4,2), (4,3), (4,5), (4,6), (4,8), (5,1), (5,3), (5,4), (5,6),
            (5,7), (5,9), (6,2), (6,4), (6,5), (6,8), (7,3), (7,5), (7,8), (7,9), (8,4), (8,6), (8,7), (8,9), (9,5), (9,7), (9,8)
        };

        public SymbGame InitGame(SymbMode mode, string name)
        {
            var rnd = new Random();

            return new SymbGame()
            {
                Name = name,
                Mode = mode,
                Date = DateTime.Now,
                TutorialLevel1 = new SymbLevel()
                {
                    Name = "Oefenitem1",
                    Left = 1,
                    Right = 2,
                },
                TutorialLevel2 = new SymbLevel()
                {
                    Name = "Oefenitem2",
                    Left = 8,
                    Right = 6
                },
                Levels = Combinations
                .OrderBy(combination => rnd.Next())
                .Select(combination => new SymbLevel()
                {
                    Name = $"P{combination.Item1}-{combination.Item2}",
                    Left = combination.Item1,
                    Right = combination.Item2,
                }).ToList()
            };
        }

        #endregion

        #region dotgame

        private static readonly List<int> Amounts = new() { 3, 9, 5, 4, 1, 8, 2, 7, 3, 6 };

        public DotGame InitDotGame(string name)
        {
            int i = 0;

            return new DotGame()
            {
                Name = name,
                Date = DateTime.Now,
                TutorialLevel = new DotLevel()
                {
                    Name = "Oefenitem-8",
                    Amount = 8,
                },
                Levels = Amounts.Select(amount =>
                {
                    i++;
                    return new DotLevel()
                    {
                        Name = $"P{i}-{amount}",
                        Amount = amount,
                    };
                }).ToList()
            };
        }

        #endregion
    }
}
