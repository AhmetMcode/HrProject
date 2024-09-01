using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IMaintenanceRequestService : IBaseRepository<MaintenanceRequest>
    {
        IEnumerable<MaintenanceRequest> GetIncludeMaintenanceRequest();
        MaintenanceRequest GetByIdInclude(int id);
    }
}
