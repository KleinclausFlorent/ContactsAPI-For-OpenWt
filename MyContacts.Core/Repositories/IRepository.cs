using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Core.Repositories
{
    /// <summary>
    /// Interface used to define the global request every entity will handle
    /// </summary>
    /// <typeparam name="TEntity"> Will be one of the model we defined</typeparam>
    public interface IRepository<TEntity> where TEntity : class 
    {
        // ---  Methods ---
            ValueTask<TEntity> GetByIdAsync(int id);

            Task<IEnumerable<TEntity>> GetAllAsync();

            IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

            Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

            Task AddAsync(TEntity entity);

            void Remove(TEntity entity);

            void RemoveRange(IEnumerable<TEntity> entities);


    }
}
