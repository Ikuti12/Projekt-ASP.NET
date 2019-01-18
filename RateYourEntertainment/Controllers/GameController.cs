using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RateYourEntertainment.Models;
using RateYourEntertainment.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateYourEntertainment.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameContext _context;
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GameController(GameContext context, IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }
        // GET: /<controller>/

        public IActionResult Index()
        {
            var games = from g in _context.Games select new { g.Name, Count = g.GameReviews.Count() };

            return View(games.ToList());
        }
    }
}
