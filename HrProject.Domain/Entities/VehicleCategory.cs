using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class VehicleCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
