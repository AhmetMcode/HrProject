using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class Checks : BaseEntity
    {
        public bool ReceivedOrGiven { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Amount { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNo { get; set; }
        public string Receiver { get; set; }
        public string PrincipalDebtor { get; set; }
        public string? Description { get; set; }
        public DateTime StartingDate { get; set; } // Bu özellik eklenmiştir
        public decimal TotalAmount { get; set; } // Bu özellik eklenmiştir
        public int Installment { get; set; } // Bu özellik eklenmiştir
        public CheckStatusEnum CheckStatusEnum { get; set; }

    }
}
