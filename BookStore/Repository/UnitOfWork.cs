using BookStore.DAL.Models;

namespace BookStore.Repository
{
    public class UnitOfWork
    {
        private readonly DatabaseContext _context;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        private Repository<Author, int> _authorRepository;
        private Repository<Book, int> _bookRepository;
        private Repository<Order, int> _orderRepository;
        public Repository<Author, int> Author => _authorRepository ??= new AuthorRepository(_context);
        public Repository<Book, int> Book => _bookRepository ??= new BookRepository(_context);
        public Repository<Order, int> Order => _orderRepository ??= new OrderRepository(_context);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public int SaveChanges() => _context.SaveChanges();
    }
}
