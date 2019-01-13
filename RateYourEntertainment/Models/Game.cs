using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RateYourEntertainment.Utility;

namespace RateYourEntertainment.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [Remote("CheckIfGameNameAlreadyExists", "GameManagement", ErrorMessage = "That name already exists")]
        public string Name { get; set; }
        [MaxLength(400)]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        
        [ValidUrl(ErrorMessage = "That's not a valid URL")]
        public string ImageURL { get; set; }
        [ValidUrl(ErrorMessage = "That's not a valid URL")]
        public string ImageThumbnailURL { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<GameReview> GameReviews { get; set; }
        public MultiplayerInformation MultiplayerInformation { get; set; }
    }
}
