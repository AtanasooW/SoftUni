using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }
        [Key]
        public int GameId { get; set; }

        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        [NotMapped]
        public virtual Team HomeTeam { get; set; }

        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }
        [NotMapped]
        public virtual Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        //?
        public decimal HomeTeamBetRate { get; set; }

        public decimal AwayTeamBetRate { get; set; }

        public decimal DrawBetRate { get; set; }
        public int Result { get; set; }

        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }
        public ICollection<Bet> Bets { get; set; }

    }
}
