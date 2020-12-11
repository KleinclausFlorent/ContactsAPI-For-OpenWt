using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    /// <summary>
    /// interface for the Expertise model
    /// defines the specific methods for this model 
    /// </summary>
    public interface IExpertiseRepository : IRepository<Expertise>
    {
        // ---  Methods ---
            Task<IEnumerable<Expertise>> GetAllWithContactSkillExpertiseAsync();

            Task<Expertise> GetWithContactSkillExpertisesByIdAsync(int id);

    }
}
