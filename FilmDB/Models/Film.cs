using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmDB.Models
{
    public class Film
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [Range(1890,2200)]
        public int Year { get; set; }
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
