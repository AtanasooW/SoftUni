namespace Trucks.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Utilities;
    public class Client
    {
        public Client()
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Restrictions.ClientMaxCharName)]
        [MinLength(Restrictions.ClientMinCharName)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(Restrictions.ClientMinCharNationality)]
        [MaxLength(Restrictions.ClientMaxCharNationality)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;
        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
