using System.Collections.Generic;
using System.Linq;
using RateYourEntertainment.Models;
using RateYourEntertainment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BethanysPieShop.Controllers
{
    [Authorize(Roles = "Administrators")]
    [Authorize(Policy = "DeleteGame")]
    public class PieManagementController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieManagementController(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            var games = _gameRepository.GetAllGames().OrderBy(g => g.GameId);
            return View(games);
        }

        public IActionResult AddGame()
        {
            var categories = _categoryRepository.Categories;
            var gameEditViewModel = new GameEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().CategoryId
            };
            return View(gameEditViewModel);
        }

        [HttpPost]
        public IActionResult AddGame(GameEditViewModel gameEditViewModel)
        {

            if (ModelState.IsValid)
            {
                _gameRepository.CreateGame(gameEditViewModel.Game);
                return RedirectToAction("Index");
            }

            return View(gameEditViewModel);
        }
        public IActionResult EditGame(int gameId)
        {
            var categories = _categoryRepository.Categories;

            var game = _gameRepository.Games.FirstOrDefault(g => g.GameId == gameId);

            var gameEditViewModel = new GameEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Game = game,
                CategoryId = game.CategoryId
            };

            var item = gameEditViewModel.Categories.FirstOrDefault(c => c.Value == game.CategoryId.ToString());
            item.Selected = true;

            return View(gameEditViewModel);
        }

        [HttpPost]
        //public IActionResult EditPie([Bind("Pie")] PieEditViewModel pieEditViewModel)
        public IActionResult EditGame(GameEditViewModel gameEditViewModel)
        {
            gameEditViewModel.Game.CategoryId = gameEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _gameRepository.UpdateGame(gameEditViewModel.Game);
                return RedirectToAction("Index");
            }
            return View(gameEditViewModel);
        }

        [HttpPost]
        public IActionResult DeleteGame(string gameId)
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckIfPieNameAlreadyExists([Bind(Prefix = "Game.Name")]string name)
        {
            var game = _gameRepository.Games.FirstOrDefault(g => g.Name == name);
            return game == null ? Json(true) : Json("That pie name is already taken");
        }
    }
}