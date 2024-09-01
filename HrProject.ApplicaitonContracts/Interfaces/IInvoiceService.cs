using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IInvoiceService : IBaseRepository<Invoice>
    {
        public Invoice GetInvoiceInclude(int id);
        public Task AddInvoice(Invoice invoice);
        public IEnumerable<Invoice> GetIncludeInvoice();
        public CariKart GetCariById(int id);
        public InvoiceAdress GetInvoiceAdressByCariId(int id);
        public Task FaturaToplamGuncelleme(int faturdaId);

    }
}
