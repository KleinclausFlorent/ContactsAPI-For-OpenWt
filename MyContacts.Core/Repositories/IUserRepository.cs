using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    /// <summary>
    /// interface for the User model
    /// defines the specific methods for this model 
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        // --- Methods ---
            Task<User> Authenticate(string username, string password);

            Task<User> Create(User userParam, string password);

            void Update(User user, string password = null);

            void Delete(int id);

    }
}
