using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class LogsKayitService : BaseRepository<LogKayit>, ILogsKayitService
    {
        public LogsKayitService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public LogKayit SonGiris(string userId)
        {
            return _context.LogKayits
                  .Where(x => x.ApplicationUserId == userId && x.YapilanIslem == "Giriş")
                  .OrderByDescending(x => x.GerceklesmeZamani) // Tarih'e göre sıralama
                  .FirstOrDefault(); // İlk kaydı al
        }
    }
}
