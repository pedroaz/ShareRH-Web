using PetBook.Domain.UsersDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetBook.Services.UsersServices
{
    public interface IUserService
    {
        Task AddUser(User user);
        bool Auth(string name, string password, out User user);
        Task DeleteUsers();
        string GenerateUserToken(User user);
        List<User> GetAllUsers();
    }
}
