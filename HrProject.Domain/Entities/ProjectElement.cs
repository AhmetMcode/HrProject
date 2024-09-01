using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ProjectElement : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsShowWord { get; set; }
    }
}
