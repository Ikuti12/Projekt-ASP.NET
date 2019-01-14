using Microsoft.AspNetCore.Mvc;
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
        [Remote("CheckIfGameNameAlreadyExists", "GameManagement", ErrorMessage = "That name already exists")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageThumbnailURL { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<GameReview> GameReviews { get; set; }

    }
}
