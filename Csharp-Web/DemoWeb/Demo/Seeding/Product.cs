using Demo.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Seeding
{
	public static class Product
	{
		public static IEnumerable<ProductViewModel> Products = new List<ProductViewModel>()
		{

		new ProductViewModel()
		{
			Id = Guid.NewGuid(),
			Name = "Red Label",
			Price = 20m
		},
		 new ProductViewModel()
		{
			Id = Guid.NewGuid(),
			Name = "Ruski Standard",
			Price = 18.5m
		},
		 new ProductViewModel()
		{
			Id = Guid.NewGuid(),
			Name = "Rakia",
			Price = 2000m
		}
	};
	}
}
