using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        ValueTask<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);


    }
}
