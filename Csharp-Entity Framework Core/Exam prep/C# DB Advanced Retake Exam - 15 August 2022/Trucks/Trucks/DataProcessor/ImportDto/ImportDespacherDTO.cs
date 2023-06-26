using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models;
using Trucks.Utilities;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despacher")]
    public class ImportDespacherDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(Restrictions.DespatcherMinCharName)]
        [MaxLength(Restrictions.DespatcherMaxCharName)]
        public string Name { get; set; }
        [XmlElement("Position")]
        public string Position { get; set; }
        [XmlArray("Trucks")]
        public TruckDTO[] Trucks { get; set; }
    }
}
