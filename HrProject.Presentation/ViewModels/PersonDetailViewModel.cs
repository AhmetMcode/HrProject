using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class PersonDetailViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<PersonPosition> PersonPositions { get; set; }
        public IEnumerable<Workplace> Workplaces { get; set; }
        public PersonSalary PersonSalary { get; set; }
        public PersonCreateVM PersonCreateVM { get; set; }
        public PostType PostType { get; set; }
        public IEnumerable<PersonSalary> PersonSalaries { get; set; }
        public IEnumerable<PersonBonus> PersonBonuses { get; set; }
        public IEnumerable<PersonAdvancePayment> PersonAdvancePayments { get; set; }
        public IEnumerable<PersonPermission> PersonPermissions { get; set; }
        public IEnumerable<PersonPermissionType> PersonPermissionTypes { get; set; }
        public PersonBonus PersonBonus { get; set; }
        public PersonAnnualLeave PersonAnnualLeave { get; set; }
        public IEnumerable<PersonAnnualLeave> PersonAnnualLeaves { get; set; }
        public PersonPermission PersonPermission { get; set; }
        public PersonIstenCikar PersonIstenCikar { get; set; }
        public PersonPermissionType PersonPermissionType { get; set; }
        public PersonAdvancePayment PersonAdvancePayment { get; set; }
        public IFormFile PersonPermissionFile { get; set; }
        public IFormFile IstenCikisDosya { get; set; }
        public List<ISGSafetyIssue> Issues { get; set; }
    }

    public enum PostType
    {
        All,
        Document

    }
}
