using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Book
    {
        [Required]
        [Key]
        public int ISBN { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]

        public DateTime PublicationDate { get; set; }

        [Required]
        public int Edition { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }

        [ForeignKey("AuthorID")]
        public Author Author { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
