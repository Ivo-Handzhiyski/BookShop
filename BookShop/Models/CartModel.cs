using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    [PrimaryKey(nameof(ISBN), nameof(CartId))]
    public class CartItem
    {
        [Key, Column(Order = 0)]
        public int ISBN { get; set; }

        [Key, Column(Order = 1)]
        public string CartId { get; set; }

        [ForeignKey("ISBN")]
        public Book Book { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
