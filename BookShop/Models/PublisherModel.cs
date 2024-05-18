using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Publisher
    {
        [Required]
        [Key]
        public string PublisherId { get; set; }

        [Required]
        public string PublisherName { get; set; } 
    }
}
