using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
        }
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int SquadNumber { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int Assists { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
