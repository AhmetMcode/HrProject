using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.Data;
using HrProject.Presentation.Data.Migrations;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class RopeIronPmService : BaseRepository<RopeIronPm>, IRopeIronPmService
    {
        public RopeIronPmService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
