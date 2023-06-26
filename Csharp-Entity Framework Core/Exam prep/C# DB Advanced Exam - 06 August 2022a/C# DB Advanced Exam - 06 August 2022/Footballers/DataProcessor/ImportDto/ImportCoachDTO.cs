using Footballers.Data.Models;
using Footballers.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachDTO
    {
        [XmlElement("Name")]
        [MinLength(Restrictions.CoachNameMinLenght)]
        [MaxLength(Restrictions.CoachNameMaxLenght)]
        public string Name { get; set; }

        [XmlElement("Nationality")]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public ImportFootballerDTo[] Footballers { get; set; }
    }
}
