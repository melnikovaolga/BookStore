using BookStore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models
{
    public class OrderToBook: IEntity<int>
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }
        public int BookId { get; set; }

    }
}
