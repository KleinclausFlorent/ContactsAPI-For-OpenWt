using MyContacts.Core;
using MyContacts.Core.Models;
using MyContacts.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Service.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _unitOfWork.Users.Authenticate(username, password);
        }

        public async Task<User> Create(User user, string password)
        {
            await _unitOfWork.Users.Create(user, password);

            await _unitOfWork.CommitAsync();

            return user;
        }

        public void Delete(int id)
        {
            _unitOfWork.Users.Delete(id);
            _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }

        public void Update(User user, string password = null)
        {
            _unitOfWork.Users.Update(user, password);
            _unitOfWork.CommitAsync();
        }
    }
}
