using System;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class ISGSafetyIssue
    {
        public int Id { get; set; }
        public string? Description { get; set; } // Description of the safety issue
        public DateTime ReportDate { get; set; } // Date the issue was reported
        public required string ReportedById { get; set; } // ID of the user who reported the issue
        public int CategoryId { get; set; } // Foreign key to SafetyIssueCategory
        public ISGSafetyIssueCategory? Category { get; set; } // Category of the safety issue
        public int SubCategoryId { get; set; } // Foreign key to SafetyIssueSubCategory
        public ISGSafetyIssueSubCategory? SubCategory { get; set; } // Subcategory of the safety issue
        public ICollection<ISGSafetyIssueImages>? Images { get; set; } // Collection of images related to the issue
        public int? PersonId { get; set; }
        public Person? Person { get; set; } // The person related to the safety issue
        public ISGRiskLevel RiskLevel { get; set; } // Enum for Risk Level
    }
}

