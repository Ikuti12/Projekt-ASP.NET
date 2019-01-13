using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public interface IGameReviewRepository
    {
        void AddGameReview(GameReview gameReview);
        IEnumerable<GameReview> GetReviewsForGame(int gameId);
    }
}