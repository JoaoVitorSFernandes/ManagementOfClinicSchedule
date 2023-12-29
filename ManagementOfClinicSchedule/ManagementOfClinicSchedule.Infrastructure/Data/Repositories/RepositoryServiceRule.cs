using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;
using ManagementOfClinicSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementOfClinicSchedule.Infrastructure.Data.Repositories
{
    internal class RepositoryServiceRule : RepositoryBase<ServiceRule>, IRepositoryServiceRule
    {
        private readonly DataContext _dataContext;

        public RepositoryServiceRule(DataContext dataContext) 
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ServiceRule>> AvailableTimes()
        {
            try
            {
                return await _dataContext.ServicesRule
                                            .AsNoTracking()
                                            .Include(t => t.Timesheet)
                                            .Where(x => x.Timesheet.Any(item => item.IsBusy != true))
                                            .ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"RSREX01 - Internal server erro. \n\n {ex.Message}");
            }
        }
    }
}
