using Microsoft.AspNetCore.Mvc;
using BookStore.DAL.Models;
using BookStore.Repository;
using BookStore.BL.Models;
using BookStore.Mapping;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly UnitOfWork _context;

        public AuthorController(UnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Author/with-books
        [HttpGet("with-books")]
        public async IAsyncEnumerable<AuthorResponse> GetAuthor()
        {
            await foreach (Author author in _context.Author.GetAllWithRelationsAsync())
                yield return author.ToResponse();
        }


        // GET: api/Author
        [HttpGet]
        public async IAsyncEnumerable<AuthorGridResponse> GetAuthorInfo()
        {
            await foreach (Author author in _context.Author.GetAllAsync())
                yield return author.ToGridResponse();
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponse>> GetAuthor(int id)
        {
            var author = await _context.Author.GetByIdWithRelationsAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author.ToResponse();
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
