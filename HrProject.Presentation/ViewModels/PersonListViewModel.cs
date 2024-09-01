using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class PersonListViewModel
    {
        public int Id { get; set; }
        public string TcNo { get; set; }
        public string Name { get; set; }
        public bool IsActiveWorker { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }  // PersonPosition adını tutar
        public string PhoneNumber { get; set; }
        public decimal WorkingTime { get; set; }
        public decimal Salary { get; set; }
        public string IBAN { get; set; }
        public string Workplace { get; internal set; }
        public string ProfilePicture { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; } // Onayı yapan kullanıcının adı
        public DateTime? ApprovalDate { get; set; } // Onay tarihi  
    }
}
