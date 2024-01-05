using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;
using ManagementOfClinicSchedule.Domain.Core.Interfaces.Services;
using System.Runtime.CompilerServices;

namespace ManagementOfClinicSchedule.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task Add(TEntity entity)
        {
            await _repositoryBase.Add(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entity)
        {
            await _repositoryBase.AddRange(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repositoryBase.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repositoryBase.GetById(id);
        }

        public async Task Remove(TEntity entity)
        {
            await _repositoryBase.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<TEntity> entity)
        {
            await _repositoryBase.RemoveRange(entity);
        }
    }
}
