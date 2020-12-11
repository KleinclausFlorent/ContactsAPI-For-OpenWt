using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    /// <summary>
    /// interface for the Expertise service
    /// defines the specific methods for this model  which will be called in the Service tier
    /// </summary>
    public interface IExpertiseService
    {
        // --- Methods ---
            Task<IEnumerable<Expertise>> GetAllExpertises();

            Task<Expertise> GetExpertiseById(int id);

            Task<Expertise> CreateExpertise(Expertise newExpertise);

            Task UpdateExpertise(Expertise expertiseToBeUpdated, Expertise expertise);

            Task DeleteExpertise(Expertise expertise);
    }
}
