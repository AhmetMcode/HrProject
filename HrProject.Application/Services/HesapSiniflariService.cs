using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class HesapSiniflariService : BaseRepository<HesapSiniflari>, IHesapSiniflariService
    {
        public HesapSiniflariService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<HesapSiniflari> GetAllHesapSiniflar()
        {
            return _context.HesapSiniflaris
            .Include(hs => hs.HesapGruplari)
                .ThenInclude(hg => hg.HesapPlani).ThenInclude(hp => hp.HesapMuavin).ThenInclude(hm => hm.HesapTali).ThenInclude(ht => ht.HesapDetay)
            .ToList();
        }
    }
}
