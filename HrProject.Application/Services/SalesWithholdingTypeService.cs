using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class SalesWithholdingTypeService : BaseRepository<SalesWithholdingType>, ISalesWithholdingTypeService
    {
        public SalesWithholdingTypeService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
