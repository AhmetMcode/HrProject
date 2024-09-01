using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class FollowCurrencyRate : BaseEntity
    {
        public DateTime CurrencyRateDate { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public CurrencyType CurrencyType2 { get; set; }
        public decimal CurrencyRate { get; set; }
    }
}
