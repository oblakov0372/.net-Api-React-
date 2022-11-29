using BookProject.Resource.Api.Models.User;

namespace BookProject.Resource.Api.Services
{
    public class UserService : IUserService
    {
        public string Login(Authenticate model)
        {
            return $"{model.UserName} + {model.Password}";
        }
    }
}
