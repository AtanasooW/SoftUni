using System;
using System.Collections.Generic;
using Footballers.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public Footballer()
        {
          this.TeamsFootballers = new HashSet<TeamFootballer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Restrictions.FootballerNameMinLenght)]
        [MaxLength(Restrictions.FootballerNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        [Range(Restrictions.FootballerPositionMinRange, Restrictions.FootballerPositionMaxRange)]
        public PositionType PositionType { get; set; }

        [Required]
        [Range(Restrictions.FootballerBestSkillMinRange, Restrictions.FootballerBestSkillMaxRange)]
        public BestSkillType BestSkillType { get; set; }

        [Required]
        [ForeignKey("Coach")]
        public int CoachId { get; set; }
        public Coach Coach { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
