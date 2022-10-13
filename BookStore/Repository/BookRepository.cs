using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository: Repository<Book, int>
    {
        public BookRepository(DatabaseContext dbContext)
            => DbSet = dbContext.Book;

        public override IAsyncEnumerable<Book> GetAllWithRelationsAsync()
        {
            return DbSet.Include(x => x.Author).AsAsyncEnumerable();
        }

        public override Task<Book> GetByIdWithRelationsAsync(int id)
        {
            return DbSet
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Author)
                .SingleOrDefaultAsync();
        }
    }
}
