using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookShop.Models;

namespace BookShop.ViewModels
{
    public class BookCreateViewModel
    {
        [Required]
        public int ISBN { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The Publication Date field is required.")]
        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "The Edition field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than {1}")]
        public int Edition { get; set; }

        [Required(ErrorMessage = "The Available Quantity field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than {1}")]
        [Display(Name = "Available Quantity")]
        public int AvailableQuantity { get; set; }

        public List<int> SelectedGenreIds { get; set; } = new List<int>();
        public List<Genre> AvailableGenres { get; set; } = new List<Genre>();

        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        [Required]
        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Publisher> Publishers { get; set; } = new List<Publisher>();
    }
}
