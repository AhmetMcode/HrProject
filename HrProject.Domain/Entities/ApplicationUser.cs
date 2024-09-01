using Microsoft.AspNetCore.Identity;

namespace HrProject.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string PersonelNumber { get; set; }
        public string? MailAdresi { get; set; }
        public string? MailSifresi { get; set; }
        public string? Hakkinda { get; set; }
        public string? Adres { get; set; }
        public string? Tel { get; set; }
        public string Name { get; set; }
        public string? Color { get; set; }
        public string SurName { get; set; }
        public int Salary { get; set; }
        public string? ProfilPhoto { get; set; }
        public string? ResponsibleWareHouseFabrica { get; set; }
        public string? ResponsibleHrLocation { get; set; }
        public string passWord { get; set; }
        public bool pasif { get; set; }
    }
}
