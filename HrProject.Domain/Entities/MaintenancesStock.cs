using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class MaintenancesStock : BaseEntity
    {
        public int MaintenanceServiceId { get; set; }
        public MaintenanceService MaintenanceService { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
