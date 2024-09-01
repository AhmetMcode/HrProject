using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class PersonelDocument : BaseEntity
    {
        public string DocumentCode { get; set; }
        public string Template { get; set; }
        public int? PersonelAuthorityId { get; set; }
        public PersonelAuthority PersonelAuthority { get; set; }
        public bool IsRequired { get; set; }
    }
}
