using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IFuelTransferService : IBaseRepository<FuelTransfer>
    {
        public IEnumerable<FuelTransfer> GetIncludeFuelTransfer();
        public Person GetMainResponsibleByPlate(int id);
        public void UpdateStockByFuelTransfer(int stockId, decimal amount);
        public List<Stock> GetAllStockNamesByCategoryName();

    }
}
