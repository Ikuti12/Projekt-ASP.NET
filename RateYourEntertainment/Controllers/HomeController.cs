using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RateYourEntertainment.Auth;
using RateYourEntertainment.Models;
using RateYourEntertainment.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateYourEntertainment.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameReviewRepository _gameReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;
        public HomeController( IGameRepository gameRepository, ICategoryRepository categoryRepository, IGameReviewRepository gameReviewRepository, HtmlEncoder htmlEncoder, UserManager<ApplicationUser> userManager)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
            _gameReviewRepository = gameReviewRepository;
            _htmlEncoder = htmlEncoder;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var games = _gameRepository.GetAllGames().OrderBy(g => g.Name);
            var categories = _categoryRepository.GetAllCategories().OrderBy(c => c.CategoryName);
            var highRatedGames = (from g in games where g.Score > 3.0f select g);
            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to the best website to look at rating for your favorite entertainment media. RateYourEntertainment.com",
                Games = games.ToList(),
                Categories = categories.ToList(),
                HighRatedGames = highRatedGames.ToList()
            };

            return View(homeViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var game = _gameRepository.GetGameById(id);
            var users = _userManager.Users;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            if (game == null)
            {
                //throw new GameNotFoundException();
            }
            var category = _categoryRepository.GetCategoryById(game.CategoryId);
            return View(new GameDetailViewModel() { Game = game , Category= category,Users=users});
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Details(int id, string review, int reviewScore)
        {
            var game = _gameRepository.GetGameById(id);
            var users = _userManager.Users;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var category = _categoryRepository.GetCategoryById(game.CategoryId);
            if (game == null)
            {
            }
            if (review == null)
            {
                return RedirectToAction("Details");
            }
            string encodedReview = _htmlEncoder.Encode(review);
            var gameReview = new GameReview { Game = game, Review = encodedReview, ReviewScore = reviewScore, ApplicationUser = user };
            TryValidateModel(gameReview);
            if (ModelState.IsValid)
            {
                if (game.GameReviews.Count()>0)
                {
                    game.Score = game.Score * game.GameReviews.Count();
                }
                game.Score += reviewScore;
                game.Score = game.Score / (game.GameReviews.Count() + 1);
                _gameReviewRepository.AddGameReview(gameReview);
                return View(new GameDetailViewModel() { Game = game, Category = category, Users = users });
            }




            return RedirectToAction("Details");
        }
    }
}
