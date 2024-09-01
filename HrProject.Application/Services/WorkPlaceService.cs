using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class WorkPlaceService : BaseRepository<Workplace>, IWorkPlaceService
    {
        public WorkPlaceService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<SelectListItem> GetWorkPlaceAsSelectListItems()
        {
            var workPlace = _context.Workplaces.ToList();
            var workPlaceListItems = workPlace.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            return workPlaceListItems;
        }
    }
}
