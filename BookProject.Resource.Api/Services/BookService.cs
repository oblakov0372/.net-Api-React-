using BookProject.Resource.Api.Entities;
using BookProject.Resource.Api.Models.Book;
using BookProject.Resource.Api.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
        public async Task<List<CartItem>> GetItemsInCart(int userId)
        {
            List<CartItem> cartItems = new List<CartItem>();
            List<UserCart> items = _context.UserCart.Where(i => i.UserId == userId).ToList();
            foreach(var item in items)
            {
                Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == item.BookId);
                if(book == null) continue;
                CartItem cartItem = new CartItem()
                {
                    Id = book.Id,
                    Url = book.Url,
                    Title = book.Title,
                    Author = book.Author,
                    Price = book.Price,
                    Count = item.Count
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
        public async Task<UserCart> AddBookToCart(int bookId, int userId)
        {
            Book bookItem = await _context.Books.Where(b => b.Id == bookId).FirstOrDefaultAsync();
            if (bookItem == null)
                return null;

            UserCart item = await _context.UserCart.Where(c => c.BookId == bookId && c.UserId==userId).FirstOrDefaultAsync();

            if (item != null)
            {
                item.Count += 1;
                _context.UserCart.Update(item);
            }
            else
            {
                item = new UserCart()
                {
                    UserId = userId,
                    BookId = bookId,
                    Count = 1
                };
                _context.UserCart.Add(item);
            }

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<UserCart> DeleteBookFromCart(int id, int userId)
        {
            var itemInCart = _context.UserCart.Where(o => o.BookId == id && o.UserId == userId).FirstOrDefault();
            if (itemInCart == null) return null;
            if(itemInCart.Count > 1)
            {
                itemInCart.Count--;
                _context.UserCart.Update(itemInCart);
            }
            else
                _context.UserCart.Remove(itemInCart);
            
            await _context.SaveChangesAsync();
            return itemInCart;
        }
        public async Task<bool> ClearRowInCart(int id, int userId)
        {
            var itemInCart = _context.UserCart.Where(o => o.BookId == id && o.UserId == userId).FirstOrDefault();
            if (itemInCart == null) return false;
            _context.UserCart.Remove(itemInCart);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task ClearCart(int userId)
        {
            List<UserCart> itemInCart = _context.UserCart.Where(c => c.UserId == userId).ToList();

            foreach (UserCart item in itemInCart)
            {
                _context.UserCart.Remove(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        
    }
}
