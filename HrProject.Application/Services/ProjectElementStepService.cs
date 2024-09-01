using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProjectElementStepService : BaseRepository<ProjectElementStep>, IProjectElementStepService
    {
        public ProjectElementStepService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void DeleteStep(int id)
        {
            var stepToDelete = _context.ProjectElementStep.Find(id);
            if (stepToDelete == null)
            {
                // Belirtilen adımdan örnek bulunamadı, hata fırlat veya işlemi sonlandır.
                return;
            }

            var asd = _context.ProductManifactDetails.Where(x => x.ProjectElementStepId == id).ToList();
            _context.ProductManifactDetails.RemoveRange(asd);
            _context.ProjectElementStep.Remove(stepToDelete);
            _context.SaveChanges();

            // Silinen adımdan sonra sıralamayı güncelle
            ReorderStepsAfterDeletion(stepToDelete.ProjectElementId, stepToDelete.Sequence);
        }

        private void ReorderStepsAfterDeletion(int projectElementId, int deletedSequence)
        {
            // Silinen adımdan sonraki adımların sırasını güncelle
            var stepsToUpdate = _context.ProjectElementStep
                .Where(x => x.ProjectElementId == projectElementId && x.Sequence > deletedSequence)
                .OrderBy(x => x.Sequence)
                .ToList();

            foreach (var step in stepsToUpdate)
            {
                step.Sequence--; // Sıralamayı bir azalt
            }

            _context.SaveChanges();
        }

        public List<ProjectElementStep> GetAllInclude()
        {
            return _context.ProjectElementStep.Include(x => x.ProjectElement).Include(x => x.ProductionStep).ThenInclude(x => x.ManifactStepType).ToList();
        }

        public List<ProjectElementStep> GetByProjectElementId(int projectElementId)
        {
            return _context.ProjectElementStep.Where(x => x.ProjectElementId == projectElementId).Include(x => x.ProjectElement).Include(x => x.ProductionStep).ThenInclude(x => x.ManifactStepType).ToList();
        }

        public ProjectElementStep GetByIdInclude(int id)
        {
            return _context.ProjectElementStep.Include(x => x.ProjectElement).Include(x => x.ProductionStep).ThenInclude(x => x.ManifactStepType)
                .Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
