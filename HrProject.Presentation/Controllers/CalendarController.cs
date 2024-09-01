using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrProject.Presentation.Controllers
{
    [Authorize] // Yetkilendirme eklemesi

    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
