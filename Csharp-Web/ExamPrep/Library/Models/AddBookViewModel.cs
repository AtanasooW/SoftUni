using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        public string Rating { get; set; } = null!;
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        public ICollection<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}
