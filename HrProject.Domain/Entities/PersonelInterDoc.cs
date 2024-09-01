using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class PersonelInterDoc : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public List<PersAddDoc> PersAddDocs { get; set; }

    }
}
