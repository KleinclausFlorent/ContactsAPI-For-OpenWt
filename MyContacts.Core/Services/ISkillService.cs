using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllSkills();

        Task<Skill> GetSkillById(int id);

        Task<Skill> CreateSkill(Skill newSkill);

        Task UpdateSkill(Skill skillToBeUpdated, Skill skill);

        Task DeleteSkill(Skill skill);
    }
}
