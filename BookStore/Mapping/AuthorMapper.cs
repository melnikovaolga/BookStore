using BookStore.BL.Models;
using BookStore.DAL.Models;

namespace BookStore.Mapping
{
    public static class AuthorMapper
    {
        public static AuthorResponse ToResponse(this Author model)
        {
            var books = model.Books?.Select(x => x.ToGridResponse()).ToList();
            return new AuthorResponse
            {
                Id = model.Id,
                Name = model.Name,
                Books = books

            };
        }

        public static AuthorGridResponse ToGridResponse(this Author model)
        {
            return new AuthorGridResponse
            {
                Id = model.Id,
                Name = model.Name

            };

        }
    }
}
