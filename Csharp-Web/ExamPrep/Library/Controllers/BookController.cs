using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        public BookController(IBookService _bookService)
        {
            this.bookService = _bookService;
        }
        public async Task<IActionResult> All()
        {
            var models = await bookService.GetAllBooksAsync();
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await bookService.GetNewAddBookModelAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            decimal rating;
            if (!decimal.TryParse(model.Rating,out rating) || rating < 0 || rating > 10)
            {
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await bookService.AddBookAsync(model);
            return RedirectToAction("All");
        }

        public async Task<IActionResult> Mine()
        {
            var models = await bookService.GetAllMineBooksAsync(GetUserID());
            return View(models);
        }
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All");
            }

            var userId = GetUserID();
            await bookService.AddBookToCollectionAsync(userId, id);
            return RedirectToAction("All");
        }
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("Mine");
            }

            var userId = GetUserID();
            await bookService.RemoveBookFromCollectionAsync(userId, id);
            return RedirectToAction("Mine");
        }
    }
}
