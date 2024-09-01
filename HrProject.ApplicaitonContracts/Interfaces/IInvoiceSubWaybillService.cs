using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IInvoiceSubWaybillService : IBaseRepository<InvoiceSubWaybill>
    {
        public IEnumerable<InvoiceSubWaybill> GetIncludeISubWayBill();
    }
}
