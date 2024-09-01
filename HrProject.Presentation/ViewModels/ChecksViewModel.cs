using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class ChecksViewModel
    {
        public IEnumerable<Checks> Checkses { get; set; }
        public Checks Checks { get; set; }
        public bool ReceivedOrGiven { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CariKartTitle { get; set; }
        public int CariKartId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Amount { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNo { get; set; }
        public string Receiver { get; set; }
        public string PrincipalDebtor { get; set; }
        public string? Description { get; set; }
        public List<CheckListItem> ResultList { get; set; } // Liste oluşturmak için kullanılacak property
        public DateTime StartingDate { get; set; } // Bu özellik eklenmiştir
        public decimal TotalAmount { get; set; } // Bu özellik eklenmiştir
        public int Installment { get; set; } // Bu özellik eklenmiştir
        public int Accounts2Id { get; set; }
        public int Banks2Id { get; set; }
        public CheckStatusEnum CheckStatusEnum { get; set; }

    }
    public class CheckListItem
    {
        public int DocumentNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Amount { get; set; }
    }
    public class ChecksViewModel2
    {
        public int CheckId { get; set; }
        public string? BankName { get; set; }
        public bool ReceivedOrGiven { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CariKartTitle { get; set; }
        public int CariKartId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Amount { get; set; }
        public string BranchName { get; set; }
        public string AccountNo { get; set; }
        public string Receiver { get; set; }
        public string PrincipalDebtor { get; set; }
        public string? Description { get; set; }
        public int Accounts2Id { get; set; }
        public int Banks2Id { get; set; }
        public CheckStatusEnum CheckStatusEnum { get; set; }
    }
}
