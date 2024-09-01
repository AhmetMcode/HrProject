using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Application.Services
{
    public class HolNesneService : BaseRepository<HolNesne>, IHolNesneService
    {
        public HolNesneService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<HolNesne> GetAllInclude()
        {
            return _context.HolNesne.Include(x => x.ProductionPlace).ToList();
        }
    }
}
