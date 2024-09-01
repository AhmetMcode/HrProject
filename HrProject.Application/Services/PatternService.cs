using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class PatternService : BaseRepository<Pattern>, IPatternService
    {
        public PatternService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void AddPattenPorjectElement(PatternProjectElementType patternProjectElementType)
        {
            _context.PatternProjectElementType.Add(patternProjectElementType);
            _context.SaveChanges();
        }

        public void AddProductPlan(ProductPlan productPlanSub)
        {
            _context.ProductPlan.Add(productPlanSub);
            _context.SaveChanges();
        }

        public void AddProductPlanDailyPlanned(ProductPlanDailyPlanned productPlanSubPlanned)
        {
            _context.ProductPlanDailyPlanned.Add(productPlanSubPlanned);
            _context.ProductPlanProductPlanned.AddRange(productPlanSubPlanned.ProductPlanProductPlanned);
            _context.SaveChanges();
        }

        public ProductPlanSubPlanned AddProductPlanSubPlanned(ProductPlanSubPlanned productPlanSubPlanned)
        {
            _context.ProductPlanSubPlanned.Add(productPlanSubPlanned);
            _context.SaveChanges();
            return productPlanSubPlanned;
        }

        public void DeletePattenPorjectElement(int PatternId, int ProjectElementTypeId)
        {
            var ppet = _context.PatternProjectElementType.Where(x => x.PatternId == PatternId && x.ProjectElementTypeId == ProjectElementTypeId).FirstOrDefault();
            if (ppet != null)
            {
                _context.PatternProjectElementType.Remove(ppet);
                _context.SaveChanges();
            }

        }

        public List<ProductPlanSubPlanned> GetAlldProductPlanSubPlanned()
        {
            return _context.ProductPlanSubPlanned.ToList();
        }

        public List<ProductPlan> GetAllProductPlan()
        {
            return _context.ProductPlan.Include(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlanDailyPlanned).ThenInclude(x => x.ProductPlanProductPlanned).ToList();
        }

        public List<ProductPlanDailyPlanned> GetAllProductPlanDailyPlanned()
        {
            return _context.ProductPlanDailyPlanned.ToList();
        }

        public List<ProductPlanProductPlanned> GetAllProductPlanProductPlanned()
        {
            return _context.ProductPlanProductPlanned.ToList();
        }

        public List<Pattern> GetByAllInclude()
        {
            return _context.Patterns.Include(x => x.PatternProjectElementTypes).ToList();
        }

        public Pattern GetByIdInclude(int PatternId)
        {
            return _context.Patterns.Where(x => x.Id == PatternId).Include(x => x.PatternProjectElementTypes).FirstOrDefault();
        }

        public List<ProductPlanDailyPlanned> GetProductPlanDailyPlannedByPatternId(int PatternId)
        {

            var dailys = _context.ProductPlanDailyPlanned
                      .Include(x => x.ProductPlanSubPlanned)
                      .Where(x => x.ProductPlanSubPlanned.PatternId == PatternId).ToList();
            foreach (var daily in dailys)
            {
                daily.ProductPlanSubPlanned.ProductPlanDailyPlanned = null;
            }

            return dailys;

        }

        public List<ProductPlanProductPlanned> GetProductPlanPlannedByPatternId(int PatternId)
        {
            var dailys = _context.ProductPlanProductPlanned
                      .Include(x => x.ProductPlanDailyPlanned)
                      .ThenInclude(x => x.ProductPlanSubPlanned)
                      .Where(x => x.ProductPlanDailyPlanned.ProductPlanSubPlanned.PatternId == PatternId).ToList();
            foreach (var daily in dailys)
            {
                daily.ProductPlanDailyPlanned = null;
            }

            return dailys;
        }

        public List<ProductPlanProductPlanned> GetProductPlanPlannedByPatternIdAndDate(int PatternId, DateTime tarih)
        {
            var dailys = _context.ProductPlanProductPlanned
                     .Include(x => x.ProductPlanDailyPlanned)
                     .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan)
                     .Where(x => x.ProductPlanDailyPlanned.ProductPlanSubPlanned.PatternId == PatternId && x.StartTime.Date == tarih.Date).ToList();
            return dailys;
        }
        public ProductManifact2 GetProductManifactsByProductPlanId(int productPlanId)
        {
            var dailys = _context.ProductManifacts2.Where(x => x.ProductPlanProductPlannedId == productPlanId).Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProductManifactDetailImages).Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).FirstOrDefault();
            return dailys;
        }
        public List<ProductPlanDailyPlanned> GetProductPlanSubPlannedByPatternId(int PatternId)
        {
            throw new NotImplementedException();
        }

        public List<PatternProjectElementType> MyPatternProjectElements(int PatternId)
        {
            return _context.PatternProjectElementType.Where(x => x.PatternId == PatternId).ToList();
        }

        public List<ProjectElementType> MyProjectElements(int PatternId)
        {
            return _context.PatternProjectElementType.Where(x => x.PatternId == PatternId).Select(x => x.ProjectElementType).ToList();
        }

        public async Task RePlanByDailyId(int dailyId, DateTime newDate, string secim)
        {
            var gunluk = _context.ProductPlanDailyPlanned.Where(x => x.Id == dailyId).Include(x => x.ProductPlanProductPlanned).Include(x => x.ProductPlanSubPlanned).FirstOrDefault();
            int kalipId = gunluk.ProductPlanSubPlanned.PatternId;
            var kalip = _context.Patterns.Where(x => x.Id == kalipId).FirstOrDefault();
            DateTime gunlukBaslangicTarihi = gunluk.StartTime.Date;
            DateTime yeniTarih = newDate.Date;

            TimeSpan fark = yeniTarih - gunlukBaslangicTarihi;
            int gunFarki = fark.Days;

            var buKaliptakiGunlukPlanlar = _context.ProductPlanDailyPlanned
                                            .Where(x => x.StartTime.Date >= gunluk.StartTime.Date && x.ProductPlanSubPlanned.PatternId == kalipId).Include(x => x.ProductPlanProductPlanned)
                                            .ToList();
            if (secim == ErtelemeEnum.SadeceBuGun.ToString())
            {
                gunluk.StartTime = gunluk.StartTime.AddDays(gunFarki);
                gunluk.EndTime = gunluk.EndTime.AddDays(gunFarki);
                foreach (var urunPlan in gunluk.ProductPlanProductPlanned)
                {
                    urunPlan.StartTime = urunPlan.StartTime.AddDays(gunFarki);
                    urunPlan.EndTime = urunPlan.EndTime.AddDays(gunFarki);
                    _context.ProductPlanProductPlanned.Update(urunPlan);

                }
            }
            if (secim == ErtelemeEnum.SadeceBuProje.ToString())
            {
                foreach (var gunlukPlan in buKaliptakiGunlukPlanlar.Where(x => x.ProductPlanSubPlannedId == gunluk.ProductPlanSubPlannedId).ToList())
                {
                    // StartTime ve EndTime'e gün farkını ekleyin
                    gunlukPlan.StartTime = gunlukPlan.StartTime.AddDays(gunFarki);
                    gunlukPlan.EndTime = gunlukPlan.EndTime.AddDays(gunFarki);
                    _context.ProductPlanDailyPlanned.Update(gunlukPlan);
                    foreach (var urunPlan in gunlukPlan.ProductPlanProductPlanned)
                    {
                        urunPlan.StartTime = urunPlan.StartTime.AddDays(gunFarki);
                        urunPlan.EndTime = urunPlan.EndTime.AddDays(gunFarki);
                        _context.ProductPlanProductPlanned.Update(urunPlan);
                    }
                }
            }
            if (secim == ErtelemeEnum.TumProjeler.ToString())
            {
                foreach (var gunlukPlan in buKaliptakiGunlukPlanlar)
                {
                    // StartTime ve EndTime'e gün farkını ekleyin
                    gunlukPlan.StartTime = gunlukPlan.StartTime.AddDays(gunFarki);
                    gunlukPlan.EndTime = gunlukPlan.EndTime.AddDays(gunFarki);
                    _context.ProductPlanDailyPlanned.Update(gunlukPlan);
                    foreach (var urunPlan in gunlukPlan.ProductPlanProductPlanned)
                    {
                        urunPlan.StartTime = urunPlan.StartTime.AddDays(gunFarki);
                        urunPlan.EndTime = urunPlan.EndTime.AddDays(gunFarki);
                        _context.ProductPlanProductPlanned.Update(urunPlan);
                    }
                }
            }

            _context.SaveChangesAsync();

        }

        public async Task RePlanProduct(int productId, DateTime newDate, string secim)
        {
            var pdoruct = _context.ProductPlanProductPlanned.Where(x => x.Id == productId).FirstOrDefault();
            pdoruct.StartTime = newDate.Date;
            pdoruct.EndTime = newDate.Date.AddDays(1).AddSeconds(-10);
            _context.ProductPlanProductPlanned.Update(pdoruct);
            _context.SaveChangesAsync();
        }

        public List<ProductManifact2> GetProductManifactByPatternId(int PatternId)
        {
            var dailys = _context.ProductManifacts2.Include(x => x.ProductManifactDetail).ThenInclude(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).Include(x => x.ProductPlanProductPlanned)
                       .ThenInclude(x => x.ProductPlanDailyPlanned)
                       .ThenInclude(x => x.ProductPlanSubPlanned)
                       .Where(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.PatternId == PatternId).ToList();
            foreach (var daily in dailys)
            {
                daily.ProductPlanProductPlanned.ProductPlanDailyPlanned = null;

            }
            foreach (var item in dailys)
            {
                foreach (var detail in item.ProductManifactDetail.ToList())
                {
                    detail.ProductManifact = null;
                }
            }
            return dailys;
        }

        public ProductPlanSubPlanned GetProductPlanSubPlannedById(int id)
        {
            var plan = _context.ProductPlanSubPlanned.Where(x => x.Id == id).Include(x => x.ProductPlan).Include(x => x.ProductPlanDailyPlanned).ThenInclude(x => x.ProductPlanProductPlanned).FirstOrDefault();
            return plan;
        }

        public async Task UrunGunDegistir(int productId, DateTime newDate)
        {
            var product = await _context.ProductPlanProductPlanned
                                        .FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            var eskigunluk = await _context.ProductPlanDailyPlanned
                                           .FirstOrDefaultAsync(x => x.Id == product.ProductPlanDailyPlannedId);
            if (eskigunluk == null)
            {
                throw new ArgumentException("Old daily plan not found.");
            }

            var yenigunluk = await _context.ProductPlanDailyPlanned
                                           .FirstOrDefaultAsync(x => x.ProductPlanSubPlannedId == eskigunluk.ProductPlanSubPlannedId && x.StartTime.Date == newDate.Date);

            if (yenigunluk != null)
            {
                // Ürünün günlüğünü güncelle
                product.StartTime = yenigunluk.StartTime;
                product.EndTime = yenigunluk.EndTime;
                product.ProductPlanDailyPlannedId = yenigunluk.Id;
                _context.ProductPlanProductPlanned.Update(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("No daily plan found for the new date.");
            }
        }

        public ProductPlan GetProductPlanByProjeId(int ProjectId)
        {
            ProductPlan productPlan = new ProductPlan();
            productPlan = _context.ProductPlan.Where(x => x.ProjectModuleSubId == ProjectId).Include(x => x.ProductPlanSubPlanned).FirstOrDefault();
            return productPlan;
        }
    }
}
