namespace HrProject.Presentation.ViewModels
{
    public class ProductionDrawingAddVm
    {
        public int SubId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ResponsUserId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}
