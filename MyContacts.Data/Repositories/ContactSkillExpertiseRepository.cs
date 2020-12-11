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
    public class ContactSkillExpertiseRepository : Repository<ContactSkillExpertise>, IContactSkillExpertiseRepository
    {
        private MyContactsDbContext MyContactsDbContext
        {
            get { return Context as MyContactsDbContext; }
        }

        public ContactSkillExpertiseRepository(MyContactsDbContext context) : base(context) { }

        public async Task<IEnumerable<ContactSkillExpertise>> GetAllWithCSEAsync()
        {
            return await MyContactsDbContext.ContactSkillExpertises
                .Include(x => x.Contact)
                .Include(x => x.Skill)
                .Include( x => x.Expertise)
                .ToListAsync();
        }

        public async Task<ContactSkillExpertise> GetWithCSEByIdAsync(int id)
        {
            return await MyContactsDbContext.ContactSkillExpertises
                .Include(x => x.Contact)
                .Include(x => x.Skill)
                .Include(x => x.Expertise)
                .SingleOrDefaultAsync( x => x.Id == id);
        }

        public async Task<IEnumerable<ContactSkillExpertise>> GetAllWithContactByContactIdAsync(int contactId)
        {
            return await MyContactsDbContext.ContactSkillExpertises
                .Include(x => x.Contact)
                .Include(x => x.Skill)
                .Include(x => x.Expertise)
                .Where(x => x.ContactId == contactId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ContactSkillExpertise>> GetAllWithContactBySkillIdAsync(int skillId)
        {
            return await MyContactsDbContext.ContactSkillExpertises
                .Include(x => x.Contact)
                .Include(x => x.Skill)
                .Include(x => x.Expertise)
                .Where(x => x.SkillId == skillId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ContactSkillExpertise>> GetAllWithContactByExpertiseIdAsync(int expertiseId)
        {
            return await MyContactsDbContext.ContactSkillExpertises
                .Include(x => x.Contact)
                .Include(x => x.Skill)
                .Include(x => x.Expertise)
                .Where(x => x.ExpertiseId == expertiseId)
                .ToListAsync();
        }

        public async Task<int> GetCSEId(ContactSkillExpertise contactSkillExpertiseToFind)
        {
            ContactSkillExpertise tempcse = await MyContactsDbContext.ContactSkillExpertises
                .SingleOrDefaultAsync(x => 
                    x.Contact.Id == contactSkillExpertiseToFind.ContactId && x.Skill.Id == contactSkillExpertiseToFind.SkillId
                );
            if (tempcse == null) return 0;
            return tempcse.Id;
        }

        public async Task<int> GetCSEIdByContactIdSkillId(int contactId, int skillId)
        {
            ContactSkillExpertise tempcse = await MyContactsDbContext.ContactSkillExpertises
                .SingleOrDefaultAsync(x =>
                x.SkillId == skillId && x.ContactId == contactId
                );

            return tempcse.Id;
        }
    }
}
