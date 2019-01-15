using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace RateYourEntertainment.Models
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _appDbContext;

        public GameRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Game> GetAllGames()
        {
            return _appDbContext.Games.OrderBy(g => g.GameId);
        }
        public IEnumerable<Game> Games
        {
            get
            {
                return _appDbContext.Games.Include(c => c.Category);
            }
        }
        public Game GetGameById(int gameId)
        {
            return _appDbContext.Games.Include(g => g.GameReviews).FirstOrDefault(g => g.GameId == gameId);
        }
        public void UpdateGame (Game game)
        {
            _appDbContext.Games.Update(game);
            _appDbContext.SaveChanges();
        }

        public void CreateGame(Game game)
        {
            _appDbContext.Games.Add(game);
            _appDbContext.SaveChanges();
        }
        public void DeleteGame(Game game)
        {
            _appDbContext.Games.Remove(game);
            _appDbContext.SaveChanges();
        }
    }
}
