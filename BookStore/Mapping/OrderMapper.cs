using BookStore.BL.Models;
using BookStore.DAL.Models;

namespace BookStore.Mapping
{
    public static class OrderMapper
    {
        public static OrderResponse ToResponse(this Order model)
        {
            return new OrderResponse
            {
                Id = model.Id,
                CustomerName = model.CustomerName,
                CreatedDate = model.CreatedDate,
                Books = model.OrderToBook?.Select(x => x.Book.ToResponse()).ToArray(),

            };
        }
    }
}
