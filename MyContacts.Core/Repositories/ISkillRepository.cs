using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    /// <summary>
    /// interface for the Skill model
    /// defines the specific methods for this model 
    /// </summary>
    public interface ISkillRepository : IRepository<Skill>
    {
        // --- Methods ---
            Task<IEnumerable<Skill>> GetAllWithContactSkillExpertiseAsync();

            Task<Skill> GetWithContactSkillExpertisesByIdAsync(int id);

    }
}
