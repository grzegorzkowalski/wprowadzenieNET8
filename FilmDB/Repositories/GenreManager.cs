using FilmDB.Data;
using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Repositories
{
    public class GenreManager
    {
        private readonly ApplicationDbContext _context;
        public GenreManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenreManager> AddGenre(Genre genre) 
        { 
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return this;
        }

        public async Task<Genre?> GetGenre(int id) 
        {
            return await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Genre>> GetGenres() 
        { 
            return await _context.Genres.ToListAsync();
        }

        public List<Genre> GetGenresSync()
        {
            return _context.Genres.ToList();
        }
    }
}
