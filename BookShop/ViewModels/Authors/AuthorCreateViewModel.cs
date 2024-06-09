using System.ComponentModel.DataAnnotations;

namespace BookShop.ViewModels.Authors
{
    public class AuthorCreateViewModel
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "The Author Name field is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string AuthorName { get; set; }
    }
}
