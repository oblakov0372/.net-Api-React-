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
        public async Task AddBookToItems(Book item)
        {
            _context.Books.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> DeleteBookFromItems(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null) return null;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBook(Book item)
        {
            if (_context.Books.Where(b => b.Id == item.Id) == null) return;
            _context.Books.Update(item);
            await _context.SaveChangesAsync();
        }


        // For Users
        public async Task AddBookToOrder(Book item)
        {
            Order itemForOrder = new Order()
            {
                UserId = 1,
                BookId = item.Id,
            };

            _context.Orders.Add(itemForOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookFromOrder(int id)
        {
            var order = _context.Orders.Where(o => o.BookId == id).FirstOrDefault();
            if (order == null) return;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        
    }
}
