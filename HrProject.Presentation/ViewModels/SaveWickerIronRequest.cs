using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class SaveWickerIronRequest
    {
        public List<WickerIronCalculate> wickerIronCalculates { get; set; }
        public decimal celikHasirTop { get; set; }
        public int TypeId { get; set; }
        public decimal celikHasirTopTotal2 { get; set; }
    }
    public class SaveRopeIronRequest
    {
        public List<RopeIron> RopeIrons { get; set; }
        public decimal RopeIronTop { get; set; }
        public decimal RopeIronTopTotal { get; set; }
    }
    public class SaveAnkrajIronRequest
    {
        public List<AnkrajIron> AnkrajIrons { get; set; }
        public decimal AnkrajIronTop { get; set; }
        public decimal AnkrajIronTopTotal { get; set; }
    }
    public class OfferCalculateDetailSave
    {
        public ProjectElementDetails ProjectElementDetails { get; set; }
        public decimal NetIron { get; set; }
        public decimal NetIronTotal { get; set; }
        public decimal Concrete { get; set; }
        public decimal NetConcreteTotal { get; set; }
    }
    public class PMCalculateDetailSave
    {
        public PMProjectElementDetails ProjectElementDetails { get; set; }
        public decimal NetIron { get; set; }
        public decimal NetIronTotal { get; set; }
        public decimal Concrete { get; set; }
        public decimal NetConcreteTotal { get; set; }
    }
}
