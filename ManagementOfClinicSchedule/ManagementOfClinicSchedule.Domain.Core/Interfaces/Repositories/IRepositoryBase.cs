namespace ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entity);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entity);
        Task<IEnumerable<TEntity>> GetAll(TEntity entity);
    }
}
