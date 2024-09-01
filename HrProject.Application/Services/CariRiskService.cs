using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class CariRiskService : BaseRepository<CariRisk>, ICariRiskService
    {
        public CariRiskService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
