using Microsoft.EntityFrameworkCore;
using MyContacts.Core.Models;
using MyContacts.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Data.Repositories
{
    /// <summary>
    /// Class repository for the user model, herit from repository and implements the user interface repository
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        // --- Attributes ---   
            private MyContactsDbContext MyContactsDbContext
            {
                get { return Context as MyContactsDbContext; }
            }

        // --- Methods ---
            // -- Public --
                public UserRepository(MyContactsDbContext context) : base(context) { }

                public async Task<User> Authenticate(string username, string password)
                {
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return null;

                    var user = await MyContactsDbContext.Users.SingleOrDefaultAsync(x => x.Username == username);

                    //Check if username exists
                    if (user == null) return null;

                    // Check if password is correct
                    if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

                    //Authentification succesfull
                    return user;
                }

                public async Task<User> Create(User user, string password)
                {
                    //Validation
                    if (string.IsNullOrWhiteSpace(password)) throw new Exception("Password is required");

                    var resultUser = await MyContactsDbContext.Users.AnyAsync(x => x.Username == user.Username);
                    if (resultUser)
                        throw new Exception("Username \"" + user.Username + " \" is already taken");
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(password, out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    await MyContactsDbContext.Users.AddAsync(user);

                    return user;
                }

                public void Delete(int id)
                {
                    var user = MyContactsDbContext.Users.Find(id);
                    if (user != null)
                    {
                        MyContactsDbContext.Users.Remove(user);
                    }
                }

                public void Update(User userParam, string password = null)
                {
                    var user = MyContactsDbContext.Users.Find(userParam.Id);

                    if (user == null)
                        throw new Exception("User not found");

                    if (userParam.Username != user.Username)
                    {
                        // username has changed so check if the new username is already taken
                        if (MyContactsDbContext.Users.Any(x => x.Username == userParam.Username))
                            throw new Exception("Username \"" + user.Username + " \" is already taken");
                    }

                    //Update user properties
                    // TODO : Verify if contactId do exist // Copy boolean admin and copy contact if relevant
                    user.ContactId = userParam.ContactId;
                    user.Username = userParam.Username;

                    //Update password if it was entered
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        byte[] passwordHash, passwordSalt;
                        CreatePasswordHash(password, out passwordHash, out passwordSalt);

                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                    }

                    MyContactsDbContext.Users.Update(user);
                }

            // -- Private --
                private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
                {
                    if (password == null) throw new ArgumentNullException("password");
                    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

                    using (var hmac = new System.Security.Cryptography.HMACSHA512())
                    {
                        passwordSalt = hmac.Key;
                        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    }

                }

                private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
                {
                    if (password == null) throw new ArgumentNullException("password");
                    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
                    if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash(64 bytes expected).", "passwordHash");
                    if (storedSalt.Length != 128) throw new ArgumentException("Invalid lenght of password salt (128 bytes expected).", "passwordHash");

                    using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
                    {
                        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                        for (int i = 0; i < computedHash.Length; i++)
                        {
                            if (computedHash[i] != storedHash[i]) return false;
                        }
                    }

                    return true;
                }
    }
}
