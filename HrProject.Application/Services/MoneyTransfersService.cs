using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services;

public class MoneyTransfersService : BaseRepository<MoneyTransfer>, IMoneyTransfersService
{
    public MoneyTransfersService(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public MoneyTransfer GetByIdInclude(int id)
    {
        var moneytransfer = _context.MoneyTransfers.Include(c => c.Bank2Id).Include(x => x.Account2Id).Include(x => x.ChecksId).Include(x => x.CariKartId)
            .Where(x => x.Id == id).FirstOrDefault();
        return moneytransfer;
    }

    public IEnumerable<MoneyTransfer> GetIncludeMoneyTransfer()
    {
        var moneytransfer = _context.MoneyTransfers.Include(c => c.Bank2Id).Include(x => x.Account2Id).Include(x => x.ChecksId).Include(x => x.CariKartId).ToList();
        return moneytransfer;
    }

    public void AddOtherMoneyTransfer(bool inbankOrAccount, bool outbankOrAccount, int inAccountOrBankId, int outAccountOrBankId, CurrencyType own, CurrencyType selected, decimal moneyEquivalent, decimal amount, string description, DateTime transferDate)
    {
        MoneyTransfer moneyTransfer = new MoneyTransfer();
        MoneyTransfer inMoneyTransfer = new MoneyTransfer();

        if (inbankOrAccount)
        {
            var inbank = _context.Banks2.Where(x => x.Id == inAccountOrBankId).FirstOrDefault();

            moneyTransfer.Bank2Id = inAccountOrBankId;
            moneyTransfer.Amount = Convert.ToDouble(amount);
            moneyTransfer.Description = description;
            moneyTransfer.TransferDate = transferDate;

            if (outbankOrAccount)
            {
                var outbank = _context.Banks2.Where(x => x.Id == outAccountOrBankId).FirstOrDefault();
                moneyTransfer.RelevantAccount = outbank.Name;

                inMoneyTransfer.Bank2Id = outAccountOrBankId;
                inMoneyTransfer.Amount = Convert.ToDouble(amount);
                inMoneyTransfer.Description = description;
                inMoneyTransfer.TransferDate = transferDate;

                inMoneyTransfer.RelevantAccount = inbank.Name;


                if (own == selected)
                {
                    inbank.FinalBalance -= amount;
                    outbank.FinalBalance += amount;

                    moneyTransfer.MoneyInOut = false;
                    inMoneyTransfer.MoneyInOut = true;

                    moneyTransfer.TotalAmount = Convert.ToDouble(inbank.FinalBalance);
                    inMoneyTransfer.TotalAmount = Convert.ToDouble(outbank.FinalBalance);
                }
                else
                {
                    inbank.FinalBalance -= amount;
                    outbank.FinalBalance += moneyEquivalent;

                    moneyTransfer.MoneyInOut = false;
                    inMoneyTransfer.MoneyInOut = true;

                    moneyTransfer.TotalAmount = Convert.ToDouble(inbank.FinalBalance);
                    inMoneyTransfer.TotalAmount = Convert.ToDouble(outbank.FinalBalance);


                }
                _context.Banks2.Update(inbank);
                _context.Banks2.Update(outbank);
            }
            else
            {
                var outaccount = _context.Accounts2.Where(x => x.Id == outAccountOrBankId).FirstOrDefault();

                moneyTransfer.RelevantAccount = outaccount.Name;

                inMoneyTransfer.Account2Id = outaccount.Id;
                inMoneyTransfer.Amount = Convert.ToDouble(amount);
                inMoneyTransfer.Description = description;
                inMoneyTransfer.TransferDate = transferDate;
                inMoneyTransfer.RelevantAccount = inbank.Name;

                if (own == selected)
                {
                    inbank.FinalBalance -= amount;
                    outaccount.FinalBalance += amount;

                    moneyTransfer.MoneyInOut = false;
                    inMoneyTransfer.MoneyInOut = true;

                    moneyTransfer.TotalAmount = Convert.ToDouble(inbank.FinalBalance);
                    inMoneyTransfer.TotalAmount = Convert.ToDouble(outaccount.FinalBalance);
                }
                else
                {
                    inbank.FinalBalance -= amount;
                    outaccount.FinalBalance += moneyEquivalent;

                    moneyTransfer.MoneyInOut = false;
                    inMoneyTransfer.MoneyInOut = true;

                    moneyTransfer.TotalAmount = Convert.ToDouble(inbank.FinalBalance);
                    inMoneyTransfer.TotalAmount = Convert.ToDouble(outaccount.FinalBalance);

                }
                _context.Banks2.Update(inbank);
                _context.Accounts2.Update(outaccount);
            }
        }

        else
        {
            var inaccount = _context.Accounts2.Where(x => x.Id == inAccountOrBankId).FirstOrDefault();

            moneyTransfer.Account2Id = inaccount.Id;
            moneyTransfer.Amount = Convert.ToDouble(amount);
            moneyTransfer.Description = description;
            moneyTransfer.TransferDate = transferDate;


            if (outbankOrAccount)
            {
                var outbank = _context.Banks2.Where(x => x.Id == outAccountOrBankId).FirstOrDefault();

                moneyTransfer.RelevantAccount = outbank.Name;

                inMoneyTransfer.Bank2Id = outbank.Id;
                inMoneyTransfer.Description = description;
                inMoneyTransfer.TransferDate = transferDate;
                inMoneyTransfer.Amount = Convert.ToDouble(amount);
                inMoneyTransfer.MoneyTransferEnum = MoneyTransferEnum.ParaTransferi;
                inMoneyTransfer.RelevantAccount = inaccount.Name;

                if (own == selected)
                {
                    inaccount.FinalBalance -= amount;
                    outbank.FinalBalance += amount;

                    moneyTransfer.MoneyInOut = false;
                    inMoneyTransfer.MoneyInOut = true;

                    moneyTransfer.TotalAmount = Convert.ToDouble(inaccount.FinalBalance);
                    inMoneyTransfer.TotalAmount = Convert.ToDouble(outbank.FinalBalance);
                }
                else
                {
                    inaccount.FinalBalance -= amount;
                    outbank.FinalBalance += moneyEquivalent;

                    moneyTransfer.MoneyInOut = false;
                    inMoneyTransfer.MoneyInOut = true;

                    moneyTransfer.TotalAmount = Convert.ToDouble(inaccount.FinalBalance);
                    inMoneyTransfer.TotalAmount = Convert.ToDouble(outbank.FinalBalance);
                }

                _context.Accounts2.Update(inaccount);
                _context.Banks2.Update(outbank);
            }
            else
            {
                var outaccount = _context.Accounts2.Where(x => x.Id == outAccountOrBankId).FirstOrDefault();

                moneyTransfer.RelevantAccount = outaccount.Name;

                inMoneyTransfer.Account2Id = outaccount.Id;
                inMoneyTransfer.Description = description;
                inMoneyTransfer.TransferDate = transferDate;
                inMoneyTransfer.Amount = Convert.ToDouble(amount);
                inMoneyTransfer.MoneyTransferEnum = MoneyTransferEnum.ParaTransferi;
                inMoneyTransfer.RelevantAccount = inaccount.Name;


                if (own == selected)
                {
                    inaccount.FinalBalance -= amount;
                    outaccount.FinalBalance += amount;

                    moneyTransfer.MoneyInOut = false;
                    inMoneyTransfer.MoneyInOut = true;

                    moneyTransfer.TotalAmount = Convert.ToDouble(inaccount.FinalBalance);
                    inMoneyTransfer.TotalAmount = Convert.ToDouble(outaccount.FinalBalance);

                }
                else
                {
                    inaccount.FinalBalance -= amount;
                    outaccount.FinalBalance += moneyEquivalent;

                    moneyTransfer.MoneyInOut = false;
                    inMoneyTransfer.MoneyInOut = true;

                    moneyTransfer.TotalAmount = Convert.ToDouble(inaccount.FinalBalance);
                    inMoneyTransfer.TotalAmount = Convert.ToDouble(outaccount.FinalBalance);
                }

                _context.Accounts2.Update(inaccount);
                _context.Accounts2.Update(outaccount);
            }
        }
        _context.MoneyTransfers.Add(moneyTransfer);
        _context.MoneyTransfers.Add(inMoneyTransfer);
        _context.SaveChanges();
    }

    public decimal GetCurrencyValueJson(DateTime cdate, CurrencyType alinan, CurrencyType cevirlecek)
    {
        try
        {

            var asd = _context.FollowCurrencyRates.Where(x => x.CurrencyRateDate.Date == cdate.Date && x.CurrencyType == alinan && x.CurrencyType2 == cevirlecek).FirstOrDefault();
            if (asd != null)
            {
                return asd.CurrencyRate;
            }
            else
            {
                return 1m;
            }
        }
        catch (Exception)
        {

            return 1;
        }

    }

    public void UpdateAndAddTransfer(bool outMoney, bool bankOrAccount, int outAccountOrBankId, decimal amount, string description, DateTime transferDate)
    {
        MoneyTransfer moneyTransfer = new MoneyTransfer();

        if (bankOrAccount)
        {
            var bank = _context.Banks2.Where(x => x.Id == outAccountOrBankId).FirstOrDefault();
            moneyTransfer.Bank2Id = outAccountOrBankId;
            moneyTransfer.Amount = Convert.ToDouble(amount);
            moneyTransfer.Description = description;
            moneyTransfer.TransferDate = transferDate;
            moneyTransfer.RelevantAccount = "-";


            if (outMoney)
            {
                moneyTransfer.MoneyInOut = false;
                moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.ParaÇıkışı;

                bank.FinalBalance -= amount;
                moneyTransfer.TotalAmount = Convert.ToDouble(bank.FinalBalance);
            }
            else
            {
                moneyTransfer.MoneyInOut = true;
                bank.FinalBalance += amount;
                moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.ParaGirişi;
                moneyTransfer.TotalAmount = Convert.ToDouble(bank.FinalBalance);

            }
            _context.Banks2.Update(bank);
        }
        else
        {
            var account = _context.Accounts2.Where(x => x.Id == outAccountOrBankId).FirstOrDefault();
            moneyTransfer.Account2Id = outAccountOrBankId;
            moneyTransfer.Amount = Convert.ToDouble(amount);
            moneyTransfer.Description = description;
            moneyTransfer.TransferDate = transferDate;
            moneyTransfer.RelevantAccount = "-";
            if (outMoney)
            {
                moneyTransfer.MoneyInOut = false;
                account.FinalBalance -= amount;
                moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.ParaÇıkışı;
                moneyTransfer.TotalAmount = Convert.ToDouble(account.FinalBalance);

            }
            else
            {
                moneyTransfer.MoneyInOut = true;
                account.FinalBalance += amount;
                moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.ParaGirişi;
                moneyTransfer.TotalAmount = Convert.ToDouble(account.FinalBalance);
            }
            _context.Accounts2.Update(account);
        }
        // Diğer işlemler (eğer varsa) ve SaveChanges çağrısı
        _context.MoneyTransfers.Add(moneyTransfer);
        _context.SaveChanges();
    }

    public void UpdateAccountOrBankByChecks(bool bankOraccount, int bankId, int accountId, bool inMoney, decimal amount, DateTime transferDate, int cariId)
    {
        MoneyTransfer moneyTransfer = new MoneyTransfer();
        MoneyTransfer moneyCheckTransfer = new MoneyTransfer();

        var cari = _context.CariKarts.Where(x => x.Id == cariId).FirstOrDefault();

        if (bankOraccount)
        {
            var bank = _context.Banks2.Where(x => x.Id == bankId).FirstOrDefault();

            moneyTransfer.Bank2Id = bankId;
            moneyTransfer.Amount = Convert.ToDouble(amount);
            moneyTransfer.TransferDate = transferDate;
            moneyTransfer.RelevantAccount = cari.Title;

            moneyCheckTransfer.CariKartId = cari.Id;
            moneyCheckTransfer.Amount = Convert.ToDouble(amount);
            moneyCheckTransfer.TransferDate = transferDate;
            moneyCheckTransfer.RelevantAccount = bank.Name;

            if (inMoney)
            {
                moneyTransfer.MoneyInOut = true;
                moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CekTahsilat;

                moneyCheckTransfer.MoneyInOut = false;
                moneyCheckTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CekÖdeme;

                cari.FinalBalance -= amount;
                moneyCheckTransfer.TotalAmount = Convert.ToDouble(cari.FinalBalance);

                bank.FinalBalance += amount;
                moneyTransfer.TotalAmount = Convert.ToDouble(bank.FinalBalance);

            }
            else
            {
                moneyTransfer.MoneyInOut = false;
                moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CekÖdeme;

                moneyCheckTransfer.MoneyInOut = true;
                moneyCheckTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CekTahsilat;

                cari.FinalBalance += amount;
                moneyCheckTransfer.TotalAmount = Convert.ToDouble(cari.FinalBalance);

                bank.FinalBalance -= amount;
                moneyTransfer.TotalAmount = Convert.ToDouble(bank.FinalBalance);

            }
            _context.Banks2.Update(bank);
            _context.CariKarts.Update(cari);
        }
        else
        {
            var account = _context.Accounts2.Where(x => x.Id == accountId).FirstOrDefault();

            moneyTransfer.Account2Id = accountId;
            moneyTransfer.Amount = Convert.ToDouble(amount);
            moneyTransfer.TransferDate = transferDate;
            moneyTransfer.RelevantAccount = cari.Title;

            moneyCheckTransfer.CariKartId = cari.Id;
            moneyCheckTransfer.Amount = Convert.ToDouble(amount);
            moneyCheckTransfer.TransferDate = transferDate;
            moneyCheckTransfer.RelevantAccount = account.Name;


            if (inMoney)
            {
                moneyTransfer.MoneyInOut = true;
                moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CekTahsilat;

                moneyCheckTransfer.MoneyInOut = false;
                moneyCheckTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CekÖdeme;

                cari.FinalBalance -= amount;
                moneyCheckTransfer.TotalAmount = Convert.ToDouble(cari.FinalBalance);

                account.FinalBalance += amount;
                moneyTransfer.TotalAmount = Convert.ToDouble(account.FinalBalance);

            }
            else
            {
                moneyTransfer.MoneyInOut = false;
                moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CekÖdeme;

                moneyCheckTransfer.MoneyInOut = true;
                moneyCheckTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CekTahsilat;

                cari.FinalBalance += amount;
                moneyCheckTransfer.TotalAmount = Convert.ToDouble(cari.FinalBalance);

                account.FinalBalance -= amount;
                moneyTransfer.TotalAmount = Convert.ToDouble(account.FinalBalance);
            }
            _context.Accounts2.Update(account);
            _context.CariKarts.Update(cari);
        }
        _context.MoneyTransfers.Add(moneyTransfer);
        _context.MoneyTransfers.Add(moneyCheckTransfer);
        _context.SaveChanges();
    }

    public void AddMoneyTransferInCariKart(bool outMoney, int carikartId, decimal amount, string description, DateTime transferDate)
    {

        var cariKarts = _context.CariKarts.Where(c => c.Id == carikartId).FirstOrDefault();
        var defaultAccount = _context.Accounts2.SingleOrDefault(a => a.DefaultAccount == true);


        MoneyTransfer moneyTransfer = new MoneyTransfer();
        moneyTransfer.CariKartId = carikartId;
        moneyTransfer.Amount = Convert.ToDouble(amount);
        moneyTransfer.Description = description;
        moneyTransfer.TransferDate = transferDate;


        MoneyTransfer moneyTransferAccount = new MoneyTransfer();
        moneyTransferAccount.Account2Id = defaultAccount.Id;
        moneyTransferAccount.Amount = Convert.ToDouble(amount);
        moneyTransferAccount.Description = description;
        moneyTransferAccount.TransferDate = transferDate;


        if (outMoney)
        {
            moneyTransfer.MoneyInOut = false;
            moneyTransferAccount.MoneyInOut = true;

            cariKarts.FinalBalance -= amount;
            defaultAccount.FinalBalance += amount;

            moneyTransferAccount.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CariGiris;
            moneyTransferAccount.TotalAmount = Convert.ToDouble(defaultAccount.FinalBalance);
            moneyTransferAccount.RelevantAccount = cariKarts.Title;

            moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CariCikis;
            moneyTransfer.TotalAmount = Convert.ToDouble(cariKarts.FinalBalance);
            moneyTransfer.RelevantAccount = defaultAccount.Name;
        }
        else
        {
            moneyTransfer.MoneyInOut = true;
            moneyTransferAccount.MoneyInOut = false;

            cariKarts.FinalBalance += amount;
            defaultAccount.FinalBalance -= amount;

            moneyTransferAccount.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CariCikis;
            moneyTransferAccount.TotalAmount = Convert.ToDouble(defaultAccount.FinalBalance);
            moneyTransferAccount.RelevantAccount = cariKarts.Title;

            moneyTransfer.MoneyTransferEnum = Domain.Enums.MoneyTransferEnum.CariGiris;
            moneyTransfer.TotalAmount = Convert.ToDouble(cariKarts.FinalBalance);
            moneyTransfer.RelevantAccount = defaultAccount.Name;

        }
        _context.Accounts2.Update(defaultAccount);
        _context.CariKarts.Update(cariKarts);
        _context.MoneyTransfers.Add(moneyTransferAccount);
        _context.MoneyTransfers.Add(moneyTransfer);
        _context.SaveChanges();
    }
}


