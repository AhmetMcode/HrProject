using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class AlperenUretim : BaseEntity
    {
        public DateTime Tarih { get; set; }
        public decimal Uretim { get; set; }
    }
}
