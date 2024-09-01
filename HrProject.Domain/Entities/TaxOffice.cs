using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class TaxOffice : BaseEntity
    {
        public int CityId { get; set; }
        public string District { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; }
    }
}
