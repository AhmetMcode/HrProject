using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class PersonelDocumentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentCode { get; set; }
        public IFormFile Template { get; set; }
        public int? PersonelAuthorityId { get; set; }
        public PersonelAuthority PersonelAuthority { get; set; }
        public List<PersonelAuthority> PersonelAuthorities { get; set; }
        public IEnumerable<PersonelInterDoc> PersonelInterDocs { get; set; }
        public bool IsRequired { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public PersonelInterDoc PersonelInterDoc { get; set; }
        public PersAddDoc PersAddDoc { get; set; }
        public IEnumerable<Person> Personals { get; set; }
        public List<PersAddDoc> PersAddDocs { get; set; }
        public IEnumerable<PersonelDocument> PersonelDocuments { get; set; }
        public int PersonelDocumentId { get; set; }
        public PersonelDocument PersonelDocument { get; set; }
        public DateTime SigningDate { get; set; }
        public IFormFile SigningDocument { get; set; }
    }
}
