using Footballers.Data.Models.Enums;
using Footballers.Data.Models;
using Footballers.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class ImportFootballerDTo
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(Restrictions.FootballerNameMinLenght)]
        [MaxLength(Restrictions.FootballerNameMaxLenght)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement("PositionType")]
        [Required]
        [Range(Restrictions.FootballerPositionMinRange, Restrictions.FootballerPositionMaxRange)]
        public int PositionType { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        [Range(Restrictions.FootballerBestSkillMinRange, Restrictions.FootballerBestSkillMaxRange)]
        public int BestSkillType { get; set; }
    }
}
