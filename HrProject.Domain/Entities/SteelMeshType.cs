using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class SteelMeshType : BaseEntity
    {
        public string Code { get; set; }
        public decimal Kgm2 { get; set; }
    }
}
