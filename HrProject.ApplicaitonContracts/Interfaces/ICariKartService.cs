using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ICariKartService : IBaseRepository<CariKart>
    {
        bool AddCariKart(CariKart cariKart);
        CariKart GetCariKartInclude(int id);
        void UpdateTotalCariKart(CariKart? cariKart, List<InvoiceAdress>? invoiceAdress, CariRisk? cariRisk, CariBank cariBank, OtherCariRisk? otherCariRisk);
    }
}
