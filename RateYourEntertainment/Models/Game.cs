using Microsoft.AspNetCore.Mvc;
using RateYourEntertainment.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        [ValidUrl(ErrorMessage = "That's not a valid URL")]
        public string ImageThumbnailURL { get; set; }
        [ValidUrl(ErrorMessage = "That's not a valid URL")]
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public float Score { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<GameReview> GameReviews { get; set; }

    }
}
