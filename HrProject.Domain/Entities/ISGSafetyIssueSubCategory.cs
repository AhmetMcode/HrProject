using System;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class ISGSafetyIssueSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } // Name of the subcategory, e.g., "Not Wearing Helmet"
        public ISGRiskLevel RiskLevel { get; set; } // Severity level of the issue
        public int CategoryId { get; set; } // Foreign key to SafetyIssueCategory
        public ISGSafetyIssueCategory Category { get; set; } // Category this subcategory belongs to

    }
}

