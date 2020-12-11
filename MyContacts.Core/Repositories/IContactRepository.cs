using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    /// <summary>
    /// interface for the Contact model
    /// defines the specific methods for this model 
    /// </summary>
    public interface IContactRepository : IRepository<Contact>
    {
        // ---  Methods ---
            Task<IEnumerable<Contact>> GetAllWithContactSkillExpertiseAsync();

            Task<Contact> GetWithContactSkillExpertisesByIdAsync(int id);

    }
}
