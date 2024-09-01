using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class MaintenanceRequestListService : BaseEntity
    {
        public int MaintenanceRequestId { get; set; }
        public MaintenanceRequest MaintenanceRequest { get; set; }
        public int MaintenanceServiceId { get; set; }
        public MaintenanceService MaintenanceService { get; set; }
    }
}
