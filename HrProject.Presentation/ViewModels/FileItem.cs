namespace HrProject.Presentation.ViewModels
{
    public class FileItem
    {
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public List<FileItem> Subitems { get; set; }
    }

}
