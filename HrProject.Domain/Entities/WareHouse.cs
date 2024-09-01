using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class WareHouse : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
