using System;
namespace HrProject.Domain.Entities
{
    public class ISGSafetyIssueCategory
    {
        public int Id { get; set; }
        public required string Name { get; set; } // Name of the category, e.g., "Clothing Issues"
        public ICollection<ISGSafetyIssueSubCategory>? SubCategories { get; set; } // Subcategories under this category
        public ICollection<ISGSafetyIssue>? SafetyIssues { get; set; } // Issues related to this category
    }
}

