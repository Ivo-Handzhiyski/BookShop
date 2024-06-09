using BookShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BookShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BookGenre> BookGenres { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Genre>()
                .HasIndex(g => g.GenreName)
                .IsUnique();

            builder.Entity<Book>()
                .Property(b => b.ISBN)
                .ValueGeneratedNever();
        }
    }
}
