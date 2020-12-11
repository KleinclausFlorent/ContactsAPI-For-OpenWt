using MyContacts.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core
{
    /// <summary>
    /// interface for the UnitofWork links the repositories to the databaseContext
    /// defines the specific methods and will be implemented in the data tier
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        // --- Attributes ---
            IContactRepository Contacts { get; }

            ISkillRepository Skills { get;  }

            IUserRepository Users { get; }

            IExpertiseRepository Expertises { get; }

            IContactSkillExpertiseRepository ContactSkillExpertises { get; }

        // --- Methods ---
            Task<int> CommitAsync();
    }
}
