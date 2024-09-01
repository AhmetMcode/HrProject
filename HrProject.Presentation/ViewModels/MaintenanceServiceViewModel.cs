using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class MaintenanceServiceViewModel
    {
        public IEnumerable<MaintenanceService> MaintenanceServices { get; set; }
        public MaintenanceService MaintenanceService { get; set; }
        public List<MaintenancesStock> MaintenancesStocks { get; set; }
        public string Name { get; set; }
        public decimal ServiceTime { get; set; }
        public int VehicleId { get; set; }
        public string VehicleCategory { get; set; }
        public string Description { get; set; }
        public int ControlKm { get; set; }
        public int ControlRange { get; set; }
    }
}
