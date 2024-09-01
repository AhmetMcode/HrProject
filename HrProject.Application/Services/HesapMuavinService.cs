using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class HesapMuavinService : BaseRepository<HesapMuavin>, IHesapMuavinService
    {
        public HesapMuavinService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public bool IsCodeOrNameExists(int hesapPlaniId, string hesapCode, string? hesapName)
        {
            return _context.HesapMuavins.Any(h => h.HesapPlaniId == hesapPlaniId && (h.HesapCode == hesapCode || h.HesapName == hesapName));
        }



    }
}
