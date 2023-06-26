using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Export
{
    public class ExportProductDTO
    {
        [JsonProperty("name")]
        public string Name{ get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string Seller{ get; set; }
    }
}
