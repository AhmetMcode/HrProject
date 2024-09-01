using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IInvoiceStockService : IBaseRepository<InvoiceStock>
    {
        public InvoiceStock GetInvoiceStockInclude(int id);

        public IEnumerable<InvoiceStock> GetIncludeInvoiceStock();
        public InvoiceStock CalculateInoviceStock(int id);
    }
}
