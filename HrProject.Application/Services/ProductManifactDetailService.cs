using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProductManifactDetailService : BaseRepository<ProductManifactDetail>, IProductManifactDetail
    {
        public ProductManifactDetailService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void AddImageForStep(int id, string resim)
        {
            ProductManifactDetailImages productManifactDetailImages = new ProductManifactDetailImages();
            productManifactDetailImages.ProductManifactDetailId = id;
            productManifactDetailImages.ImagePath = resim;
            _context.ProductManifactDetailImages.Add(productManifactDetailImages);
            _context.SaveChanges();
        }

        public ProductManifactDetail GetByActiveManifactInclude(int id)
        {
            var manifact = _context.ProductManifacts2.Where(x => x.Id == id).FirstOrDefault();
            var activeDetail = _context.ProductManifactDetails.Where(x => x.ProductManifact2Id == id && x.ProductStepEnum == ProductStepDurumEnum.Start || x.ProductStepEnum == ProductStepDurumEnum.Revize).FirstOrDefault();
            if (activeDetail == null)
            {
                activeDetail = _context.ProductManifactDetails.Where(x => x.ProductManifact2Id == id && x.ProductStepEnum == ProductStepDurumEnum.None).FirstOrDefault();
            }
            return activeDetail;
        }

        public ProductManifactDetail GetByIdInclude(int id)
        {
            return _context.ProductManifactDetails.Where(x => x.Id == id).Include(x => x.ProductManifact).Include(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).ThenInclude(x => x.ManifactStepType).FirstOrDefault();
        }

        public ProductManifactDetail GetByIdNextInclude(int id)
        {
            var productManifat = _context.ProductManifactDetails.Where(x => x.Id == id).Include(x => x.ProductManifact).Include(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).FirstOrDefault();
            int seq = productManifat.ProjectElementStep.Sequence + 1;
            return _context.ProductManifactDetails.Where(x => x.ProductManifact2Id == productManifat.ProductManifact2Id && x.ProjectElementStep.Sequence == seq).Include(x => x.ProductManifact).Include(x => x.ProjectElementStep).ThenInclude(x => x.ProductionStep).FirstOrDefault();
        }
    }
}
