using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IFollowCurrencyRateService : IBaseRepository<FollowCurrencyRate>
    {
        decimal GetByDateAndType(DateTime date, CurrencyType currencyType);

    }
}
