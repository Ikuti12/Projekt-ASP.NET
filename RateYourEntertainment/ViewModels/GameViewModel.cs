using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.ViewModels
{
    public class GameViewModel
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}