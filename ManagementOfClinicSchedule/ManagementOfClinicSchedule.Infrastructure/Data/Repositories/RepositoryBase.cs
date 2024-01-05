using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagementOfClinicSchedule.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;

        public RepositoryBase(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await _dataContext.Set<TEntity>()
                                         .AsNoTracking()
                                         .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }

        public async Task Add(TEntity entity)
        {
            try
            {
                await _dataContext.Set<TEntity>().AddAsync(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _dataContext.Set<TEntity>().AddRange(entities);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }

        public async Task Remove(TEntity entity)
        {
            try
            {
                _dataContext.Set<TEntity>().Remove(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _dataContext.Set<TEntity>().RemoveRange(entities);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }
    }
}
