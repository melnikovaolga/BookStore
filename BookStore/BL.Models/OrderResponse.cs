using System.ComponentModel.DataAnnotations;

namespace BookStore.BL.Models
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<BookResponse>? Books { get; set; }
    }
}
