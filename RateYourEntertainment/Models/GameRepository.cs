using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _appDbContext.Games;
        }
        public Game GetGameById(int gameId)
        {
            return _appDbContext.Games.FirstOrDefault(g => g.Id == gameId);
        }
    }
}
