using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager _filmManager;
        private readonly GenreManager _genreManager;
        public FilmController(FilmManager filmManager, GenreManager genreManager) 
        { 
            _filmManager = filmManager;
            _genreManager = genreManager;
        }
        public IActionResult Index()
        {
            var films = _filmManager.GetFilms();
            return View(films);
        }

        [HttpGet]
        public IActionResult AddFilm() 
        {
            ViewBag.Genres = new SelectList(_genreManager.GetGenresSync(), "Id", "Name");
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

        [HttpGet]
        public IActionResult EditFilm(int id)
        {
            var filmToEdit = _filmManager.GetFilm(id);
            if (filmToEdit != null)
            {
                return View(filmToEdit);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult EditFilm(Film film)
        {
            if (film != null)
            {
                _filmManager.UpdateFilm(film);
                return RedirectToAction("Index");   
            }
            else
            {
                return View(film);
            }   
        }

        [HttpGet]
        public ActionResult Details(int id) 
        {
            var film = _filmManager.GetFilm(id);
            if (film != null)
            {
                return View(film);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult RemoveFilm(int id) 
        {
            var filmToDelete = _filmManager.GetFilm(id);
            if (filmToDelete != null)
            {
                return View(filmToDelete);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Remove(int id)
        { 
            var filmToDelete = _filmManager.GetFilm(id);
            if (filmToDelete != null)
            {
                _filmManager.RemoveFilm(id);
                return RedirectToAction("Index");
            }
            else 
            {
                return View("RemoveFilm", id);
            }
        }
    }
}
