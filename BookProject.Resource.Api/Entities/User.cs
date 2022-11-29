using System.ComponentModel.DataAnnotations;

namespace BookProject.Resource.Api.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }

    }
}
