using System;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class ISGSafetyIssueSubCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // Alt kategori adı
        public ISGRiskLevel RiskLevel { get; set; } // Risk seviyesi
        public int CategoryId { get; set; } // Kategori ID
    }
}

