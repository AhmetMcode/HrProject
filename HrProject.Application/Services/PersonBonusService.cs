using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services;

public class PersonBonusService : BaseRepository<PersonBonus>, IPersonBonusService
{
    public PersonBonusService(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
