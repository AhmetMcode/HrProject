using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class MoneyTransfer : BaseEntity
    {
        public int? CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public int? Account2Id { get; set; }
        public Account2 Account2 { get; set; }
        public int? Bank2Id { get; set; }
        public Bank2 Bank2 { get; set; }
        public int? ChecksId { get; set; }
        public Checks Checks { get; set; }
        public MoneyTransferEnum MoneyTransferEnum { get; set; }
        public bool MoneyInOut { get; set; }
        public string RelevantAccount { get; set; }
        public double Amount { get; set; }
        public DateTime TransferDate { get; set; }
        public double TotalAmount { get; set; }
        public string? Description { get; set; }


    }
}
