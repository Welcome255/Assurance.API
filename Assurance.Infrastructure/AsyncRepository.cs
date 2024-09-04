﻿using Assurance.ApplicationCore.Entites;
using Assurance.ApplicationCore.Interfaces;
using Assurance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Assurance.Infrastructure
{
    public class AsyncRepository<TBaseEntity> : IAsyncRepository<TBaseEntity> where TBaseEntity : BaseEntity

    {
        protected readonly AssuranceContext _dbContext;

        public AsyncRepository(AssuranceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TBaseEntity entity)
        {
            await _dbContext.Set<TBaseEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TBaseEntity entity)
        {
            _dbContext.Set<TBaseEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(TBaseEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<TBaseEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TBaseEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TBaseEntity>> ListAsync()
        {
            return await _dbContext.Set<TBaseEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TBaseEntity>> ListAsync(System.Linq.Expressions.Expression<Func<TBaseEntity, bool>> predicate)
        {
            return await _dbContext.Set<TBaseEntity>()
                .Where(predicate)
                .ToListAsync();
        }
    }
}
