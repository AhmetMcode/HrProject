using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class TaxOfficeService : BaseRepository<TaxOffice>, ITaxOfficeService
    {
        public TaxOfficeService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
