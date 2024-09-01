using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services;

public class TallyDetailService : BaseRepository<TallyDetail>, ITallyDetailService
{
    public TallyDetailService(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    

    public List<TallyDetail> GetTailiesByMounth(DateTime tarih, List<int> personIds)
    {
        return _context.TallyDetail.Where(x => x.DayOfWork.Month == tarih.Month &&
                                                        x.DayOfWork.Year == tarih.Year &&
                                                        personIds.Contains(x.PersonId)).Include(x => x.Person).ToList();
    }
}
