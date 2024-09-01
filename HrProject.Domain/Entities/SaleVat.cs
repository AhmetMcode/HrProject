using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class SaleVat : BaseEntity
    {
        public decimal VATRate { get; set; }
        public string? VATRateCode { get; set; }
    }
}
