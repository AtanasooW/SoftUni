﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("partId")]
    public class CarPartsDTO
    {
        [XmlElement("id")]
        public int PartId { get; set; }
    }
}
