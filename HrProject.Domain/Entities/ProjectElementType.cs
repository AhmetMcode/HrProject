using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ProjectElementType : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ProjectElement ProjectElement { get; set; }
        public int ProjectElementId { get; set; }

    }
}
