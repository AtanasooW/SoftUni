using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int ScoredGoals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
    }
}
