using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Application.Services
{
    public class LabaratuarSonucService : BaseRepository<LabaratuarSonuc>, ILabaratuarSonucService
    {
        public LabaratuarSonucService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public LabaratuarSonuc EkleVeyaGetir(int dailyId)
        {
            LabaratuarSonuc labaratuarSonuc = new LabaratuarSonuc();
            if (_context.LabaratuarSonuc.Where(x => x.ProductPlanDailyPlannedId == dailyId).FirstOrDefault() != null)
            {
                return _context.LabaratuarSonuc.Where(x => x.ProductPlanDailyPlannedId == dailyId).FirstOrDefault();
            }
            else
            {
                labaratuarSonuc.ProductPlanDailyPlannedId = dailyId;
                _context.LabaratuarSonuc.Add(labaratuarSonuc);
                _context.SaveChanges();
                return labaratuarSonuc;
            }
        }

        public List<ProductPlanDailyPlanned> GetDailyPlanneds()
        {
            // Günlük planları ve ilgili detayları çekmek için LINQ sorgusu
            var urunSokumOnayiPlanlari = _context.ProductPlanDailyPlanned
                .Include(p => p.ProductPlanProductPlanned)
                    .ThenInclude(pp => pp.ProductManifact2)
                        .ThenInclude(pm => pm.ProductManifactDetail)
                            .ThenInclude(pmd => pmd.ProjectElementStep)
                                .ThenInclude(pes => pes.ProductionStep)
                .Where(p => p.ProductPlanProductPlanned
                    .Any(pp => pp.ProductManifact2.ProductManifactDetail
                        .Any(pmd => pmd.ProjectElementStep.ProductionStep.Name == "ÜRÜN KÜRLEME AŞAMASI"
                                    && pmd.StartDate.Year != 1)))
                .ToList();

            return urunSokumOnayiPlanlari;
        }


    }
}
