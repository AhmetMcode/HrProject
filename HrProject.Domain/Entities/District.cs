using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class District : BaseEntity
    {
        public string Name { get; set; }
        public string? TcpsCode { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
