using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProjectService : BaseRepository<Project>, IProjectService
    {
        public ProjectService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
