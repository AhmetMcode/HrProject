using HrProject.Domain.Entities;

namespace HrProject.Presentation.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public ApplicationUser user { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string ProfilPhoto { get; set; }
        public string Rols { get; set; }
        public DateTime? SonGirisTarihi { get; set; }
    }
}
