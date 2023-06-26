using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Models.Products
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public string ImgPath { get; set; }
    }
}
