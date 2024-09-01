using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class CariRisk : BaseEntity
    {
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public decimal RiskLimit { get; set; }
        public RiskControl RiskControl { get; set; }
        public LimitAction LimitActionAll { get; set; }
        public LimitAction LimitActionDelivery { get; set; }
        public LimitAction LimitActionOrder { get; set; }
    }
    public class OtherCariRisk : BaseEntity
    {
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public decimal OwnCheckAmount { get; set; }
        public LimitAction OwnCheckAction { get; set; }
        public decimal CustomerCheckAmount { get; set; }
        public LimitAction CustomerCheckAction { get; set; }
        public decimal DeliveryNoteAmount { get; set; }
        public LimitAction DeliveryNoteAction { get; set; }
    }
}
