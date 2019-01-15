using System.Collections.Generic;

namespace RateYourEntertainment.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> Games { get; }
        Game GetGameById(int gameId);
        void CreateGame(Game game);

        void UpdateGame(Game game);
        void DeleteGame(Game game);
    }
}
