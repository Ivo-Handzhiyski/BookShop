using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookShop.Models;
using Newtonsoft.Json;
using BookShop.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "CartId";

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCartItems();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int ISBN)
        {
            var book = _context.Books.Find(ISBN);
            if (book == null)
            {
                return NotFound();
            }

            var cartId = GetCartId();
            var cart = GetCartItems();
            var cartItem = _context.CartItems.FirstOrDefault(c => c.ISBN == ISBN && c.CartId == cartId);
            if (cartItem == null)
            {
                _context.CartItems.Add(new CartItem { Book = book, ISBN = book.ISBN, CartId = cartId, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCartItem(int isbn, int quantity)
        {
            var cartId = GetCartId();
            var cartItem = _context.CartItems.FirstOrDefault(c => c.ISBN == isbn && c.CartId == cartId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int isbn)
        {
            var cartId = GetCartId();
            var cart = GetCartItems();
            var cartItem = cart.FirstOrDefault(c => c.Book.ISBN == isbn && c.CartId == cartId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        private string GetCartId()
        {
            if (HttpContext.Session.GetString(CartSessionKey) == null)
            {
                HttpContext.Session.SetString(CartSessionKey, Guid.NewGuid().ToString());
            }
            return HttpContext.Session.GetString(CartSessionKey);
        }

        private List<CartItem> GetCartItems()
        {
            var cartId = GetCartId();
            return _context.CartItems
                           .Include(c => c.Book)
                           .ThenInclude(b => b.Author)
                           .Include(c => c.Book)
                           .ThenInclude(b => b.Publisher)
                           .Where(c => c.CartId == cartId)
                           .ToList();
        }
    }
}
