using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IMoneyTransfersService : IBaseRepository<MoneyTransfer>
    {
        public MoneyTransfer GetByIdInclude(int id);
        public IEnumerable<MoneyTransfer> GetIncludeMoneyTransfer();
        void UpdateAndAddTransfer(bool outMoney, bool bankOrAccount, int outAccountOrBankId, decimal amount, string description, DateTime transferDate);
        void AddOtherMoneyTransfer(bool inbankOrAccount, bool outbankOrAccount, int inAccountOrBankId, int outAccountOrBankId, CurrencyType own, CurrencyType selected, decimal moneyEquivalent, decimal amount, string description, DateTime transferDate);
        decimal GetCurrencyValueJson(DateTime cdate, CurrencyType alinan, CurrencyType cevirlecek);
        void UpdateAccountOrBankByChecks(bool bankOraccount, int bankId, int accountId, bool inMoney, decimal amount, DateTime transferDate, int cariId);
        public void AddMoneyTransferInCariKart(bool outMoney, int carikartId, decimal amount, string description, DateTime transferDate);

    }
}
