using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class EDocumentBaseRateService : BaseRepository<EDocumentBaseRate>, IEDocumentBaseRateService
    {
        public EDocumentBaseRateService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
