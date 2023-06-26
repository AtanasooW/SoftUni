using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models;
using Trucks.Utilities;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDTO
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(Restrictions.ClientMaxCharName)]
        [MinLength(Restrictions.ClientMinCharName)]
        public string Name { get; set; } = null!;

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(Restrictions.ClientMinCharNationality)]
        [MaxLength(Restrictions.ClientMaxCharNationality)]
        public string Nationality { get; set; } = null!;

        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; } = null!;


        [JsonProperty("Trucks")]
        public int[] TruckId{ get; set; }
    }
}
