using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Homies.Data.Models
{
    public class Event
    {
        public Event()
        {
            this.EventsParticipants = new HashSet<EventParticipant>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey("Organiser")]
        public string OrganiserId { get; set; }
        [Required]
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }

        [Required]
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public Models.Type Type { get; set; } = null!;

        public ICollection<EventParticipant> EventsParticipants { get; set; }

    }
}