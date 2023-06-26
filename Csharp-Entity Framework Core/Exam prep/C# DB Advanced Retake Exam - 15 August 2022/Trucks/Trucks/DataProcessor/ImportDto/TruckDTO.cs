using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class TruckDTO
    {
        [XmlElement("RegistrationNumber")]
        [MinLength(8)]
        [MaxLength(8)]
        public string? RegistrationNumber { get; set; }



        [XmlElement("VinNumber")]
        [Required]
        [MinLength(17)]
        [MaxLength(17)]
        public string VinNumber { get; set; } = null!;



        [XmlElement("TankCapacity")]
        [Range(95,1420)]
        public int TankCapacity { get; set; }


        [XmlElement("CargoCapacity")]
        [Range(5000,29000)]
        public int CargoCapacity { get; set; }


        [XmlElement("CategoryType")]

        [Range(0,3)]
        public CategoryType CategoryType { get; set; }


        [XmlElement("MakeType")]
        [Range(0,4)]
        public MakeType MakeType { get; set; }

    }
}
