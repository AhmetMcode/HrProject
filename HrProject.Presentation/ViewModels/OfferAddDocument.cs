using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class OfferAddDocument
    {
        public int OfferId { get; set; }
        public int Id { get; set; }
        public Offer Offer { get; set; }
        public IFormFile Document1File { get; set; }
        public IFormFile? Document2File { get; set; }
        public IFormFile? Document3File { get; set; }
        public IFormFile? Document4File { get; set; }
        public IFormFile? Document5File { get; set; }
        public IFormFile? Document6File { get; set; }
        public string Document1 { get; set; }
        public string Document2 { get; set; }
        public string Document3 { get; set; }
        public string Document4 { get; set; }
        public string Document5 { get; set; }
        public string Document6 { get; set; }
    }
}
