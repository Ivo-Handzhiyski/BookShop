using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Genre
    {
        [Required]
        [Key]

        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }

    }
}
