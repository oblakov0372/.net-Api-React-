using BookProject.Resource.Api.Entities;
using BookProject.Resource.Api.Models.User;
using BookProject.Resource.Api.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookProject.Resource.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ProjectDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ProjectDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string Login(Authenticate model)
        {
            var authenticatedUser = Authenticate(model);
            if (authenticatedUser == null)
                return null;

            return GenerateJwt(authenticatedUser);
        }

        private User Authenticate(Authenticate model)
        {
            return _context.Users.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
        }
        private string GenerateJwt(User user)
        {
            var tokenDescriptor = CreateTokenDescriptor(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer" + jwt);
            }
            return jwt;
        }

        private SecurityTokenDescriptor CreateTokenDescriptor(User user)
        {
            var issuer = _configuration.GetValue<string>("Jwt:Issuer");
            var audience = _configuration.GetValue<string>("Jwt:Audience").ToString();
            var key = Encoding.ASCII.GetBytes
            (_configuration.GetValue<string>("Jwt:Key").ToString());
            return new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("IsAdmin", user.isAdmin.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
        }
    }
}
