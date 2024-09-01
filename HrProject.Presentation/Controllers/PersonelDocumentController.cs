using Microsoft.AspNetCore.Mvc;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Models;
using HrProject.Presentation.ViewModels;

namespace HrProject.Presentation.Controllers
{
    public class PersonelDocumentController : Controller
    {
        private readonly IPersonelAuthorityService personelAuthorityService;
        private readonly IPersonelDocumentService personelDocumentService;
        private readonly IPersonelInterDocService personelInterDocService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPersonService personService;

        public PersonelDocumentController(IPersonelAuthorityService personelAuthorityService, IPersonelDocumentService personelDocumentService, IPersonelInterDocService personelInterDocService, IWebHostEnvironment webHostEnvironment, IPersonService personService)
        {
            this.personelAuthorityService = personelAuthorityService;
            this.personelDocumentService = personelDocumentService;
            this.personelInterDocService = personelInterDocService;
            this.webHostEnvironment = webHostEnvironment;
            this.personService = personService;
        }
        public IActionResult GetAuthority()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthority(PersonelDocumentViewModel Vm)
        {
            PersonelAuthority authority = new PersonelAuthority
            {
                Id = Vm.Id,
                Name = Vm.Name,
            };
            personelAuthorityService.Insert(authority);
            return RedirectToAction("GetPerDocument");
        }

        public IActionResult GetPerDocument()
        {
            ViewBag.PersonelAuthority = personelAuthorityService.GetAll();
            var VM = new PersonelDocumentViewModel();
            //VM.PersonelAuthorities = personelAuthorityService.GetAll();
            return View(VM);
        }

        [HttpPost]
        public IActionResult AddPerDocument(PersonelDocumentViewModel Vm)
        {
            ViewBag.PersonelAuthority = personelAuthorityService.GetAll();
            PersonelDocument perdoc = new PersonelDocument
            {
                Id = Vm.Id,
                DocumentCode = Vm.DocumentCode,
                Template = FileWork.ReturnFileName(Vm.Template, "perdocument", webHostEnvironment),
                PersonelAuthorityId = Vm.PersonelAuthorityId,
                IsRequired = Vm.IsRequired,
            };
            personelDocumentService.Insert(perdoc);
            return RedirectToAction("GetPersonel");
        }

        public IActionResult GetPersonel()
        {
            ViewBag.PersonelDocuments = personelDocumentService.GetAll();
            ViewBag.Personals = personService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddPersonel(PersonelDocumentViewModel Vm)
        {
            ViewBag.PersonelDocuments = personelDocumentService.GetAll();
            ViewBag.Personals = personService.GetAll();
            PersonelInterDoc pers = new PersonelInterDoc
            {
                Id = Vm.Id,
                PersonId = Vm.PersonId,
                PersAddDocs = Vm.PersAddDocs,
            };
            personelInterDocService.Insert(pers);
            return RedirectToAction("GetPerDocument");
        }

        public IActionResult GetDocList(int authorityId, string documentCode, bool? IsRequired)
        {
            // Veritabanından tüm kayıtları al
            ViewBag.PersonelAuthorities = personelAuthorityService.GetAll();
            var allEntries = personelDocumentService.GetIncludePerDoc();

            // Filtreleme işlemlerini uygula

            if (authorityId != 0)
            {
                allEntries = allEntries.Where(sc => sc.PersonelAuthorityId == authorityId);
            }

            if (!string.IsNullOrEmpty(documentCode))
            {
                // Turkish to English dönüşüm işlemi
                allEntries = allEntries.Where(sc => sc.DocumentCode.ToLower().Contains(documentCode.ToLower()) || sc.DocumentCode.Contains(documentCode));
            }


            if (IsRequired.HasValue)
            {
                allEntries = allEntries.Where(sc => sc.IsRequired == IsRequired.Value);
            }

            var filteredDoc = allEntries.OrderByDescending(sc => sc.DocumentCode).ToList();

            var vm = new PersonelDocumentViewModel
            {
                PersonelDocuments = filteredDoc,
                //IsRequired = IsRequired
            };

            ViewData["authorityId"] = authorityId;
            ViewData["documentCode"] = documentCode;

            return View(vm);
        }
        [HttpGet]
        public IActionResult GetPerDocList(int[] personId, int[] authorityIds)
        {
            ViewBag.Personals = personService.GetAll();
            var allEntries = personService.GetAll();
            var filteredAuthList = new List<PersonelAuthority>();
            ViewBag.AllAuthories = personelAuthorityService.GetAll().ToList();
            if (personId.Count() != 0)
            {
                allEntries = allEntries.Where(x => personId.Contains(x.Id));
            }
            if (authorityIds.Count() != 0)
            {
                var documentList2 = personelDocumentService.Where(x => authorityIds.Contains(x.PersonelAuthorityId.Value)).ToList();
                filteredAuthList = personelAuthorityService.Where(x => authorityIds.Contains(x.Id)).ToList();
                ViewBag.DocumentList = documentList2;
            }
            else
            {
                var documentList2 = personelDocumentService.Where(x => authorityIds.Contains(x.PersonelAuthorityId.Value)).ToList();
                filteredAuthList = personelAuthorityService.GetAll().ToList();

                ViewBag.DocumentList = documentList2;
            }
            var filteredDoc = allEntries.OrderBy(sc => sc.Name).ToList();

            PersonelDocumentViewModel pers = new PersonelDocumentViewModel();

            pers.PersonelInterDocs = personelInterDocService.GetIncludePerInterDoc();
            pers.PersonelDocuments = personelDocumentService.GetIncludePerDoc();
            pers.Personals = filteredDoc;
            ViewBag.FilteredAuthories = filteredAuthList;
            ViewData["personId"] = personId;


            return View(pers);

        }

        public IActionResult GetRequiredDocPerList(int authorityId)
        {
            // Veritabanından tüm kayıtları al

            var filteredAuthList = personelDocumentService.GetIncludePerDoc();
            ViewBag.PersonelAuthorities = personelAuthorityService.GetAll();

            if (authorityId != 0)
            {
                filteredAuthList = filteredAuthList
                    .Where(sc => sc.PersonelAuthorityId == authorityId && sc.IsRequired);
            }

            var filteredDocGroups = filteredAuthList
                .Where(sc => sc.IsRequired)
                .GroupBy(sc => sc.PersonelAuthorityId)
                .Select(group => group.First())
                .ToList();

            PersonelDocumentViewModel pers = new PersonelDocumentViewModel();

            pers.PersonelInterDocs = personelInterDocService.GetIncludePerInterDoc()
                .Where(pd => pd.PersAddDocs.Any(pad => filteredDocGroups.Any(sc => sc.Id == pad.PersonelDocumentId)))
                .ToList();

            pers.PersonelDocuments = filteredAuthList; // Filtrelenmiş listeyi doğrudan kullanın
            ViewBag.FilteredAuthories = filteredDocGroups;

            return View(pers);
        }

    }
}
