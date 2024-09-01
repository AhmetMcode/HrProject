using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class SalesWithholdingRate : BaseEntity
    {
        public decimal WithHRate { get; set; }
        public string WithHRateCode { get; set; }
    }
}
