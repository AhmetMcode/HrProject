using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class MaintenanceRequest : BaseEntity
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Requester { get; set; }
        public bool InOrOutRequest { get; set; }
        public List<MaintenanceRequestListService> MaintenanceRequestListServices { get; set; }
        public DateTime LastRequestTime { get; set; }
        public string FaultPhoto { get; set; }
        public string? InvoicePhoto { get; set; }
        public MaintenanceStatusEnum MaintenanceStatusEnum { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? RejectionReason { get; set; }
        public string? ServiceMessage { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int VehicleMaintenanceKm { get; set; }
    }
}
