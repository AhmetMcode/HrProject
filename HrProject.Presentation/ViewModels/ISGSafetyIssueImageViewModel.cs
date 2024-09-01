using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class ISGSafetyIssueImageViewModel
    {
        public string ImagePath { get; set; }
        public IFormFile ImageFile { get; set; } // Resim dosyasını tutmak için
    }
}
