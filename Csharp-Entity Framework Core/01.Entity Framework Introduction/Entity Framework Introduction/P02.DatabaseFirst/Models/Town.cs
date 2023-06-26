using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SoftUni.Models
{
    public class Town
    {
        public Town()
        {
            Addresses = new HashSet<Address>();
        }


        public int TownId { get; set; }

        public string Name { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
