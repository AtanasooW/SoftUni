using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;
        public BookService(LibraryDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var book = new Book()
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                Rating = decimal.Parse(model.Rating),
                CategoryId = model.CategoryId
            };
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, int bookId)
        {
            bool alreadyAdded = await dbContext.IdentityUsersBooks.AnyAsync(x => x.CollectorId == userId && x.BookId == bookId);
            if (!alreadyAdded)
            {

                var userBook = new IdentityUserBook()
                {
                    BookId = bookId,
                    CollectorId = userId
                };

                await dbContext.IdentityUsersBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await dbContext.Books.Select(x => new AllBookViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Rating = x.Rating,
                Category = x.Category.Name,
                ImageUrl = x.ImageUrl
            }).ToListAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllMineBooksAsync(string userId)
        {
            return await dbContext.IdentityUsersBooks
                .Where(x => x.CollectorId == userId)
                .Select(x => new AllBookViewModel
                {
                    Id = x.Book.Id,
                    Title = x.Book.Title,
                    Author = x.Book.Author,
                    Description = x.Book.Description,
                    Category = x.Book.Category.Name,
                    ImageUrl = x.Book.ImageUrl
                }).ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books
                .Where(x => x.Id == id)
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Rating = x.Rating,
                    CategoryId = x.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await dbContext.Categories
                .Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            var model = new AddBookViewModel 
            {
                Categories = categories 
            };

            return model;
        }

        public async Task RemoveBookFromCollectionAsync(string userId, int bookId)
        {
            bool IsHere = await dbContext.IdentityUsersBooks.AnyAsync(x => x.CollectorId == userId && x.BookId == bookId);
            if (IsHere)
            {
                var userBook = new IdentityUserBook()
                {
                    BookId = bookId,
                    CollectorId = userId
                };

                dbContext.IdentityUsersBooks.Remove(userBook);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
