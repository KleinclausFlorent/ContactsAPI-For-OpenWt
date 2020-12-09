using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Services
{
    public interface IExpertiseService
    {
        Task<IEnumerable<Expertise>> GetAllExpertises();

        Task<Expertise> GetExpertiseById(int id);

        Task<Expertise> CreateExpertise(Expertise newExpertise);

        Task UpdateExpertise(Expertise expertiseToBeUpdated, Expertise expertise);

        Task DeleteExpertise(Expertise expertise);
    }
}
