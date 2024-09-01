using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ProjectType : BaseEntity
    {
        public string Name { get; set; }
        public int PartCount { get; set; }
    }
}
