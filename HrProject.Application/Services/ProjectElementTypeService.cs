using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProjectElementTypeService : BaseRepository<ProjectElementType>, IProjectElementTypeService
    {
        public ProjectElementTypeService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void AddOfferTechnicals(OfferTechnical offerTechnical)
        {
            _context.OfferTechnicals.Add(offerTechnical);
            _context.SaveChanges();
        }

        public void DeleteOfferTech(int id)
        {
            var tech = _context.OfferTechnicals.Where(x => x.Id == id).FirstOrDefault();
            _context.OfferTechnicals.Remove(tech);
            _context.SaveChanges();
        }

        public List<ProjectElementType> GetProjectElementTypesByInclude()
        {
            return _context.ProjectElementTypes.Include(x => x.ProjectElement).ToList();
        }

        public void UpdateOfferTech(OfferTechnical offerTechnical)
        {
            _context.Update(offerTechnical);
            _context.SaveChanges();
        }

        List<OfferTechnical> IProjectElementTypeService.GetOfferTechnicals()
        {
            return _context.OfferTechnicals.ToList();
        }
    }
}
