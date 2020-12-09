using MyContacts.Core;
using MyContacts.Core.Repositories;
using MyContacts.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyContactsDbContext _context;
        private IContactRepository _contactRepository;
        private ISkillRepository _skillRepository;
        private IUserRepository _userRepository;
        private IExpertiseRepository _expertiseRepository;
        private IContactSkillExpertiseRepository _contactSkillExpertiseRepository;

        public UnitOfWork(MyContactsDbContext context) => _context = context;

        public IContactRepository Contacts => _contactRepository = _contactRepository ?? new ContactRepository(_context);

        public ISkillRepository Skills => _skillRepository = _skillRepository ?? new SkillRepository(_context);

        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public IExpertiseRepository Expertises => _expertiseRepository = _expertiseRepository ?? new ExpertiseRepository(_context);

        public IContactSkillExpertiseRepository ContactSkillExpertises => _contactSkillExpertiseRepository = _contactSkillExpertiseRepository ?? new ContactSkillExpertiseRepository(_context);

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
