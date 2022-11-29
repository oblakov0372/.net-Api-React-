using BookProject.Resource.Api.Models.User;
using BookProject.Resource.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(Authenticate model)
        {
            string response = _userService.Login(model);
            return Ok(response);
        }
    }
}
