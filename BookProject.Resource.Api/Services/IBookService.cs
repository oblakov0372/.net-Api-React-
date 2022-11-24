using BookProject.Resource.Api.Entities;

namespace BookProject.Resource.Api.Services
{
    public interface IBookService
    {
        public Task<List<Book>> GetAll();
        public Task<Book> GetById(int id);
        public Task AddBookToOrder(Book item);
        public Task AddBookToItems(Book item);
        public Task DeleteBookFromOrder(int id);
        public Task<Book> DeleteBookFromItems(int id);
        public Task UpdateBook(Book item);


    }
}
