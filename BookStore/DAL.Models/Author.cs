using BookStore.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DAL.Models
{
    public class Author: IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
