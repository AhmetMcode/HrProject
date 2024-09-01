using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class PmCalculateDocuments : BaseEntity
    {
        public int PmCalculateId { get; set; }
        public PmCalculate PmCalculate { get; set; }
        public int RevizeNumber { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
    }
}
