using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services;

public class PersonPermissionService : BaseRepository<PersonPermission>, IPersonPermissionService
{
    public PersonPermissionService(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public IEnumerable<PersonPermission> GetIncludeType()
    {
        return _context.PersonPermissions.Include(x => x.PersonPermissionType);
    }
}
