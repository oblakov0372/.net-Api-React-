using BookProject.Resource.Api.Entities;
using BookProject.Resource.Api.Models.Book;
using BookProject.Resource.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksContoller : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksContoller(IBookService bookService)
        {
            _bookService = bookService;
        }
        //For users
        [HttpGet("Books")]
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
        [HttpPost("AddBookToCart")]
        public IActionResult AddBookToCart(int bookId)
        {
            var bookInCart = _bookService.AddBookToCart(bookId);
            if (bookInCart == null)
                return NotFound();
            return Ok(bookInCart);
        }

        [HttpDelete("RemoveBookFromCart{bookId}")]
        public IActionResult RemoveBookFromCart(int bookId)
        {
            var bookInCart = _bookService.DeleteBookFromCart(bookId);
            if (bookInCart == null)
                return NotFound();
            return Ok(bookInCart);
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
