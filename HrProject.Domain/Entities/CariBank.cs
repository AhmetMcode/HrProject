using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class CariBank : BaseEntity
    {
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCode { get; set; }
        public string? AccountNumber { get; set; }
        public string? IBAN { get; set; }
        public string? Note { get; set; }
        public string? SwiftCode { get; set; }
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public CurrencyType? CurrencyType { get; set; }

    }
}
