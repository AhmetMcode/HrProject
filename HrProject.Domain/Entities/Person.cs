using Microsoft.AspNetCore.Http;
using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActiveWorker { get; set; } = true;
        public PersonPosition PersonPosition { get; set; }
        public int PersonPositionId { get; set; }
        public Workplace Workplace { get; set; }
        public int WorkplaceId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public decimal WorkingTime { get; set; }
        public decimal MesaiCarpan { get; set; }
        public string IBAN { get; set; }
        public IEnumerable<PersonSalary> PersonSalaries { get; set; }
        public string IdCard { get; set; }
        public string PlaceOfResidence { get; set; }
        public string ProfilePicture { get; set; }
        public string Diploma { get; set; }
        public string CriminalRecord { get; set; }
        public string PopulationRegistration { get; set; }
        public string HealthReport { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<PersonBonus> PersonBonuses { get; set; }
        public bool IsApproved { get; set; } = false;
        public string? ApprovedById { get; set; } // Onayı yapan kullanıcının ID'si
        public ApplicationUser? ApprovedBy { get; set; } // Onayı yapan kullanıcı
        public DateTime? ApprovalDate { get; set; } // Onay tarihi
    }
}
