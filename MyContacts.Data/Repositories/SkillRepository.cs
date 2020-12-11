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
    /// Class repository for the Skill model, herit from repository and implements the skill interface repository
    /// </summary>
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        // --- Attributes  ---
            private MyContactsDbContext MyContactsDbContext
            {
                get { return Context as MyContactsDbContext; }
            }
        // --- Methods ---
            public SkillRepository(MyContactsDbContext context) : base(context) { }


            public async Task<IEnumerable<Skill>> GetAllWithContactSkillExpertiseAsync()
            {
                return await MyContactsDbContext.Skills
                   .Include(s => s.ContactSkillExpertises)
                   .ToListAsync();
            }

            public async Task<Skill> GetWithContactSkillExpertisesByIdAsync(int id)
            {
                return await MyContactsDbContext.Skills
                     .Include(s => s.ContactSkillExpertises)
                     .SingleOrDefaultAsync(s => s.Id == id);
            }
    }
}
