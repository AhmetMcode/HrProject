using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class HesapTaliService : BaseRepository<HesapTali>, IHesapTaliService
    {
        public HesapTaliService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
