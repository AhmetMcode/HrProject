using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IInWaybillService : IBaseRepository<InWaybill>
    {
        void AddInWayBillService(InWaybill inWaybill);
        object GetInvoiceAddress2(int id);

        string UpdateWaybillNo2(DateTime editDate, int cariKartId);
    }
}
