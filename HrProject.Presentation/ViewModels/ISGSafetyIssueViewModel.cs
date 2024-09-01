using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class ISGSafetyIssueViewModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportedById { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public List<IFormFile>? Images { get; set; } // IFormFile listesini kullanarak resimleri alacağız
        public List<ISGSafetyIssueImages>? ExistingImages { get; set; } // Mevcut resimler
        public List<ISGSafetyIssue> Issues { get; set; } = new List<ISGSafetyIssue>();
        public int? PersonId { get; set; }
        public List<Person>? Persons { get; set; } // List of persons to select from
        public string? DeletedImages { get; set; }
    }
}
