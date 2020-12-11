using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    /// <summary>
    /// interface for the User service
    /// defines the specific methods for this model  which will be called in the Service tier
    /// </summary>
    public interface IUserService
    {
        // --- Methods ---
            Task<User> Authenticate(string username, string password);

            Task<IEnumerable<User>> GetAllUsers();

            Task<User> GetUserById(int id);

            Task<User> Create(User user, string password);

            void Update(User user, string password = null);

            void Delete(int id);
    }
}
