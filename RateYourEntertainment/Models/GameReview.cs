namespace RateYourEntertainment.Models
{
    public class GameReview
    {
        public int GameReviewId { get; set; }
        public Game Game { get; set; }
        public string Review { get; set; }
    }
}
