using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class HesapPlaniService : BaseRepository<HesapPlani>, IHesapPlaniService
    {
        public HesapPlaniService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public HesapPlani GetHesapDetails(int hesapPlaniId)
        {
            // hesapPlaniId'ye göre veritabanından hesap detaylarını al
            var hesap = _context.HesapPlanis
                .Include(h => h.HesapGruplari) // Gerekirse ilişkili tabloları dahil et
                .FirstOrDefault(h => h.Id == hesapPlaniId);

            return hesap;
        }
    }
}
