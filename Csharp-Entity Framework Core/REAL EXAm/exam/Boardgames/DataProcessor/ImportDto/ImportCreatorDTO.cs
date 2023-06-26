using Boardgames.Data.Models;
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
    [XmlType("Creator")]
    public class ImportCreatorDTO
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(Restrictions.CreatorFirstNameMinLenght)]
        [MaxLength(Restrictions.CreatorFirstNameMaxLenght)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [MinLength(Restrictions.CreatorLastNameMinLenght)]
        [MaxLength(Restrictions.CreatorLastNameMaxLenght)]
        public string LastName { get; set; }

        [XmlArray("Boardgames")]
        public ImportBoardgameDTO[] Boardgames { get; set; }
    }
}
