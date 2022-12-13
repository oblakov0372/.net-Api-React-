using BookProject.Resource.Api.Entities;
using BookProject.Resource.Api.Models.Book;

namespace BookProject.Resource.Api.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Task<Book> GetById(int id);
        public Task<UserCart> AddBookToCart(int id, int userId);
        public Task AddBookToItems(Book item);
        public Task<List<CartItem>> GetItemsInCart(int userId);
        public Task<UserCart> DeleteBookFromCart(int id,int userId);
        public Task<bool> ClearRowInCart(int id, int userId);
        public Task ClearCart(int userId);
        public Task<Book> DeleteBookFromItems(int id);
        public Task UpdateBook(Book item);


    }
}
