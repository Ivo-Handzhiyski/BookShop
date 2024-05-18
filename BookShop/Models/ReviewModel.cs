using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Review
    {
        [Required]
        [Key]

        public int ReviewId { get; set; }

        [Required]
        [ForeignKey("ISBN")]
        public Book Book { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public Customer Customer { get; set; }

        [Required]
        public string ReviewStars { get; set; }
        [Required]
        public string ReviewComment { get; set; }
    }
}
