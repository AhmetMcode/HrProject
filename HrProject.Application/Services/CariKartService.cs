using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class CariKartService : BaseRepository<CariKart>, ICariKartService
    {
        public CariKartService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public bool AddCariKart(CariKart carikart)
        {
            try
            {
                carikart.TaxOfficeId = 48;
                carikart.CreatedTime = DateTime.Now;
                InvoiceAdress invoiceAdress = new InvoiceAdress();
                invoiceAdress.CityId = 1;
                invoiceAdress.DistrictId = 1;
                invoiceAdress.CreatedTime = DateTime.Now;
                invoiceAdress.Adress = "";
                Insert(carikart);
                invoiceAdress.CariKartId = carikart.Id;
                _context.InvoiceAdress.Add(invoiceAdress);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public CariKart GetCariKartInclude(int id)
        {
            return _context.CariKarts.Include(x => x.CariRisk).Include(x => x.OtherCariRisk).Include(x => x.InvoiceAdresses).Include(x => x.TaxOffice).Where(x => x.Id == id).FirstOrDefault();
        }


        public void UpdateTotalCariKart(CariKart? cariKart, List<InvoiceAdress>? invoiceAdress, CariRisk? cariRisk, CariBank cariBank, OtherCariRisk? otherCariRisk)
        {
            if (cariKart != null)
            {
                cariKart.TaxOfficeId = _context.TaxOffices.FirstOrDefault(x => x.Code == cariKart.TaxOfficeId.ToString()).Id;
                Update(cariKart);
            }
            if (invoiceAdress != null)
            {
                foreach (var item in invoiceAdress)
                {

                }

            }
            if (cariRisk != null)
            {
                _context.Entry(cariRisk).State = EntityState.Modified;
                _context.SaveChanges();
            }
            if (otherCariRisk != null)
            {
                _context.Entry(otherCariRisk).State = EntityState.Modified;
                _context.SaveChanges();
            }
            if (cariBank != null)
            {
                _context.Entry(cariBank).State = EntityState.Modified;
                _context.SaveChanges();

            }
        }


    }
}
