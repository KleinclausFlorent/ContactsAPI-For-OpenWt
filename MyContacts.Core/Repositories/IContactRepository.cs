using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetAllWithContactSkillExpertiseAsync();

        Task<Contact> GetWithContactSkillExpertisesByIdAsync(int id);

    }
}
