using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    public interface IExpertiseRepository : IRepository<Expertise>
    {
        Task<IEnumerable<Expertise>> GetAllWithContactSkillExpertiseAsync();

        Task<Expertise> GetWithContactSkillExpertisesByIdAsync(int id);

    }
}
