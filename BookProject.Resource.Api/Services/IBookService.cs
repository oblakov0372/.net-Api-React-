using BookProject.Resource.Api.Entities;
using BookProject.Resource.Api.Models.Book;

namespace BookProject.Resource.Api.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public UserCart AddBookToCart(int id, int userId);
        public void AddBookToItems(Book item);
        public List<CartItem> GetItemsInCart(int userId);
        public UserCart DeleteBookFromCart(int id,int userId);
        public bool ClearRowInCart(int id, int userId);
        public void ClearCart(int userId);
        public Book DeleteBookFromItems(int id);
        public void UpdateBook(Book item);


    }
}
