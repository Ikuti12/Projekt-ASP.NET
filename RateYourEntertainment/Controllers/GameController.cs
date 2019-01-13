using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using RateYourEntertainment.Filters;
using Microsoft.AspNetCore.Mvc;
using RateYourEntertainment.Models;
using RateYourEntertainment.Utility;
using RateYourEntertainment.ViewModels;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RateYourEntertainment.Controllers
{
    [GameNotFoundException]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameReviewRepository _gameReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;
        private readonly ILogger<GameController> _logger;

        public GameController(IGameRepository gameRepository, ICategoryRepository categoryRepository, ILogger<GameController> logger,
            IGameReviewRepository gameReviewRepository, HtmlEncoder htmlEncoder)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
            _gameReviewRepository = gameReviewRepository;
            _htmlEncoder = htmlEncoder;
            _logger = logger;
        }
        public ViewResult List(string category)
        {
            IEnumerable<Game> games;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                games = _gameRepository.Games.OrderBy(g => g.GameId);
                currentCategory = "All games";
            }
            else
            {
                games = _gameRepository.Games.Where(g => g.Category.CategoryName == category)
                   .OrderBy(g => g.GameId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new GameListViewModel
            {
                Games = games,
                CurrentCategory = currentCategory
            });
        }

        [Route("[controller]/Details/{id}")]
        public IActionResult Details(int id)
        {
            var game = _gameRepository.GetGameById(id);
            if (game == null)
            {
                _logger.LogDebug(LogEventIds.GetGameIdNotFound, new Exception("Game not found"), "Game with id {0} not found", id);
                //return NotFound();
                //Catch this error using the exception filter
                throw new GameNotFoundException();
            }

            return View(new GameDetailViewModel() { Game = game });
        }

        [Route("[controller]/Details/{id}")]
        [HttpPost]
        public IActionResult Details(int id, string review)
        {
            var game = _gameRepository.GetGameById(id);
            if (game == null)
            {
                _logger.LogWarning(LogEventIds.GetGameIdNotFound, new Exception("Game not found"), "Game with id {0} not found", id);
                return NotFound();
            }

            string encodedReview = _htmlEncoder.Encode(review);

            _gameReviewRepository.AddGameReview(new GameReview() { Game = game, Review = encodedReview });

            return View(new GameDetailViewModel() { Game = game });
        }

    }
}