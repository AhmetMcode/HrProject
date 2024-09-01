using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class OfferMaterialsService : BaseRepository<OfferMaterials>, IOfferMaterials
    {
        public OfferMaterialsService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void Add(OfferMaterials offerMaterial)
        {
            if (_context.OfferMaterials.Where(x => x.CurrentValueId == offerMaterial.CurrentValueId).Count() == 0)
            {
                if (!offerMaterial.Formula)
                {
                    offerMaterial.Formulas = Formulas.Manuel;
                }
                _context.OfferMaterials.Add(offerMaterial);
                _context.SaveChanges();
            }
        }

        public List<OfferMaterials> GetAllInclude()
        {
            return _context.OfferMaterials.Include(x => x.OfferCostCategory).Include(x => x.CurrentValue).ThenInclude(x => x.Unit).ToList();
        }

        public void SaveJsonOfferMaterialDetail(List<OfferCostCalculateDetail> details)
        {
            foreach (var item in details)
            {
                try
                {
                    var detay = _context.OfferCostCalculateDetails.Where(x => x.Id == item.Id).FirstOrDefault();
                    detay.Percent = item.Percent;
                    detay.Quantity = item.Quantity;
                    detay.Wastage = item.Wastage;
                    detay.Enflasyon = item.Enflasyon;
                    detay.CurrentValueC = item.CurrentValueC;
                    detay.Amount = item.Quantity * item.CurrentValueC;
                    detay.Amount = detay.Amount + (detay.Amount * (item.Enflasyon / 100M));
                    detay.Amount = detay.Amount + (detay.Amount * (item.Wastage / 100M));
                    _context.OfferCostCalculateDetails.Update(detay);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    continue;
                }

            }
        }
    }
}
