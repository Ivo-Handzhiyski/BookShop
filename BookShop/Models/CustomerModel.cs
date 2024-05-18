using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Customer : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string CustomerFirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; } = string.Empty;

        [Required]
        public string City { get; set; }
    }
}
