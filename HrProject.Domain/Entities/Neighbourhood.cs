using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class Neighbourhood : BaseEntity
    {
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public int TcpsCode { get; set; }
    }
}
