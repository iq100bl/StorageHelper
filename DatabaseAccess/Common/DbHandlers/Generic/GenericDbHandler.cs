using DatabaseAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Core.Handlers.GenericHandler
{
    public abstract class GenericDbHandler<TEntity> : IGenericDbHandler<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        protected GenericDbHandler(ApplicationContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task Update(TEntity entity)
        {
             _dbSet.Update(entity);
            return Task.CompletedTask;
        }
        
        public Task Delite(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual TEntity[] GetAll()
        {
            return _dbSet.AsNoTracking().ToArray();
        }
    }
}
