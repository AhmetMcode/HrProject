using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProductionPlaceService : BaseRepository<ProductionPlace>, IProductionPlace
    {
        public ProductionPlaceService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
