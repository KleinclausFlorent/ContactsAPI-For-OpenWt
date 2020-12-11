using MyContacts.Core;
using MyContacts.Core.Repositories;
using MyContacts.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Data
{
    /// <summary>
    /// class which implements the UnitofWork which links the repositories to the databaseContext
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        // --- Attributes ---
            // -- Private --
                private readonly MyContactsDbContext _context;
                private IContactRepository _contactRepository;
                private ISkillRepository _skillRepository;
                private IUserRepository _userRepository;
                private IExpertiseRepository _expertiseRepository;
                private IContactSkillExpertiseRepository _contactSkillExpertiseRepository;
            // -- Public --
                public UnitOfWork(MyContactsDbContext context) => _context = context;

                public IContactRepository Contacts => _contactRepository = _contactRepository ?? new ContactRepository(_context);

                public ISkillRepository Skills => _skillRepository = _skillRepository ?? new SkillRepository(_context);

                public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

                public IExpertiseRepository Expertises => _expertiseRepository = _expertiseRepository ?? new ExpertiseRepository(_context);

                public IContactSkillExpertiseRepository ContactSkillExpertises => _contactSkillExpertiseRepository = _contactSkillExpertiseRepository ?? new ContactSkillExpertiseRepository(_context);
        
        // --- Methods ---
            public async Task<int> CommitAsync()
            {
                return await _context.SaveChangesAsync();
            }

            public void Dispose()
            {
                _context.Dispose();
            }
    }
}
