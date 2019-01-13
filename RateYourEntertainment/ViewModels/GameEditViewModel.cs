using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateYourEntertainment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RateYourEntertainment.ViewModels
{
    public class GameEditViewModel
    {
        public Game Game { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
    }
}