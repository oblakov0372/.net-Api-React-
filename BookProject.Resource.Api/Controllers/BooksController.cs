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
    public class BooksController : ControllerBase
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
        public IActionResult GetBookById(int id)
        {
            Book item = _bookService.GetById(id);
            if (item == null)
                return BadRequest("Haven't book with this id");

            return Ok(item);
        }

        [HttpGet("CartItems")]
        [Authorize]
        public IActionResult GetItemsInCart()
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            List<CartItem> cartItems = _bookService.GetItemsInCart(userId);
            return Ok(cartItems);
        }
        [Authorize]
        [HttpPost("AddBookToCart")]
        public IActionResult AddBookToCart(int bookId)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var bookInCart = _bookService.AddBookToCart(bookId,userId);
            if (bookInCart == null)
                return NotFound();
            return Ok(bookInCart);
        }
        [Authorize]
        [HttpDelete("RemoveBookFromCart{bookId}")]
        public IActionResult RemoveBookFromCart(int bookId)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var bookInCart = _bookService.DeleteBookFromCart(bookId,userId);
            if (bookInCart == null)
                return NotFound();
            return Ok(bookInCart);
        }
        [Authorize]
        [HttpDelete("ClearRowInCart{bookId}")]
        public IActionResult ClearRowInCart(int bookId)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            bool responce = _bookService.ClearRowInCart(bookId, userId);
            if (responce == false)
                return BadRequest("Not Found");
            return Ok("Cleared");
        }
        [Authorize]
        [HttpDelete("ClearCart")]
        public IActionResult ClearCart()
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _bookService.ClearCart(userId);
            return Ok();
        }
        //For Admin
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateBook{id}")]
        public IActionResult UpdateBook(int id, UpdateBook request)
        {
            Book itemForEdit = _bookService.GetById(id);
            if (itemForEdit == null)
                return BadRequest("Not Found");
            itemForEdit.Url = request.Url;
            itemForEdit.Title = request.Title;
            itemForEdit.Author = request.Author;
            itemForEdit.Price = request.Price;
            _bookService.UpdateBook(itemForEdit);
            return Ok(itemForEdit);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteBook{id}")]
        public IActionResult DeleteBook(int id)
        {
            Book deletedBook = _bookService.DeleteBookFromItems(id);
            if (deletedBook == null)
                return BadRequest("Not Found");

            return Ok(deletedBook);
        }
    }
}
