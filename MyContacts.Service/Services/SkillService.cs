using MyContacts.Core;
using MyContacts.Core.Models;
using MyContacts.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Service.Services
{
    /// <summary>
    /// Class which implements the contact skill interface
    /// used the unit of work to acces the database and return what is needed in the requests
    /// </summary>
    public class SkillService : ISkillService
    {
        // --- Attributes ---
        private readonly IUnitOfWork _unitOfWork;

        // --- Methods ---
            public SkillService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Skill> CreateSkill(Skill newSkill)
            {
                await _unitOfWork.Skills.AddAsync(newSkill);
                await _unitOfWork.CommitAsync();
                return newSkill;
            }

            public async Task DeleteSkill(Skill skill)
            {
                _unitOfWork.Skills.Remove(skill);
                await _unitOfWork.CommitAsync();
            }

            public async Task<IEnumerable<Skill>> GetAllSkills()
            {
                return await _unitOfWork.Skills.GetAllAsync();
            }

            public async Task<Skill> GetSkillById(int id)
            {
                return await _unitOfWork.Skills.GetByIdAsync(id);
            }


            public async Task UpdateSkill(Skill skillToBeUpdated, Skill skill)
            {
                skillToBeUpdated.Name = skill.Name;

                await _unitOfWork.CommitAsync();
            }
    }
}
