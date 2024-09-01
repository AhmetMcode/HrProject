using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProjectElementStepService : IBaseRepository<ProjectElementStep>
    {
        public List<ProjectElementStep> GetByProjectElementId(int projectElementId);
        public List<ProjectElementStep> GetAllInclude();
        public ProjectElementStep GetByIdInclude(int id);
        public void DeleteStep(int id);
    }
}
