using HungryPig.Shared;

namespace HungryPig.Services
{
    public interface IGameService
    {
        Game InitGame(Mode mode, string name);
    }

    public class GameService : IGameService
    {
        #region (non)symbolic

        private static readonly List<(int, int)> Combinations = new()
        {
            (1,5), (2,3), (2,4), (2,6), (3,2), (3,4), (3,5), (3,7), (4,2), (4,3), (4,5), (4,6), (4,8), (5,1), (5,3), (5,4), (5,6),
            (5,7), (5,9), (6,2), (6,4), (6,5), (6,8), (7,3), (7,5), (7,8), (7,9), (8,4), (8,6), (8,7), (8,9), (9,5), (9,7), (9,8)
        };

        public Game InitGame(Mode mode, string name)
        {
            var rnd = new Random();

            return new Game()
            {
                Name = name,
                Mode = mode,
                Date = DateTime.Now,
                TutorialLevel1 = new Level()
                {
                    Name = "Oefenitem1",
                    Left = 1,
                    Right = 2,
                },
                TutorialLevel2 = new Level()
                {
                    Name = "Oefenitem2",
                    Left = 8,
                    Right = 6
                },
                Levels = Combinations
                .OrderBy(combination => rnd.Next())
                .Select(combination => new Level()
                {
                    Name = $"P{combination.Item1}-{combination.Item2}",
                    Left = combination.Item1,
                    Right = combination.Item2,
                }).ToList()
            };
        }

        #endregion
    }
}
