using Microsoft.EntityFrameworkCore;
using MyContacts.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Data.Repositories
{
    /// <summary>
    /// Class repository , implements the interface repository for generic classes
    /// </summary>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        // --- Attributes ---
            // -- Protected --
                protected readonly DbContext Context;

            // -- Public --
                public Repository(DbContext context)
                {
                    this.Context = context;
                }

        // --- Methods ---
            public ValueTask<TEntity> GetByIdAsync(int id)
            {
                return Context.Set<TEntity>().FindAsync(id);
            }

            public async Task<IEnumerable<TEntity>> GetAllAsync()
            {
                return await Context.Set<TEntity>().ToListAsync();
            }

            public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            {
                return Context.Set<TEntity>().Where(predicate);
            }

            public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            {
                return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
            }

            public async Task AddAsync(TEntity entity)
            {
                await Context.Set<TEntity>().AddAsync(entity);
            }

            public void Remove(TEntity entity)
            {
                Context.Set<TEntity>().Remove(entity);
            }

            public void RemoveRange(IEnumerable<TEntity> entities)
            {
                Context.Set<TEntity>().RemoveRange(entities);
            }
    }
}
