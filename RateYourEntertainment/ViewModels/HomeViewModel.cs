using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateYourEntertainment.Models;

namespace RateYourEntertainment.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Game> Games {get;set;}
        public List<Category> Categories { get; set; }

    }
}
