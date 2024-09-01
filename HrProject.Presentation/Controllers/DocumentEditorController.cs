using Microsoft.AspNetCore.Mvc;

namespace HrProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class DocumentEditorController : Controller
    {
    }

    public class CustomParameter
    {
        public string content { get; set; }
        public string type { get; set; }
    }

    public class CustomRestrictParameter
    {
        public string passwordBase64 { get; set; }
        public string saltBase64 { get; set; }
        public int spinCount { get; set; }
    }
}



