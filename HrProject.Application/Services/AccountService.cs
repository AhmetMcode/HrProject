using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class AccountService : BaseRepository<Account2>, IAccountService
    {
        public AccountService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
