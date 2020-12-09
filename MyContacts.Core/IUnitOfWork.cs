using MyContacts.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core
{
    public interface IUnitOfWork : IDisposable
    {

        IContactRepository Contacts { get; }

        ISkillRepository Skills { get;  }

        IUserRepository Users { get; }

        IExpertiseRepository Expertises { get; }

        IContactSkillExpertiseRepository ContactSkillExpertises { get; }

        Task<int> CommitAsync();
    }
}
