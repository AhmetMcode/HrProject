using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels;

public class PermissionViewModel
{
    public PermissionViewModel()
    {
        NewPermissionType = new PersonPermissionType();
    }
    public IEnumerable<PersonPermissionType> ExistingPermissionTypes { get; set; }
    public PersonPermissionType NewPermissionType { get; set; }
}
