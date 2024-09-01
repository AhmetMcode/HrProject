using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class NewFoodService : BaseRepository<NewFood>, INewFoodService
    {
        public NewFoodService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IEnumerable<NewFood> GetIncludeNewFood()
        {
            var result = _context.NewFoods.Include(x => x.Stock).Include(x => x.Unit);
            return result;
        }





    }
}
