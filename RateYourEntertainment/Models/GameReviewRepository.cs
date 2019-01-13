using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public class GameReviewRepository : IGameReviewRepository
    {
        private readonly AppDbContext _appDbContext;

        public GameReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddGameReview(GameReview gameReview)
        {
            _appDbContext.GameReviews.Add(gameReview);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<GameReview> GetReviewsForGame(int gameId)
        {
            return _appDbContext.GameReviews.Where(g => g.Game.GameId == gameId);
        }
    }
}