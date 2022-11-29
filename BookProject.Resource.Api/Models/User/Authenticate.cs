using System.ComponentModel.DataAnnotations;

namespace BookProject.Resource.Api.Models.User
{
    public class Authenticate
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
