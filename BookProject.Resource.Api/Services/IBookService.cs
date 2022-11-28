using BookProject.Resource.Api.Entities;
using BookProject.Resource.Api.Models.Book;

namespace BookProject.Resource.Api.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public UserCart AddBookToCart(int id);
        public void AddBookToItems(Book item);
        public List<CartItem> GetItemsInCart();
        public UserCart DeleteBookFromCart(int id);
        public bool ClearRowInCart(int id);
        public void ClearCart();
        public Book DeleteBookFromItems(int id);
        public void UpdateBook(Book item);


    }
}
