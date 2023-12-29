namespace ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Remove(TEntity entity);
    }
}
