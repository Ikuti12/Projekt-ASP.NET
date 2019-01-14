using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateYourEntertainment.Models;
using RateYourEntertainment.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateYourEntertainment.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GameController(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var games = _gameRepository.GetAllGames().OrderBy(g => g.Name);
            var categories = _categoryRepository.GetAllCategories().OrderBy(c => c.CategoryName);
            var homeViewModel = new HomeViewModel()
            {
                Games = games.ToList(),
                Categories = categories.ToList()
            };

            return View(homeViewModel);
        }
    }
}
