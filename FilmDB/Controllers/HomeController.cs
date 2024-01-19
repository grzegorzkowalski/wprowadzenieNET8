using FilmDB.Data;
using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilmDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FilmManager _manager;

        public HomeController(ILogger<HomeController> logger, FilmManager filmManager)
        {
            _logger = logger;
            _manager = filmManager;
        }

        public IActionResult Index()
        {
            //var newFilm = new Film() 
            //{ 
            //    Title = "Matrix",
            //    Year = 1999,
            //    Id = 15
            //};
            //_manager.AddFilm(newFilm);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
