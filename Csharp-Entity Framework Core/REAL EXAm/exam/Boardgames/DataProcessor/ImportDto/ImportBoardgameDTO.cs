using Boardgames.Data.Models.Enums;
using Boardgames.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(Restrictions.BoardgameNameMinLenght)]
        [MaxLength(Restrictions.BoardgameNameMaxLenght)]
        public string Name { get; set; }

        [XmlElement("Rating")]
        [Required]
        [Range(Restrictions.BoardgameRatingMinLenght, Restrictions.BoardgameRatingMaxLenght)]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Required]
        [Range(Restrictions.BoardgameYearPublishedMinRange, Restrictions.BoardgameYearPublishedMaxRange)]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Required]
        [Range(Restrictions.BoardgameCategoryTypeMinRange, Restrictions.BoardgameCategoryTypeMaxRange)]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        [Required]
        public string Mechanics { get; set; }
    }
}
