﻿using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    /// <summary>
    /// interface for the ContactSkillExpertise model
    /// defines the specific methods for this model 
    /// </summary>
    public interface IContactSkillExpertiseRepository : IRepository<ContactSkillExpertise>
    {
        // ---  Methods ---
            Task<IEnumerable<ContactSkillExpertise>> GetAllWithCSEAsync();

            Task<ContactSkillExpertise> GetWithCSEByIdAsync(int id);

            Task<int> GetCSEId(ContactSkillExpertise contactSkillExpertiseToFind);

            Task<int> GetCSEIdByContactIdSkillId(int contactId, int skillId);

            Task<IEnumerable<ContactSkillExpertise>> GetAllWithContactByContactIdAsync(int contactId);

            Task<IEnumerable<ContactSkillExpertise>> GetAllWithContactBySkillIdAsync(int skillId);

            Task<IEnumerable<ContactSkillExpertise>> GetAllWithContactByExpertiseIdAsync(int expertiseId);
    }
}
