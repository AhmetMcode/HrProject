using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class UnitService : BaseRepository<Unit>, IUnitService
    {
        public UnitService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        private string ConvertToBase64(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }
        public InfoCompany GetAddinfoCompany(InfoCompany company, IFormFile resim)
        {



            if (company.Id != 0)
            {
                _context.InfoCompany.Update(company);

                _context.SaveChanges();
                return company;
            }
            else
            {
                company.Id = 0;
                _context.InfoCompany.Add(company);
                _context.SaveChanges();
                return company;
            }
        }

        public List<ConcreteClass> GetConcreteClass()
        {
            return _context.ConcreteClass.ToList();

        }

        public InfoCompany GetinfoCompany()
        {
            return _context.InfoCompany.FirstOrDefault();
        }

        public List<IronDiameterWeight> GetIronDiameterWeight()
        {
            return _context.IronDiameterWeights.ToList();
        }

        public string GetLogo()
        {
            return _context.InfoCompany.FirstOrDefault().Resim;
        }

        public List<ProjectElement> GetProjectElements()
        {
            return _context.ProjectElements.ToList();
        }

        public ProjectElement GetProjectElementsById(int id)
        {
            return _context.ProjectElements.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<SteelMeshType> GetStellMesh()
        {
            return _context.SteelMeshType.ToList();
        }

        public List<ToronDiameter> GetToronDiameter()
        {
            return _context.ToronDiameters.ToList();
        }

        public List<ProjectElementType> GetProjectElementTypes()
        {
            var resul = _context.ProjectElementTypes.ToList();
            return resul;
        }
    }
}
