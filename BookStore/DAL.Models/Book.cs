using BookStore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DAL.Models
{
    public class Book: IEntity<int>
    {

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
        public int AuthorId { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
