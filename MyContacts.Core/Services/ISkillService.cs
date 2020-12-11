using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    /// <summary>
    /// interface for the Skill service
    /// defines the specific methods for this model  which will be called in the Service tier
    /// </summary>
    public interface ISkillService
    {
        // --- Methods ---
            Task<IEnumerable<Skill>> GetAllSkills();

            Task<Skill> GetSkillById(int id);

            Task<Skill> CreateSkill(Skill newSkill);

            Task UpdateSkill(Skill skillToBeUpdated, Skill skill);

            Task DeleteSkill(Skill skill);
    }
}
