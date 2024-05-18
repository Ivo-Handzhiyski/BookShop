using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Order
    {
        [Required]
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("UserId")]
        public Customer Customer { get; set; }

        public DateTime Date { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
