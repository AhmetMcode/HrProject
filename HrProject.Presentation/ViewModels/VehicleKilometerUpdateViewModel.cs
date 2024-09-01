using System;
namespace HrProject.Presentation.ViewModels
{
    public class VehicleKilometerUpdateViewModel
    {
        public int VehicleId { get; set; }
        public string VehiclePlate { get; set; }
        public int? CurrentKilometer { get; set; } // Optional, to display the current kilometer
        public int NewKilometer { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now; // Default to the current date and time
        public string MainResponsible { get; set; } // Yeni eklenen alan
        public string BackupResponsible { get; set; } // Yeni eklenen alan
    }
}

