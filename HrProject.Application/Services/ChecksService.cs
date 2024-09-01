using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ChecksService : BaseRepository<Checks>, IChecksService
    {
        public ChecksService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public IEnumerable<Checks> GetIncludeChecks()
        {
            var checks = _context.Checkses
                .Include(c => c.CariKart)
                .ToList();

            return checks;
        }

        public void UpdateCirolaStatus(int checkId)
        {
            var result = _context.Checkses.FirstOrDefault(x => x.Id == checkId);
            result.CheckStatusEnum = Domain.Enums.CheckStatusEnum.Cirolu;
            _context.Checkses.Update(result);
            _context.SaveChanges();
        }

        public void UpdateStatus(bool inMoney, int checkId)
        {
            var result = _context.Checkses.FirstOrDefault(x => x.Id == checkId);

            if (inMoney)
            {
                result.CheckStatusEnum = Domain.Enums.CheckStatusEnum.TahsilEdildi;
            }
            else
            {
                result.CheckStatusEnum = Domain.Enums.CheckStatusEnum.Ödendi;
            }
            _context.Checkses.Update(result);
            _context.SaveChanges();
        }
    }
}
