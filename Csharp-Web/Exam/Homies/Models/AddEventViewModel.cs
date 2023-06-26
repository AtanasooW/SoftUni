using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class AddEventViewModel
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        public ICollection<TypeViewModel> Types { get; set; } = new HashSet<TypeViewModel>();

        public string OrganiserId { get; set; }
    }
}
