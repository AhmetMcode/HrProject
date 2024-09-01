using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class Unit : BaseEntity
    {
        public string? UnitName { get; set; }
        public UnitType UnitType { get; set; }
    }
}
