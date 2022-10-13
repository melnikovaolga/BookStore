namespace BookStore.BL.Models
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<BookGridResponse>? Books { get; set; }
    }
}
