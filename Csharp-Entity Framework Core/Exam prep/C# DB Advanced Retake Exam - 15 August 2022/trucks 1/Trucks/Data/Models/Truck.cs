using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(8)]
        public string? RegistrationNumber { get; set; }

        [StringLength(17)]

        public string VinNumber { get; set; }

        public int TankCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public Categories CategoryType { get; set; }
        public Types MakeType { get; set; }

        [ForeignKey("Despatcher")]

        public int DespatcherId { get; set; }
        public Despatcher Despatcher { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
