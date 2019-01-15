using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RateYourEntertainment.Models;

namespace RateYourEntertainment.ViewModels
{
    public class GameDetailViewModel
    {
        public Game Game { get; set; }
        [Required(ErrorMessage = "Please enter the review")]
        public string Review { get; set; }
        public int ReviewScore { get; set; }
        public Category Category { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
    }
}
