using BookStore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.DAL.Models
{
    public class Order: IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? CustomerName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderToBook>? OrderToBook { get; set; }
    }
}
