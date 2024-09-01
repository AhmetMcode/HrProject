using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class MessageModuleService : BaseRepository<MessageModule>, IMessageModuleService
    {
        public MessageModuleService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
