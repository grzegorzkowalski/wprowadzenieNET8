using FilmDB.Data;
using FilmDB.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmDB.Repositories
{
    public class FilmManager
    {
        private readonly ApplicationDbContext _context;
        public FilmManager(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }
        public FilmManager AddFilm(Film film)
        {
            try
            {
                _context.Films.Add(film);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                film.Id = 0;
                _context.SaveChanges();
            }
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            var filmToRemove = GetFilm(id);
            if (filmToRemove != null)
            {
                _context.Films.Remove(filmToRemove);
                _context.SaveChanges();
            }
            return this;
        }

        public FilmManager UpdateFilm(Film film)
        {
            _context.Films.Update(film);
            _context.SaveChanges();
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            var editFilm = GetFilm(id);
            if (editFilm != null)
            {
                try
                {
                    editFilm.Title = !String.IsNullOrEmpty(newTitle) ? newTitle : "Brak tytułu";
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }     
            }
            return this;
        }

        public Film? GetFilm(int id)
        {
            return _context.Films.FirstOrDefault(x => x.Id == id);         
        }

        public List<Film> GetFilms()
        {
            return _context.Films.ToList();
        }
    }
}
