using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateYourEntertainment.Models;

namespace RateYourEntertainment.ViewModels
{
    public class GameDetailViewModel
    {
        public Game Game { get; set; }
        public string Review { get; set; }
        public int ReviewScore { get; set; }
        public Category Category { get; set; }
    }
}
