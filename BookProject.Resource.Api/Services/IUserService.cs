using BookProject.Resource.Api.Models.User;

namespace BookProject.Resource.Api.Services
{
    public interface IUserService
    {
        public string Login(Authenticate model);
    }
}
