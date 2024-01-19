using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager _filmManager;
        public FilmController(FilmManager filmManager) 
        { 
            _filmManager = filmManager;
        }
        public IActionResult Index()
        {
            var films = _filmManager.GetFilms();
            return View(films);
        }

        [HttpGet]
        public IActionResult AddFilm() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Film film)
        {
            try
            {
                _filmManager.AddFilm(film);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(film);
            }             
        }
    }
}
