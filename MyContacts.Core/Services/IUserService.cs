using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    public interface IUserService
    {

        Task<User> Authenticate(string username, string password);

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<User> Create(User user, string password);

        void Update(User user, string password = null);

        void Delete(int id);
    }
}
