using Microsoft.IdentityModel.Tokens;
using PetBook.Domain.UsersDomain;
using PetBook.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PetBook.Services.UsersServices
{
    public class UserService : IUserService
    {
        private readonly IPetBookDatabaseContext _dbContext;

        public UserService(IPetBookDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public bool Auth(string name, string password, out User user)
        {
            user = _dbContext.Users.ToList().Find(_ => _.Name.Equals(name));
            if (user is null) return false;
            if (user.Password != password) return false;
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public async Task DeleteUsers()
        {
            _dbContext.Users.RemoveRange(_dbContext.Users);
            await _dbContext.SaveChangesAsync();
        }

        public string GenerateUserToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySuperSecretKey@123"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>(){ 
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role)
                },
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
