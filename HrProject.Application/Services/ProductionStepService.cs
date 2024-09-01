using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProductionStepService : BaseRepository<ProductionStep>, IProductionStepService
    {
        public ProductionStepService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<ProductionStep> GetByProjectElementId(int projectElementId)
        {
            var list = new List<ProductionStep>();
            var projectElementStpeps = _context.ProjectElementStep.Where(x => x.ProjectElementId == projectElementId).Include(x => x.ProductionStep).ToList();
            if (projectElementStpeps != null)
            {
                list = projectElementStpeps.Select(x => x.ProductionStep).ToList();
            }
            return list;
        }

        public List<ManifactStepType> GetManifactStepTypes()
        {
            return _context.ManifactStepTypes.ToList();
        }
    }
}
