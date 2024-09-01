using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class FileUploadLog : BaseEntity
    {
        public DateTime UploadDate { get; set; }
        public string UploadUserId { get; set; }
        public string UploadFileName { get; set; }
        public string UploadFolderName { get; set; }
        public ApplicationUser UploadUser { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
        public int? ProjectModuleSubId { get; set; }
    }
}
