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
        public async Task<IActionResult> GetAll()
        {
            List<Book> items = await _bookService.GetAll();
            return Ok(items);
        }
        [HttpGet("Book{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            Book item = await _bookService.GetById(id);
            if(item == null)
                return BadRequest("Haven't book with this id");
            
            return Ok(item);
        }


        //For Admin

        [HttpPost("AddBookToItems")]
        public async Task<IActionResult> AddBookToItems([FromBody]CreateBook request)
        {
            Book item = new Book()
            {
                Title = request.Title,
                Author = request.Author,
                Price = request.Price
            };
            await _bookService.AddBookToItems(item);
            return Ok(item);
        }
        [HttpPut("UpdateBook{id}")]
        public async Task<IActionResult> UpdateBook(int id,UpdateBook request)
        {
            Book itemForEdit = await _bookService.GetById(id);
            if (itemForEdit == null)
                return BadRequest("Not Found");
            itemForEdit.Title = request.Title;
            itemForEdit.Author = request.Author;
            itemForEdit.Price = request.Price;
            await _bookService.UpdateBook(itemForEdit);
            return Ok(itemForEdit);
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            Book deletedBook = await _bookService.DeleteBookFromItems(id);
            if (deletedBook == null)
                return BadRequest("Not Found");
            
            return Ok(deletedBook);
        }
    }
}
