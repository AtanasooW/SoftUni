using Boardgames.Data.Models;
using Boardgames.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDTO
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(Restrictions.SellerNameMinLenght)]
        [MaxLength(Restrictions.SellerNameMaxLenght)]
        public string Name { get; set; }

        [JsonProperty("Address")]
        [Required]
        [MinLength(Restrictions.SellerAddressMinLenght)]
        [MaxLength(Restrictions.SellerAddressMaxLenght)]
        public string Address { get; set; }

        [JsonProperty("Country")]
        [Required]
        public string Country { get; set; }

        [JsonProperty("Website")]
        [Required]
        [RegularExpression(Restrictions.SellerWebsitePatter)]
        public string Website { get; set; }

        [JsonProperty("Boardgames")]
        [Required]
        public int[] BoardgamesIds { get; set; }
    }
}
