using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class MaintenanceRequestViewModel
    {
        public IEnumerable<MaintenanceRequest> MaintenanceRequests { get; set; }
        public IEnumerable<MaintenanceService> MaintenanceServices { get; set; }
        public MaintenanceRequest MaintenanceRequest { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Requester { get; set; }
        public bool InOrOutRequest { get; set; }
        public List<MaintenanceRequestListService> MaintenanceRequestListServices { get; set; }
        public DateTime LastRequestTime { get; set; }
        public IFormFile FaultPhoto { get; set; }
        public IFormFile InvoicePhoto { get; set; }
        public MaintenanceStatusEnum MaintenanceStatusEnum { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? RejectionReason { get; set; }
        public string? ServiceMessage { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int VehicleMaintenanceKm { get; set; }

    }


}
