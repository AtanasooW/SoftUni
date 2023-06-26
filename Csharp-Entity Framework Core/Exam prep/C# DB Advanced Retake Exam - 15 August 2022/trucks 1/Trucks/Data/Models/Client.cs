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

        [MaxLength(Restrictions.ClientMaxCharName)]
        [MinLength(Restrictions.ClientMinCharName)]
        public string Name { get; set; }

        [MinLength(Restrictions.ClientMinCharNationality)]
        [MaxLength(Restrictions.ClientMaxCharNationality)]
        public string Nationality { get; set; }

        public string Type { get; set; }
        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
