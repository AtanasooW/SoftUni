using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Import
{
    public class ImportProductDTO
    {
        public string Name { get; set; } = null!;
        public double Price{ get; set; }
        public int SellerId { get; set; }
        [JsonProperty("BuyerId")]
        public int? BuyerId { get; set; }
    }
}
