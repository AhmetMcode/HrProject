using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.ViewModels;

namespace HrProject.Presentation.Controllers
{
    public class VisitorController : Controller
    {

        private readonly IVisitorEntryService visitorEntryService;
        private readonly IPersonService personService;
        private readonly IMapper mapper;

        public VisitorController(IVisitorEntryService visitorEntryService, IPersonService personService, IMapper mapper)


        {

            this.visitorEntryService = visitorEntryService;
            this.personService = personService;
            this.mapper = mapper;
        }

        public IActionResult AddVisitorEntry()
        {
            ViewBag.Persons = personService.GetAll();
            return View();

        }

        [HttpPost]
        public IActionResult AddVisitorEntry(VisitorEntry visitorEntry)
        {
            ViewBag.Persons = personService.GetAll();
            visitorEntryService.Insert(visitorEntry);
            return RedirectToAction("GetVisitorList");
        }

        public IActionResult GetVisitorList(DateTime? startDate, DateTime? endDate, string visitorName, string personelName, VisitReason? visitReason, VisitorStatus? visitorStatus, int page = 1, int pageSize = 10)
        {
            // Veritabanından tüm kayıtları al
            var allEntries = visitorEntryService.GetIncludeVisitorEntry();

            // Filtreleme işlemlerini uygula
            if (startDate != null || endDate != null)
            {
                allEntries = allEntries.Where(sc => (!startDate.HasValue || sc.EntryTime.Date >= startDate) &&
                                                   (!endDate.HasValue || sc.EntryTime.Date <= endDate));
            }

            if (!string.IsNullOrEmpty(visitorName))
            {

                // Turkish to English dönüşüm işlemi
                allEntries = allEntries.Where(sc => sc.VisitorName.ToLower().Contains(visitorName.ToLower()) || sc.VisitorName.Contains(visitorName));
            }

            if (!string.IsNullOrEmpty(personelName))
            {

                // Turkish to English dönüşüm işlemi

                allEntries = allEntries.Where(sc => sc.Person != null &&
                                                    ((sc.Person.Name + " " + sc.Person.Surname).ToLower().Contains(personelName.ToLower()) ||
                                                     (sc.Person.Name + " " + sc.Person.Surname).Contains(personelName)));
            }

            if (visitReason != null)
            {
                allEntries = allEntries.Where(sc => sc.VisitReason == visitReason);
            }

            if (visitorStatus != null)
            {
                allEntries = allEntries.Where(sc => sc.VisitorStatus == visitorStatus);
            }

            // Sıralama ve sayfalama işlemlerini uygula
            var filteredEntries = allEntries.OrderByDescending(sc => sc.EntryTime)
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();

            // ViewModel'i oluştur ve view'a gönder
            var vm = new VisitorViewModel
            {
                VisitorEntries = filteredEntries,
                // Diğer ViewData değerlerini de set et
            };
            ViewData["PrevPage"] = page > 1 ? page - 1 : (int?)null;
            ViewData["NextPage"] = allEntries.Count() > (page * pageSize) ? page + 1 : (int?)null;
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;
            ViewData["personelName"] = personelName;
            ViewData["visitorName"] = visitorName;
            ViewData["visitReason"] = visitReason;
            ViewData["visitorStatus"] = visitorStatus;
            ViewData["PageSize"] = pageSize;

            return View(vm);
        }



        [HttpPost]
        public IActionResult GetVisitorList(VisitorViewModel Vm)
        {

            VisitorEntry visit = mapper.Map<VisitorViewModel, VisitorEntry>(Vm);
            visitorEntryService.Insert(visit);
            return View();
        }



        public IActionResult VisitorExitTime(int id)
        {
            var data = visitorEntryService.GetById(id);
            data.VisitorStatus = Domain.Enums.VisitorStatus.Çıkış_Yaptı;
            data.ExitTime = DateTime.Now;
            visitorEntryService.Update(data);
            return Json("ok");
        }


        [HttpGet]
        public IActionResult UpdateVisitorEntry(int id)
        {
            ViewBag.Persons = personService.GetAll();
            var result = visitorEntryService.GetById(id);
            var resul2 = mapper.Map<VisitorViewModel>(result);
            return View(resul2);

        }
        [HttpPost]
        public IActionResult UpdateVisitorEntry(VisitorViewModel Vm)
        {
            ViewBag.Persons = personService.GetAll();
            //VisitorEntry visitorEntry = new VisitorEntry();
            //visitorEntry.PersonId = Vm.PersonId;

            VisitorEntry visitor = mapper.Map<VisitorViewModel, VisitorEntry>(Vm);
            visitorEntryService.Update(visitor);
            return RedirectToAction("GetVisitorList");
        }



        [HttpGet]
        public IActionResult GetPersonInfo(int id)
        {
            var result = personService.GetByIdIncDepartman(id);

            return Json(result);
        }




    }
}
