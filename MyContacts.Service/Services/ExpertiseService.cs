﻿using MyContacts.Core;
using MyContacts.Core.Models;
using MyContacts.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Service.Services
{
    /// <summary>
    /// Class which implements the contact Expertise interface
    /// used the unit of work to acces the database and return what is needed in the requests
    /// </summary>
    public class ExpertiseService : IExpertiseService
    {
        // --- Attributes ---
            private readonly IUnitOfWork _unitOfWork;

        // --- Methods ---
            public ExpertiseService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Expertise> CreateExpertise(Expertise newExpertise)
            {
                await _unitOfWork.Expertises.AddAsync(newExpertise);
                await _unitOfWork.CommitAsync();
                return newExpertise;
            }

            public async Task DeleteExpertise(Expertise expertise)
            {
                _unitOfWork.Expertises.Remove(expertise);
                await _unitOfWork.CommitAsync();
            }

            public async Task<IEnumerable<Expertise>> GetAllExpertises()
            {
                return await _unitOfWork.Expertises.GetAllAsync();
            }

            public async Task<Expertise> GetExpertiseById(int id)
            {
                return await _unitOfWork.Expertises.GetByIdAsync(id);
            }

            public async Task UpdateExpertise(Expertise expertiseToBeUpdated, Expertise expertise)
            {
                expertiseToBeUpdated.Name = expertise.Name;

                await _unitOfWork.CommitAsync();
            }
    }
}
