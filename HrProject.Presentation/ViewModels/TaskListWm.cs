using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class TaskListWm
    {
        public List<ProductionDrawing> ProductionDrawings { get; set; }
        public List<ProjectModuleStatus> ProjectModuleStatus { get; set; }
    }
}
