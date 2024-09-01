using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class VehicleViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Plate { get; set; }
        public int VehicleCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public int Yikama { get; set; }
        public string? ChassisNo { get; set; }
        public string MainResponsible { get; set; }
        public string BackupResponsible { get; set; }
        public int MainResponsibleId { get; set; }
        public int BackupResponsibleId { get; set; }
        public DateTime InspectionDate { get; set; }
        public int InspectionInterval { get; set; }
        public FuelTypeEnum FuelTypeEnum { get; set; }
        public int? Kilometer { get; set; }  // Kilometre bilgisi
        public DateTime? LastKilometerUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
    public class VehicleViewModel1
    {
        public int VehicleId { get; set; }
        public string Plate { get; set; }
        public int VehicleCategoryId { get; set; }
        public int Yikama { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public string? ChassisNo { get; set; }
        public int MainResponsibleId { get; set; }
        public int BackupResponsibleId { get; set; }
        public DateTime InspectionDate { get; set; }
        public int InspectionInterval { get; set; }
        public FuelTypeEnum FuelTypeEnum { get; set; }
        public int? Kilometer { get; set; }  // Kilometre bilgisi
    }
}
