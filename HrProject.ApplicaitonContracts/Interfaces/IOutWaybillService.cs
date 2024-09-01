using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IOutWaybillService : IBaseRepository<OutWaybill2>
    {
        object GetInvoiceAddress(int id);
        string UpdateWaybillNo(DateTime editDate, int cariKartId);

        void UpdateStockQuantities(OutWaybillChange outWaybillChange);
        void AddOutWayBillService(OutWaybill2 outWaybill2);


    }
}
