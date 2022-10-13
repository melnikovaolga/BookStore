using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class AuthorRepository: Repository<Author, int>
    {
        public AuthorRepository(DatabaseContext dbContext)
            => DbSet = dbContext.Author;

        public override IAsyncEnumerable<Author> GetAllWithRelationsAsync()
        {
            return DbSet.Include(x => x.Books).AsAsyncEnumerable();
        }

        public override Task<Author> GetByIdWithRelationsAsync(int id)
        {
            return DbSet
                .Where(x => x.Id.Equals(id))
                .Include(x => x.Books)
                .SingleOrDefaultAsync();
        }
    }
}
