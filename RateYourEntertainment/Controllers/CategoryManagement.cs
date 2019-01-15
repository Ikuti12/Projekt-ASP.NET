using System.Collections.Generic;
using System.Linq;
using RateYourEntertainment.Models;
using RateYourEntertainment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RateYourEntertainment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryManagement : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;
        public CategoryManagement(ICategoryRepository categoryRepository, IGameRepository gameRepository)
        {
            _categoryRepository = categoryRepository;
            _gameRepository = gameRepository;
        }
        public ViewResult Index()
        {
            var categories = _categoryRepository.GetAllCategories().OrderBy(c => c.CategoryId);
            return View(categories);
        }
        public IActionResult AddCategory()
        {
            var categories = _categoryRepository.Categories;
            var categoryEditViewModel = new CategoryEditViewModel { };
            return View(categoryEditViewModel);
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryEditViewModel categoryEditViewModel)
        {

            if (ModelState.IsValid)
            {
                _categoryRepository.CreateCategory(categoryEditViewModel.Category);
                return RedirectToAction("Index");
            }

            return View(categoryEditViewModel);
        }
        public IActionResult EditCategory(int id)
        {
            var categories = _categoryRepository.Categories;

            var category = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryId == id);

            var categoryEditViewModel = new CategoryEditViewModel
            {
                Category = category
            };

            return View(categoryEditViewModel);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryEditViewModel categoryEditViewModel)
        {

            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(categoryEditViewModel.Category);
                return RedirectToAction("Index");
            }
            return View(categoryEditViewModel);
        }

    }
}
