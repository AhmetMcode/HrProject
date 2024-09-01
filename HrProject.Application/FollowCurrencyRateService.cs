using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application
{
    public class FollowCurrencyRateService : BaseRepository<FollowCurrencyRate>, IFollowCurrencyRateService
    {
        public FollowCurrencyRateService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public decimal GetByDateAndType(DateTime date, CurrencyType currencyType)
        {
            var currencyRate = _context.FollowCurrencyRates
                .Where(x => x.CurrencyRateDate == date && x.CurrencyType == currencyType)
                .Select(x => x.CurrencyRate)
                .FirstOrDefault();

            return currencyRate;
        }

    }
}
