using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class BookGenre
    {
        [Key]
        public int BookGenreId { get; set; }

        public int ISBN { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("ISBN")]
        public Book Book { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
