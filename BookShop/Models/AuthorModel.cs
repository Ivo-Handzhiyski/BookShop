using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}
