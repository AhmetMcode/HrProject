using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class AccountAndBankViewModel
    {
        public IEnumerable<Bank2> Banks { get; set; }
        public IEnumerable<Account2> Accounts { get; set; }
    }
}
