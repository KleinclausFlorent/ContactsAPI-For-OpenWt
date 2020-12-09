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
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private MyContactsDbContext MyContactsDbContext
        {
            get { return Context as MyContactsDbContext;  }
        }

        public ContactRepository(MyContactsDbContext context): base(context) { }



        public async  Task<IEnumerable<Contact>> GetAllWithContactSkillExpertiseAsync()
        {
            return await MyContactsDbContext.Contacts
               .Include(c => c.ContactSkillExpertises)
               .ToListAsync();
        }

        public async Task<Contact> GetWithContactSkillExpertisesByIdAsync(int id)
        {
            return await MyContactsDbContext.Contacts
                .Include(c => c.ContactSkillExpertises)
                .SingleOrDefaultAsync(c => c.Id == id);
        }


    }
}
