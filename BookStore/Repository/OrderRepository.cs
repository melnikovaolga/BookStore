using BookStore.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class OrderRepository: Repository<Order, int>
    {
        public OrderRepository(DatabaseContext dbContext)
            => DbSet = dbContext.Order;
        public override Task<Order> GetByIdWithRelationsAsync(int id)
        {
            return DbSet
                .Where(x => x.Id.Equals(id))
                .Include(x => x.OrderToBook)
                .ThenInclude(x => x.Book)
                .ThenInclude(x => x.Author)
                .SingleOrDefaultAsync();
        }

        public override IAsyncEnumerable<Order> GetAllWithRelationsAsync()
        {
            return DbSet.Include(x => x.OrderToBook).ThenInclude(x => x.Book).ThenInclude(x => x.Author).AsAsyncEnumerable();
        }
    }
}
