using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RateYourEntertainment.Models;
using RateYourEntertainment.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateYourEntertainment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;
        public HomeController( IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var games = _gameRepository.GetAllGames().OrderBy(g => g.Name);
            var categories = _categoryRepository.GetAllCategories().OrderBy(c => c.CategoryName);
            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to the best website to look at rating for your favorite entertainment media. RateYourEntertainment.com",
                Games = games.ToList(),
                Categories = categories.ToList()
            };

            return View(homeViewModel);
        }
        public IActionResult Details(int id)
        {
            var game = _gameRepository.GetGameById(id);
            if (game == null)
            {
                //throw new GameNotFoundException();
            }
            var category = _categoryRepository.GetCategoryById(game.CategoryId);
            return View(new GameDetailViewModel() { Game = game , Category= category });
        }
    }
}
