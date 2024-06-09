using System.ComponentModel.DataAnnotations;

namespace BookShop.ViewModels
{
    public class GenreCreateViewModel
    {
        [Required(ErrorMessage = "The Genre ID field is required.")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "The Genre Name field is required.")]
        public string GenreName { get; set; }
    }
}
