using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    public interface ISkillRepository : IRepository<Skill>
    {

        Task<IEnumerable<Skill>> GetAllWithContactSkillExpertiseAsync();

        Task<Skill> GetWithContactSkillExpertisesByIdAsync(int id);

    }
}
