using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class PersAddDocService : BaseRepository<PersAddDoc>, IPersAddDocService
    {
        public PersAddDocService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
