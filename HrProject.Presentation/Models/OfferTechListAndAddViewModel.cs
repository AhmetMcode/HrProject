using HrProject.Domain.Entities;

namespace HrProject.Presentation.Models
{
    public class OfferTechListAndAddViewModel
    {
        public List<OfferTechnical> OfferTechnicals { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string? DefaultValue { get; set; }

    }
}
