using MyContacts.Core;
using MyContacts.Core.Models;
using MyContacts.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Service.Services
{

    public class ContactSkillExpertiseService : IContactSkillExpertiseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactSkillExpertiseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ContactSkillExpertise> CreateContactSkillExpertise(ContactSkillExpertise newContactSkillExpertise)
        {
            await _unitOfWork.ContactSkillExpertises.AddAsync(newContactSkillExpertise);
            await _unitOfWork.CommitAsync();
            return newContactSkillExpertise;
        }

        public async Task DeleteContactSkillExpertise(ContactSkillExpertise contactSkillExpertise)
        {
            _unitOfWork.ContactSkillExpertises.Remove(contactSkillExpertise);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ContactSkillExpertise>> GetAllContactSkillExpertisesWithCSE()
        {
            return await _unitOfWork.ContactSkillExpertises.GetAllWithCSEAsync();
        }

        public async Task<ContactSkillExpertise> GetContactSkillExpertiseById(int id)
        {
            return await _unitOfWork.ContactSkillExpertises.GetByIdAsync(id);
        }

        public async Task<int> GetContactSkillExpertiseId(ContactSkillExpertise ContactSkillExpertiseToFind)
        {
            return await _unitOfWork.ContactSkillExpertises.GetCSEId(ContactSkillExpertiseToFind);
        }

        public async Task<int> GetContactSkillExpertiseIdByContactIdSkillID(int contactId, int skillId)
        {
            return await _unitOfWork.ContactSkillExpertises.GetCSEIdByContactIdSkillId(contactId, skillId);
        }

        public async Task<IEnumerable<ContactSkillExpertise>> GetContactSkillExpertisesByContactId(int contactId)
        {
            return await _unitOfWork.ContactSkillExpertises.GetAllWithContactByContactIdAsync(contactId);
        }

        public async Task<IEnumerable<ContactSkillExpertise>> GetContactSkillExpertisesByExpertiseId(int expertiseId)
        {
            return await _unitOfWork.ContactSkillExpertises.GetAllWithContactByExpertiseIdAsync(expertiseId);
        }

        public async Task<IEnumerable<ContactSkillExpertise>> GetContactSkillExpertisesBySkillId(int skillId)
        {
            return await _unitOfWork.ContactSkillExpertises.GetAllWithContactBySkillIdAsync(skillId);
        }

        public async Task UpdateContactSkillExpertise(ContactSkillExpertise contactSkillExpertiseToBeUpdated, ContactSkillExpertise contactSkillExpertise)
        {
            contactSkillExpertiseToBeUpdated.ContactId = contactSkillExpertise.ContactId;
            contactSkillExpertiseToBeUpdated.ExpertiseId = contactSkillExpertise.ExpertiseId;
            contactSkillExpertiseToBeUpdated.SkillId = contactSkillExpertise.SkillId;

            await _unitOfWork.CommitAsync();
        }

    }
}
