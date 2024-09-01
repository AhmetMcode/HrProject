using Microsoft.AspNetCore.Http;
using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IUnitService : IBaseRepository<Unit>
    {
        public List<ProjectElement> GetProjectElements();
        public List<ProjectElementType> GetProjectElementTypes();
        public ProjectElement GetProjectElementsById(int id);
        public List<ConcreteClass> GetConcreteClass();
        public List<IronDiameterWeight> GetIronDiameterWeight();
        public List<SteelMeshType> GetStellMesh();
        public List<ToronDiameter> GetToronDiameter();
        public string GetLogo();
        public InfoCompany GetinfoCompany();
        public InfoCompany GetAddinfoCompany(InfoCompany company, IFormFile resim);
    }
}
