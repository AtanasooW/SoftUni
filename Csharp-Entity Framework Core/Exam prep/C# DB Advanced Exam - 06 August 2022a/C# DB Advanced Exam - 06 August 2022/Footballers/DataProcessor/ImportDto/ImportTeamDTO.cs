using Footballers.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDTO
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(Restrictions.TeamNameMinLenght)]
        [MaxLength(Restrictions.TeamNameMaxLenght)]
        [RegularExpression(Restrictions.TeamNamePatter)]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(Restrictions.TeamNationalityMinLenght)]
        [MaxLength(Restrictions.TeamNationalityMaxLenght)]
        public string Nationality { get; set; }

        [JsonProperty("Trophies")]
        [Required]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] FootballersIDs{ get; set; }
    }
}
