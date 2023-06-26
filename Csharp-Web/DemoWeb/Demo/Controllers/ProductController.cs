namespace Demo.Controllers
{
	using Demo.Models.Product;
	using Demo.Seeding;
	using Microsoft.AspNetCore.Mvc;
	using static Seeding.Product;
	public class ProductController : Controller
	{
		private readonly IEnumerable<ProductViewModel> products = Product.Products;
        public IActionResult Index()
		{
			return View(products);
		}

		[HttpPost]
        public IActionResult Index(string search)
        {
			if (String.IsNullOrWhiteSpace(search))
			{
                return View(products);
            }
            IEnumerable<ProductViewModel> SearchedProducts = products.Where(p=> p.Name.ToLower().Contains(search.ToLower()));
			if (SearchedProducts == null)
			{
                return View(products);
            }
            return View(SearchedProducts);
        }
		public IActionResult Details(Guid id)
		{
			var product = products.Where(p => p.Id == id).First();
			return View(product);
		}
    }
}
