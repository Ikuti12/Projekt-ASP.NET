using RateYourEntertainment.Auth;
using System.ComponentModel.DataAnnotations;

namespace RateYourEntertainment.Models
{
    public class GameReview
    {
        public int GameReviewId { get; set; }
        public Game Game { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Review { get; set; }
        public int ReviewScore { get; set; }
    }
}
