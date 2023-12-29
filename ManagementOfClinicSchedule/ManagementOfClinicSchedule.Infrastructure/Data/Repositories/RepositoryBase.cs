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

        public async Task Add(TEntity entity)
        {
            try
            {
                await _dataContext.Set<TEntity>().AddAsync(entity);
                await _dataContext.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException($"RBEX01 - Internal server erro. \n\n {ex.Message}");
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await _dataContext.Set<TEntity>().AsNoTracking().ToListAsync(); 
            }
            catch (DbUpdateException ex) 
            {
                throw new DbUpdateException($"RBEX02 - Internal server erro. \n\n {ex.Message}");
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
                throw new DbUpdateException($"RBEX03 - Internal server erro. \n\n {ex.Message}");
            }
        }
    }
}
