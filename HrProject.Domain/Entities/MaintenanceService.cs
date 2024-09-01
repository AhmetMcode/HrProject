using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class MaintenanceService : BaseEntity
    {
        public string Name { get; set; }
        public decimal ServiceTime { get; set; }
        public int ControlKm { get; set; }
        public int ControlRange { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<MaintenancesStock> MaintenancesStocks { get; set; }
        public string VehicleCategory { get; set; }
        public string Description { get; set; }
    }
}
