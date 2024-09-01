using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class AddProjectViewModel
    {
        public Offer Offer { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
        public List<ProjectModuleStatus> ProjectModuleStatus { get; set; }
        public List<ProductionDrawing> ProductionDrawings { get; set; }
        public IFormFile ArchProject { get; set; }
        public IFormFile GroundReport { get; set; }
    }
}
