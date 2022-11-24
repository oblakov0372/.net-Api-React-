using System.ComponentModel.DataAnnotations;

namespace BookProject.Resource.Api.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } 
        public int Price { get; set; } 

    }
}
