using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class UserEmailService : BaseRepository<UserEmail>, IUserEmailService
    {
        public UserEmailService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
