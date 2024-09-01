using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces;

public interface IPersonAnnualLeaveService : IBaseRepository<PersonAnnualLeave>
{
    int GetTotalPermissionDay(int PersonId);
    public int GetUsePermission(int personId);
}
