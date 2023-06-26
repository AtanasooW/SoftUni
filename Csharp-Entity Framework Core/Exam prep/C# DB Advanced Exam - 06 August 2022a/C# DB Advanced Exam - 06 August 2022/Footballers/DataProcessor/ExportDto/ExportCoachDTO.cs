using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachDTO
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }
        [XmlElement("CoachName")]
        public string CoachName { get; set; }
        [XmlArray("Footballers")]
        public ExportFootballerDTO[] Footballers { get; set; }
        
    }
}
