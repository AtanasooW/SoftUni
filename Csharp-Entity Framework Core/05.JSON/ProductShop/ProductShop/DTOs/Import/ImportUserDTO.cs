using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Import
{
    public class ImportUserDTO
    {
        [JsonProperty("firstName")]
        public string? FirstName{ get; set; }

        [JsonProperty("lastName")]
        public string LastName{ get; set; }

        [JsonProperty("age")]
        public int? Age{ get; set; }
    }
}
