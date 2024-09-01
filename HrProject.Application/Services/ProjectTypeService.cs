using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProjectTypeService : BaseRepository<ProjectType>, IProjectTypeService
    {
        public ProjectTypeService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
