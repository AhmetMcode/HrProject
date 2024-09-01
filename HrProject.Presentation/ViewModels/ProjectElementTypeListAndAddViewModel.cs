using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class ProjectElementTypeListAndAddViewModel
    {
        public List<ProjectElementType> ProjectElementType { get; set; }
        public List<ProjectElement> ProjectElement { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ProjectElementId { get; set; }
    }
}
