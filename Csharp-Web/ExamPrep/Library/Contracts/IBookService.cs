using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task AddBookToCollectionAsync(string userId, int bookId);
        public Task AddBookAsync(AddBookViewModel model);
        public Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        public Task<IEnumerable<AllBookViewModel>> GetAllMineBooksAsync(string userId);
        public Task<BookViewModel> GetBookByIdAsync(int id);
        public Task RemoveBookFromCollectionAsync(string userId, int bookId);
        public Task<AddBookViewModel> GetNewAddBookModelAsync();
    }
}
