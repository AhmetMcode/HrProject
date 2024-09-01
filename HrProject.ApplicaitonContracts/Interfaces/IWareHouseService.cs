using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IWareHouseService : IBaseRepository<WareHouse>
    {
        //public bool ExistsByCode(string code);
        //bool ExistsByProperty(string code);
        bool ExistsByProperty(string code);
        void DepoSil(int id);
    }
}
