using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces;

public interface IPersonPermissionService : IBaseRepository<PersonPermission>
{
    IEnumerable<PersonPermission> GetIncludeType();
}
