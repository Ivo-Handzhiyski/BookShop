using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShop.Data;
using BookShop.Models;
using BookShop.ViewModels;
using X.PagedList;
using BookShop.ViewModels.Books;

namespace BookShop.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new BookCreateViewModel
            {
                AvailableGenres = _context.Genres.ToList(),
                Authors = _context.Authors.ToList(),
                Publishers = _context.Publishers.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    ISBN = model.ISBN,
                    Title = model.Title,
                    Price = model.Price,
                    PublicationDate = model.PublicationDate,
                    Edition = model.Edition,
                    AvailableQuantity = model.AvailableQuantity,
                    Author = _context.Authors.Find(model.AuthorId),
                    Publisher = _context.Publishers.Find(model.PublisherId),
                    BookGenres = model.SelectedGenreIds.Select(genreId => new BookGenre { GenreId = genreId }).ToList()
                };

                _context.Books.Add(book);
                _context.SaveChanges();


                foreach (var genreId in model.SelectedGenreIds)
                {
                    var existingBookGenre = _context.BookGenres
                        .FirstOrDefault(bg => bg.ISBN == book.ISBN && bg.GenreId == genreId);

                    if (existingBookGenre == null)
                    {
                        var bookGenre = new BookGenre
                        {
                            ISBN = book.ISBN,
                            GenreId = genreId
                        };
                        _context.BookGenres.Add(bookGenre);
                    }
                }

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }


            model.Authors = _context.Authors.ToList();
            model.Publishers = _context.Publishers.ToList();
            model.AvailableGenres = _context.Genres.ToList();

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
            }

            return View(model);
        }

        // GET: Books/Index
        public IActionResult Index(int? page, int[] selectedGenre)
        {

            int pageSize = 5; // Set the number of books you want to display per page
            int pageNumber = (page ?? 1);

            var genres = _context.Genres.ToList();

            var booksQuery = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookGenres)
                    .ThenInclude(bg => bg.Genre)
                .OrderBy(b => b.Title);

            if (selectedGenre != null && selectedGenre.Any())
            {
                // Filter books that have all selected genres
                foreach (var genreId in selectedGenre)
                {
                    booksQuery = (IOrderedQueryable<Book>)booksQuery.Where(b => b.BookGenres.Any(bg => bg.GenreId == genreId));
                }
            }

            var books = booksQuery.ToPagedList(pageNumber, pageSize); // Convert to paged list

            var model = new BookIndexViewModel
            {
                Books = books,
                Genres = genres,
                SelectedGenre = selectedGenre
            };


            return View(model); 
        }
    }
}
