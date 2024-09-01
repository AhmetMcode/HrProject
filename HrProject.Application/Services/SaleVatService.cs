using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class SaleVatService : BaseRepository<SaleVat>, ISaleVatService
    {
        public SaleVatService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
