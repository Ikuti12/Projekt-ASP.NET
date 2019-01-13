using System.Collections.Generic;

namespace RateYourEntertainment.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> Games { get; }

        IEnumerable<Game> GetAllGames();

        Game GetGameById(int gameId);

        void CreateGame(Game game);

        void UpdateGame(Game game);
    }
}