using Microsoft.AspNetCore.Mvc;
using BookShop.Data;
using BookShop.Models;
using BookShop.ViewModels.Publishers;
using System.Linq;

namespace BookShop.Controllers
{
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublishersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PublisherCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var publisher = new Publisher
                {
                    PublisherName = model.PublisherName
                };
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Redirect to a list view after creation
            }
            return View(model);
        }

        // GET: Publishers/Index
        public IActionResult Index()
        {
            var publishers = _context.Publishers.ToList();
            return View(publishers);
        }
    }
}
