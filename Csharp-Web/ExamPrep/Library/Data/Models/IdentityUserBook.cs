using Library.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        [Required]
        [ForeignKey("Collector")]
        public string CollectorId { get; set; } = null!;
        public IdentityUser Collector { get; set; } = null!;

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
//CollectorId – a string, Primary Key, foreign key (required)
//• Collector – IdentityUser
//• BookId – an integer, Primary Key, foreign key (required)
//• Book – Book