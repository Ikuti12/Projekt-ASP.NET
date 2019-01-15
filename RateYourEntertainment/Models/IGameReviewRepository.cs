using System.Collections.Generic;

namespace RateYourEntertainment.Models
{
    public interface IGameReviewRepository
    {
        void AddGameReview(GameReview gameReview);
        IEnumerable<GameReview> GetReviewsForGame(int gameId);
        IEnumerable<GameReview> GetAllReviews();
    }
}
