using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class Bank2 : BaseEntity
    {
        public string Name { get; set; }
        public string Branch { get; set; }
        public int AccountNo { get; set; }
        public string IBAN { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal FirstBalance { get; set; }
        public DateTime FirstBalanceDate { get; set; }
        public decimal FinalBalance { get; set; }
        public string? Description { get; set; }
    }
}
