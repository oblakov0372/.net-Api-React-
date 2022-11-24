using System.ComponentModel.DataAnnotations;

namespace BookProject.Resource.Api.Models.Book
{
    public class CreateBook
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
