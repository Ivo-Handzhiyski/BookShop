using Microsoft.AspNetCore.Mvc;
using BookShop.Data;
using BookShop.Models;
using BookShop.ViewModels.Authors;
using System.Linq;

namespace BookShop.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AuthorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    AuthorName = model.AuthorName
                };
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Redirect to a list view after creation
            }
            return View(model);
        }

        // GET: Authors/Index
        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }
    }
}
