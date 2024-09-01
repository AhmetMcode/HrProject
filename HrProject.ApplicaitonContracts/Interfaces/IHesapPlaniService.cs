using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IHesapPlaniService : IBaseRepository<HesapPlani>
    {
        public HesapPlani GetHesapDetails(int hesapPlaniId);
    }


}
