using BookStore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Repository
{
    public abstract class Repository<TItem, TKey>: Repository<TItem>, IRepository<TItem, TKey>
        where TItem : class, IEntity<TKey>
    {
        public virtual Task<TItem> GetByIdAsync(TKey id) => DbSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
        public abstract Task<TItem> GetByIdWithRelationsAsync(TKey id);
        public virtual ValueTask<TItem> FindAsync(TKey id) => DbSet.FindAsync(id);
    }

    public abstract class Repository<TItem> : IRepository<TItem>
    where TItem : class
    {
        protected DbSet<TItem> DbSet;

        public virtual IAsyncEnumerable<TItem> GetAllAsync() => DbSet.AsAsyncEnumerable();
        public abstract IAsyncEnumerable<TItem> GetAllWithRelationsAsync();
        public virtual void Add(TItem item) => DbSet.Add(item);
        public virtual void Remove(TItem item) => DbSet.Remove(item);
        public virtual bool Any(Expression<Func<TItem, bool>> expression) => DbSet.Any(expression);

    }
}
