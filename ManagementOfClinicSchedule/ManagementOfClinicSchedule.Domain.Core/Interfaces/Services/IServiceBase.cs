namespace ManagementOfClinicSchedule.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entity);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entity);
    }
}
