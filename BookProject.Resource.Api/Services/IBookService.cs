using BookProject.Resource.Api.Entities;

namespace BookProject.Resource.Api.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public UserCart AddBookToCart(int id);
        public void AddBookToItems(Book item);
        public UserCart DeleteBookFromCart(int id);
        public void ClearCart();
        public Book DeleteBookFromItems(int id);
        public void UpdateBook(Book item);


    }
}
