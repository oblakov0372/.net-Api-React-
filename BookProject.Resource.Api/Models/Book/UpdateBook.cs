using System.ComponentModel.DataAnnotations;

namespace BookProject.Resource.Api.Models.Book
{
    public class UpdateBook
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}
