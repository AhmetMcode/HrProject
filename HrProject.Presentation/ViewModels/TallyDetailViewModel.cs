using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels;

public class TallyDetailViewModel
{
    public IEnumerable<Person> Persons { get; set; }
    public IEnumerable<TallyDetail> TallyDetails { get; set; }
    public IEnumerable<DateTime> DateTimes { get; set; }

}
