using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public CurrencyType CurrencyType { get; set; }

        public decimal FirstBalance { get; set; }

        public DateTime FirstBalanceDate { get; set; }

        public string? Description { get; set; }

    }
}
