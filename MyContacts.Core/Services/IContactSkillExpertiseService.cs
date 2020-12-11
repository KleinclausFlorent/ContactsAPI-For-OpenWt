﻿using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    public interface IContactSkillExpertiseService
    {
        Task<IEnumerable<ContactSkillExpertise>> GetAllContactSkillExpertisesWithCSE();

        Task<ContactSkillExpertise> GetContactSkillExpertiseById(int id);

        Task<int> GetContactSkillExpertiseId(ContactSkillExpertise ContactSkillExpertiseToFind);

        Task<IEnumerable<ContactSkillExpertise>> GetContactSkillExpertisesByContactId(int contactId);

        Task<IEnumerable<ContactSkillExpertise>> GetContactSkillExpertisesBySkillId(int skillId);

        Task<IEnumerable<ContactSkillExpertise>> GetContactSkillExpertisesByExpertiseId(int expertiseId);

        Task<int> GetContactSkillExpertiseIdByContactIdSkillID(int contactId, int skillId);

        Task<ContactSkillExpertise> CreateContactSkillExpertise(ContactSkillExpertise newContactSkillExpertise);

        Task UpdateContactSkillExpertise(ContactSkillExpertise contactSkillExpertiseToBeUpdated, ContactSkillExpertise contactSkillExpertise);

        Task DeleteContactSkillExpertise(ContactSkillExpertise contactSkillExpertise);
    }
}
