namespace BookStore.BL.Models
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public decimal Price { get; set; }
    }
}
