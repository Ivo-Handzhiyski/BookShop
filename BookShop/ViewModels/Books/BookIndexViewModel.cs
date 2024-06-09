using BookShop.Models;
using X.PagedList;

namespace BookShop.ViewModels.Books
{
    public class BookIndexViewModel
    {
        public IPagedList<Book> Books { get; set; }
        public List<Genre> Genres { get; set; }
        public int[] SelectedGenre { get; set; }
    }
}
