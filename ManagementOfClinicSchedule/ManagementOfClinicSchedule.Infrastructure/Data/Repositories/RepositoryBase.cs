using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;

namespace ManagementOfClinicSchedule.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public Task<bool> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
