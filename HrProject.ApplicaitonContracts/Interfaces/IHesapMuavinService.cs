using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IHesapMuavinService : IBaseRepository<HesapMuavin>
    {
        bool IsCodeOrNameExists(int hesapPlaniId, string hesapCode, string? hesapName);


    }
}
