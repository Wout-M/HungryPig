using HungryPig.Shared;

namespace HungryPig.Services
{
    public interface IGameService
    {

    }

    public class GameService : IGameService
    {
        private static readonly List<(int, int)> Combinations = new()
        {
            (1,5), (2,3), (2,4), (2,6), (3,2), (3,4), (3,5), (3,7), (4,2), (4,3), (4,5), (4,6), (4,8), (5,1), (5,3), (5,4), (5,6),
            (5,7), (5,9), (6,2), (6,4), (6,5), (6,8), (7,3), (7,5), (7,8), (7,9), (8,4), (8,6), (8,7), (8,9), (9,5), (9,7), (9,8)
        };

        public Game InitGame(Mode mode, string name)
        {
            return new Game()
            {
                Name = name,
                Mode = mode,
                Date = DateTime.Now,
                Levels = Combinations.Select(combination => new Level()
                {
                    Name
                    Left = combination.Item1,
                    Right = combination.Item2,
                }).ToList();
            }
        }
    }
}
