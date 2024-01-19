using FilmDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Film> Films {  get; set; } 
        public DbSet<Genre> Genres { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Genre
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Drama" },
                new Genre { Id = 3, Name = "Comedy" }
            );

            // Seed data for Film
            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1, Title = "Film A", Year = 2021, GenreId = 1 },
                new Film { Id = 2, Title = "Film B", Year = 2022, GenreId = 2 }
            );
        }
    }
}
