using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class GenresController : Controller
    {
        private readonly GenreManager _genreManager;

        public GenresController(GenreManager genreManager)
        {
            _genreManager = genreManager;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _genreManager.GetGenres());
        }

        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreManager.AddGenre(genre); 
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }
    }
}
