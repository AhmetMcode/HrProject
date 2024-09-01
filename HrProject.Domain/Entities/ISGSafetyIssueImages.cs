using System;
namespace HrProject.Domain.Entities
{
    public class ISGSafetyIssueImages
    {
        public int Id { get; set; }
        public required string ImagePath { get; set; } // Path to the uploaded image
        public int SafetyIssueId { get; set; } // Foreign key to SafetyIssue
        public required ISGSafetyIssue ISGSafetyIssue { get; set; } // The safety issue this image is related to
    }
}

