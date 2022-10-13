using Microsoft.AspNetCore.Mvc;
using BookStore.DAL.Models;
using BookStore.Repository;
using BookStore.Mapping;
using BookStore.BL.Models;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UnitOfWork _context;

        public OrderController(UnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async IAsyncEnumerable<OrderResponse> GetOrder()
        {
            await foreach (Order order in _context.Order.GetAllWithRelationsAsync())
                yield return order.ToResponse();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrder(int id)
        {
            var order = await _context.Order.GetByIdWithRelationsAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order.ToResponse();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
