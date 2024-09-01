using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Plate { get; set; }
        public int VehicleCategoryId { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public int YikamaSure { get; set; }
        public string? ChassisNo { get; set; }
        public int MainResponsibleId { get; set; }
        public Person MainResponsible { get; set; }
        public int BackupResponsibleId { get; set; }
        public Person BackupResponsible { get; set; }
        public DateTime InspectionDate { get; set; }
        public int InspectionInterval { get; set; }
        public FuelTypeEnum FuelTypeEnum { get; set; }
        public List<VehicleWash> VehicleWashs { get; set; }
        public int? Kilometer { get; set; }
    }
    public class VehicleWash : BaseEntity
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public DateTime WashDate { get; set; }
        public DateTime IstekTarihi { get; set; }

        public string? WashNotes { get; set; }

        public List<VehicleWashImage> WashImages { get; set; } = new List<VehicleWashImage>();
    }

    public class VehicleWashImage : BaseEntity
    {
        public int VehicleWashId { get; set; }
        public VehicleWash VehicleWash { get; set; }

        public string ImagePath { get; set; }

        public string? Description { get; set; }
    }

    public class VehicleLend : BaseEntity
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public string? ApplicationUserId { get; set; } // Ödünç alan ApplicationUser
        public ApplicationUser? ApplicationUser { get; set; }

        public int? PersonId { get; set; } // Ödünç alan Person
        public Person? Person { get; set; }

        public string LenderUserId { get; set; } // Ödünç veren kişi
        public ApplicationUser LenderUser { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LendDate { get; set; } // Ödünç verilme tarihi
        public DateTime? ReturnDate { get; set; } // Araç geri alınma tarihi
        public string? Notes { get; set; } // Notlar, varsa
    }

    public class VehicleKilometerUpdate : BaseEntity
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int LastKilometer { get; set; } // Araçtaki son kilometre değeri
        public DateTime UpdateDate { get; set; }

        public string ApplicationUserId { get; set; } // Kilometreyi güncelleyen ApplicationUser
        public ApplicationUser ApplicationUser { get; set; }
    }

}
