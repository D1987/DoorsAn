using System.Collections.Generic;
using System.Threading.Tasks;
using DoorsAn1.Data.Models;

namespace DoorsAn1.Data.Services.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}