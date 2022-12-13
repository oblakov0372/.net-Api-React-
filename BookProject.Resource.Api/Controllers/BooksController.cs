using BookProject.Resource.Api.Entities;
using BookProject.Resource.Api.Models.Book;
using BookProject.Resource.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookProject.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly IBookService _bookService; 
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
            
        }
        //For users
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> items = _bookService.GetAll();
            return Ok(items);
        }
        [HttpGet("Book{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            Book item = await _bookService.GetById(id);
            if (item == null)
                return BadRequest("Haven't book with this id");

            return Ok(item);
        }

        [HttpGet("CartItems")]
        [Authorize]
        public async Task<IActionResult> GetItemsInCart()
        {
            int userId = GetUserId();
            List<CartItem> cartItems = await _bookService.GetItemsInCart(userId);
            return Ok(cartItems);
        }
        [Authorize]
        [HttpPost("AddBookToCart")]
        public IActionResult AddBookToCart(int bookId)
        {
            int userId = GetUserId();
            var bookInCart = _bookService.AddBookToCart(bookId,userId);
            if (bookInCart == null)
                return NotFound();
            return Ok(bookInCart);
        }
        [Authorize]
        [HttpDelete("RemoveBookFromCart{bookId}")]
        public IActionResult RemoveBookFromCart(int bookId)
        {
            
            int userId = GetUserId();
            var bookInCart = _bookService.DeleteBookFromCart(bookId,userId);
            if (bookInCart == null)
                return NotFound();
            return Ok(bookInCart);
        }
        [Authorize]
        [HttpDelete("ClearRowInCart{bookId}")]
        public async Task<IActionResult> ClearRowInCart(int bookId)
        {
            int userId = GetUserId();
            bool responce = await _bookService.ClearRowInCart(bookId, userId);
            if (responce == false)
                return BadRequest("Not Found");
            return Ok("Cleared");
        }
        [Authorize]
        [HttpDelete("ClearCart")]
        public IActionResult ClearCart()
        {
            int userId = GetUserId();
            _bookService.ClearCart(userId);
            return Ok();
        }
        //For Admin
        [HttpPost("AddBookToItems")]
        public IActionResult AddBookToItems([FromBody] CreateBook request)
        {
            Book item = new Book()
            {
                Url = request.Url,
                Title = request.Title,
                Author = request.Author,
                Price = request.Price
            };
            _bookService.AddBookToItems(item);
            return Ok(item);
        }
        [HttpPut("UpdateBook{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBook request)
        {
            Book itemForEdit = await _bookService.GetById(id);
            if (itemForEdit == null)
                return BadRequest("Not Found");
            itemForEdit.Url = request.Url;
            itemForEdit.Title = request.Title;
            itemForEdit.Author = request.Author;
            itemForEdit.Price = request.Price;
            await _bookService.UpdateBook(itemForEdit);
            return Ok(itemForEdit);
        }
        [HttpDelete("DeleteBook{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            Book deletedBook = await _bookService.DeleteBookFromItems(id);
            if (deletedBook == null)
                return BadRequest("Not Found");

            return Ok(deletedBook);
        }
    }
}
