using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IMaintenanceRequestListServiceService : IBaseRepository<MaintenanceRequestListService>
    {
        public IEnumerable<MaintenanceRequestListService> GetIncludeMaintenanceRequests();
        public IEnumerable<MaintenanceRequestListService> GetIncludeMaintenanceRequestsByRequesId(int requestId);

    }
}
