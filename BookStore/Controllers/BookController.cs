using Microsoft.AspNetCore.Mvc;
using BookStore.DAL.Models;
using BookStore.Repository;
using BookStore.Mapping;
using BookStore.BL.Models;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly UnitOfWork _context;

        public BookController(UnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async IAsyncEnumerable<BookResponse> GetBook()
        {
            await foreach (Book book in _context.Book.GetAllWithRelationsAsync())
                yield return book.ToResponse();
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetBook(int id)
        {
            var book = await _context.Book.GetByIdWithRelationsAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book.ToResponse();
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
