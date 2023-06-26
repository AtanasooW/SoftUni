using Demo.Infrastructure.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options)
            : base(options)
        {
        }
        DbSet<Product> Products { get; set; } = null!;
    }
}
