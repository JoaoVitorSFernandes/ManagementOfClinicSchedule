using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;
using ManagementOfClinicSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementOfClinicSchedule.Infrastructure.Data.Repositories
{
    public class RepositoryServiceRule : RepositoryBase<ServiceRule>, IRepositoryServiceRule
    {
        private readonly DataContext _dataContext;

        public RepositoryServiceRule(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<ServiceRule> GetById(int id)
        {
            try
            {
                return await _dataContext.ServicesRule.AsNoTracking().Include(t => t.Timesheets).Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }

        public override async Task<IEnumerable<ServiceRule>> GetAll()
        {
            try
            {
                return await _dataContext.ServicesRule
                                            .AsNoTracking()
                                            .Include(t => t.Timesheets)
                                            .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }

        public async Task<IEnumerable<ServiceRule>> AvailableTimes()
        {
            try
            {
                return await _dataContext.ServicesRule
                                            .AsNoTracking()
                                            .Include(t => t.Timesheets)
                                                .Where(x => x.Timesheets.Any(item => item.IsBusy != true))
                                            .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }
    }
}
