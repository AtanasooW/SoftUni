using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        [ForeignKey("Footballer")]
        public int FootballerId { get; set; }
        public Footballer Footballer { get; set; }
    }
}
