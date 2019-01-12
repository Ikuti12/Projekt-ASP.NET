﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public class Game
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        //public string LongDescription { get; set; }
        public string ImageThumbnailURL { get; set; }
        public string Genre { get; set; }
        //public decimal Score { get; set; }
        //public DateTime ReleaseDate { get; set; }

    }
}
