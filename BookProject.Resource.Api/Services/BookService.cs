using BookProject.Resource.Api.Entities;
using BookProject.Resource.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookProject.Resource.Api.Services
{
    public class BookService : IBookService
    {
        private readonly ProjectDbContext _context;

        public BookService(ProjectDbContext context)
        {
            _context = context;
        }
        //For Admin
        public void AddBookToItems(Book item)
        {
            _context.Books.Add(item);
            _context.SaveChanges();
        }

        public Book DeleteBookFromItems(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book == null) return null;
            _context.Books.Remove(book);
            _context.SaveChanges();
            return book;
        }

        public void UpdateBook(Book item)
        {
            if (_context.Books.Where(b => b.Id == item.Id) == null) return;
            _context.Books.Update(item);
            _context.SaveChanges();
        }


        // For Users

        public UserCart AddBookToCart(int bookId)
        {
            List<int> bookIds = _context.Books.Select(o => o.Id).ToList();
            if (bookIds.Where(id => id == bookId).FirstOrDefault() == null)
                return null;
            UserCart itemForCart = new UserCart()
            {
                UserId = 2,
                BookId = bookId,
            };

            _context.UserCart.Add(itemForCart);
            _context.SaveChanges();
            return itemForCart;
        }

        public UserCart DeleteBookFromCart(int id)
        {
            var itemInCart = _context.UserCart.Where(o => o.BookId == id && o.UserId == 2).FirstOrDefault();
            if (itemInCart == null) return null;
            _context.UserCart.Remove(itemInCart);
            _context.SaveChanges();
            return itemInCart;
        }

        public Book GetById(int id)
        {
            return _context.Books.SingleOrDefault(x => x.Id == id);
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void ClearCart()
        {
            List<UserCart> itemInCart = _context.UserCart.Where(c => c.UserId == 2).ToList();

            foreach (UserCart item in itemInCart)
            {
                _context.UserCart.Remove(item);
            }
            _context.SaveChanges();
        }
    }
}
