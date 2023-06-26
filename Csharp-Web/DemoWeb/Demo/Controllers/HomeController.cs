using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NumbersToN()
        {
            ViewBag.Message = "Numbers to 1...";
			ViewBag.Count = -1;
            return View();
        }
		[HttpPost]
		public IActionResult NumbersToN(int count = -1)
		{
			ViewBag.Message = "Numbers from 1...";
			ViewBag.Count = count;
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}