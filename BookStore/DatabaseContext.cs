using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<OrderToBook> OrderToBook { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Фёдор Михайлович Достоевский"
                },
                new Author
                {
                    Id = 2,
                    Name = "Лев Николаевич Толстой"
                });
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Игрок",
                    AuthorId = 1,
                    Price = 25
                },
                new Book
                {
                    Id = 2,
                    Name = "Юность",
                    AuthorId = 2,
                    Price = 30
                },
                new Book
                {
                    Id = 3,
                    Name = "Преступление и наказание",
                    AuthorId = 1,
                    Price = 34
                });
            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerName = "Мельникова Ольга Алексеевна"
                },
                new Order
                {
                    Id = 2,
                    CustomerName = "Иванов Иван Иванович"
                });
            builder.Entity<OrderToBook>().HasData(
                new OrderToBook
                {
                    Id = 1,
                    BookId = 1,
                    OrderId = 1
                },
                new OrderToBook
                {
                    Id = 2,
                    BookId = 2,
                    OrderId = 1
                },
                new OrderToBook
                {
                    Id = 3,
                    BookId = 3,
                    OrderId = 1
                },
                new OrderToBook
                {
                    Id = 4,
                    BookId = 1,
                    OrderId = 2
                },
                new OrderToBook
                {
                    Id = 5,
                    BookId = 3,
                    OrderId = 2
                });
        }

    }
}
