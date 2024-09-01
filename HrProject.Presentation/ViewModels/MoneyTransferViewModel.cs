using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class MoneyTransferViewModel
    {
        public Account2 Account2 { get; set; }
        public Bank2 Bank2 { get; set; }
        public CariKart CariKart { get; set; }
        public FollowCurrencyRate FollowCurrencyRate { get; set; }
        public IEnumerable<MoneyTransfer> MoneyTransfers { get; set; }
        public DateTime TransferDate { get; set; }
        public int Accounts2Id { get; set; }
        public int Banks2Id { get; set; }
        public int? ChecksId { get; set; }
        public bool bankOrAccount { get; set; }
        public MoneyTransferEnum MoneyTransferEnum { get; set; }
        public bool MoneyInOut { get; set; }
        public string RelevantAccount { get; set; }
        public double Amount { get; set; }
        public double TotalAmount { get; set; }
        public string Description { get; set; }
    }
}
