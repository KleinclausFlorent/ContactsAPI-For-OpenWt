using Microsoft.EntityFrameworkCore;
using MyContacts.Core.Models;
using MyContacts.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Data.Repositories
{
    /// <summary>
    /// Class repository for the Expertise model, herit from repository and implements the Expertise interface repository
    /// </summary>
    public class ExpertiseRepository : Repository<Expertise>, IExpertiseRepository
    {
        // --- Attributes ---
            private MyContactsDbContext MyContactsDbContext
            {
                get { return Context as MyContactsDbContext; }
            }

        // --- Methods --
            public ExpertiseRepository(MyContactsDbContext context) : base(context) { }

            public async Task<IEnumerable<Expertise>> GetAllWithContactSkillExpertiseAsync()
            {
                return await MyContactsDbContext.Expertises
                   .Include(e => e.ContactSkillExpertises)
                   .ToListAsync();
            }

            public async Task<Expertise> GetWithContactSkillExpertisesByIdAsync(int id)
            {
                return await MyContactsDbContext.Expertises
                    .Include(e => e.ContactSkillExpertises)
                    .SingleOrDefaultAsync(e => e.Id == id);
            }

        

    }
}
