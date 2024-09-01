using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IMaintenanceServiceService : IBaseRepository<MaintenanceService>
    {
        IEnumerable<MaintenanceService> GetIncludeMaintenanceService();
        public string GetCategoryByPlate(int id);
        public MaintenanceService GetByIdInclude(int id);

    }
}
