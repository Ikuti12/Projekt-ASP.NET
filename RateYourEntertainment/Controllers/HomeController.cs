using System;
using RateYourEntertainment.Filters;
using Microsoft.AspNetCore.Mvc;
using RateYourEntertainment.Models;
using RateYourEntertainment.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using RateYourEntertainment.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RateYourEntertainment.Controllers
{
    [ServiceFilter(typeof(TimerAction))]
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _memoryCache;
        public HomeController( IGameRepository gameRepository, IStringLocalizer<HomeController> stringLocalizer, ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _gameRepository = gameRepository;
            _stringLocalizer = stringLocalizer;
            _logger = logger;
            _memoryCache = memoryCache;
        }
        [ResponseCache(CacheProfileName = "Default")]

        public IActionResult Index()
        {
            var games = _gameRepository.GetAllGames().OrderBy(g => g.Name);
            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to the best website to look at rating for your favorite entertainment media. RateYourEntertainment.com",
                Games = games.ToList()
            };

            return View(homeViewModel);
        }
        public IActionResult TestUrl()
        {
            var url =
                Url.Action("Details", "Game", new { id = 1 });
            return RedirectToAction("Index");
        }
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            //Logging
            _logger.LogInformation(LogEventIds.ChangeLanguage, "Language changed to {0}", culture);

            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}
