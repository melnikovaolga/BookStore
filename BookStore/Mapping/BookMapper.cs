using BookStore.BL.Models;
using BookStore.DAL.Models;

namespace BookStore.Mapping
{
    public static class BookMapper
    {
        public static BookResponse ToResponse(this Book model)
        {
            return new BookResponse
            {
                Id = model.Id,
                Name = model.Name,
                AuthorId = model.Author.Id,
                AuthorName = model.Author.Name,
                Price = model.Price,

            };
        }

        public static BookGridResponse ToGridResponse(this Book model)
        {
            return new BookGridResponse
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,

            };
        }
    }
}
