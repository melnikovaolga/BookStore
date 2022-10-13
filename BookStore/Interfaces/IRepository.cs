using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Interfaces
{
    public interface IRepository<TItem, TKey> : IRepository<TItem>
    {
        Task<TItem> GetByIdAsync(TKey id);
        Task<TItem> GetByIdWithRelationsAsync(TKey id);
        ValueTask<TItem> FindAsync(TKey id);
    }
    public interface IRepository<TItem>
    {
        IAsyncEnumerable<TItem> GetAllAsync();
        IAsyncEnumerable<TItem> GetAllWithRelationsAsync();
        void Add(TItem item);
        void Remove(TItem item);
        bool Any(Expression<Func<TItem, bool>> expression);
    }
}
