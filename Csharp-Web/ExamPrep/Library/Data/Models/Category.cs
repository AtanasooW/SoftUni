using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
             Books = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
//Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 5 and max length 50 (required)
//• Has Books – a collection of type Books
