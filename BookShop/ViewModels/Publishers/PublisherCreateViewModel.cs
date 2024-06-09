using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookShop.Models;

namespace BookShop.ViewModels.Publishers
{
    public class PublisherCreateViewModel
    {
        [Required(ErrorMessage = "The Publisher Name field is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string PublisherName { get; set; }
    }
}
