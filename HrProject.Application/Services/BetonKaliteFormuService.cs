using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    internal class BetonKaliteFormuService : BaseRepository<BetonKontrolFormuSub>, IBetonKaliteFormu
    {
        public BetonKaliteFormuService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


    }
}
