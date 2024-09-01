using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Application.Services;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.Models;
using HrProject.Presentation.ViewModels;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Syncfusion.EJ2.FileManager.Base;

namespace HrProject.Presentation.Controllers
{
    public class HumanResourceController : Controller
    {
        private readonly IPersonPositionService personPositionService;
        private readonly IWorkPlaceService workPlaceService;
        private readonly IMapper mapper;
        private readonly IPersonService personService;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IPersonSalaryService personSalaryService;
        private readonly IPersonBonusService personBonusService;
        private readonly IPersonAdvancePaymentService personAdvancePaymentService;
        private readonly IPersonPermissionService personPermissionService;
        private readonly IPersonPermissionTypeService personPermissionTypeService;
        private readonly IPersonAnnualLeaveService personAnnualLeaveService;
        private readonly ITallyDetailService tallyDetailService;
        private readonly IPersonIstenCikarService personIstenCikarService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISafetyIssueService safetyIssueService;

        public HumanResourceController(IPersonPositionService personPositionService, IWorkPlaceService workPlaceService, IMapper mapper, IPersonService personService, IWebHostEnvironment hostEnvironment, IPersonSalaryService personSalaryService, IPersonBonusService personBonusService, IPersonAdvancePaymentService personAdvancePaymentService, IPersonPermissionService personPermissionService, IPersonPermissionTypeService personPermissionTypeService, IPersonAnnualLeaveService personAnnualLeaveService, ITallyDetailService tallyDetailService, IPersonIstenCikarService personIstenCikarService, UserManager<ApplicationUser> userManager, ISafetyIssueService safetyIssueService)

        {
            this.personPositionService = personPositionService;
            this.workPlaceService = workPlaceService;
            this.mapper = mapper;
            this.personService = personService;
            this.hostEnvironment = hostEnvironment;
            this.personSalaryService = personSalaryService;
            this.personBonusService = personBonusService;
            this.personAdvancePaymentService = personAdvancePaymentService;
            this.personPermissionService = personPermissionService;
            this.personPermissionTypeService = personPermissionTypeService;
            this.personAnnualLeaveService = personAnnualLeaveService;
            this.tallyDetailService = tallyDetailService;
            this.personIstenCikarService = personIstenCikarService;
            this.userManager = userManager;
            this.safetyIssueService = safetyIssueService;
        }
        public IActionResult Index()
        {
            var result = personService.GetPersonInclude();

            return View(result);
        }

        public IActionResult PersonelDetail(int id)
        {
            ViewBag.UsedDay = personAnnualLeaveService.GetUsePermission(id);
            var result = personService.GetPersonInclude(id);
            ViewBag.Positions = personPositionService.GetPersonPositionsAsSelectListItems();
            ViewBag.WorkPlaces = workPlaceService.GetWorkPlaceAsSelectListItems();

            // Get the issues related to the person
            var issues = safetyIssueService.GetIssuesByPersonId(id);

            // Dictionary to store the user's full name
            var userNames = new Dictionary<string, string>();

            // Populate the userNames dictionary with user details
            foreach (var issue in issues)
            {
                if (!string.IsNullOrEmpty(issue.ReportedById) && !userNames.ContainsKey(issue.ReportedById))
                {
                    var user = userManager.FindByIdAsync(issue.ReportedById).Result;
                    if (user != null)
                    {
                        userNames[issue.ReportedById] = $"{user.Name} {user.SurName}";
                    }
                }
            }

            ViewBag.UserNames = userNames;

            PersonDetailViewModel viewModel = new PersonDetailViewModel
            {
                PersonSalary = result.PersonSalaries.FirstOrDefault(x => x.IsActive),
                Person = result,
                PersonSalaries = personSalaryService.GetPersonSalaries(id),
                PersonBonuses = personBonusService.Where(x => x.PersonId == id),
                PersonAdvancePayments = personAdvancePaymentService.Where(x => x.PersonId == id),
                PersonPermissions = personPermissionService.GetIncludeType().Where(x => x.PersonId == id),
                PersonPermissionTypes = personPermissionTypeService.GetAll(),
                PersonAnnualLeaves = personAnnualLeaveService.GetAll(),
                Issues = issues
            };

            ViewBag.TotalPermission = personAnnualLeaveService.GetTotalPermissionDay(id);

            return View(viewModel);
        }



        public IActionResult CreatePerson()
        {
            List<SelectListItem> positions = personPositionService.GetPersonPositionsAsSelectListItems();
            List<SelectListItem> workPlace = workPlaceService.GetWorkPlaceAsSelectListItems();

            var viewModel = new PersonCreateVM
            {
                PositionsList = positions,
                WorkPlaceList = workPlace
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CreatePerson(PersonCreateVM personCreateVM)
        {
            var person = new Person();
            var newPerson = mapper.Map(personCreateVM, person);

            newPerson.IdCard = FileWork.ReturnFileName(personCreateVM.IdCard, "HR", hostEnvironment);
            newPerson.PlaceOfResidence = FileWork.ReturnFileName(personCreateVM.PlaceOfResidence, "HR", hostEnvironment);
            newPerson.Diploma = FileWork.ReturnFileName(personCreateVM.Diploma, "HR", hostEnvironment);
            newPerson.CriminalRecord = FileWork.ReturnFileName(personCreateVM.CriminalRecord, "HR", hostEnvironment);
            newPerson.PopulationRegistration = FileWork.ReturnFileName(personCreateVM.PopulationRegistration, "HR", hostEnvironment);
            newPerson.HealthReport = FileWork.ReturnFileName(personCreateVM.HealthReport, "HR", hostEnvironment);
            newPerson.ProfilePicture = FileWork.ReturnFileName(personCreateVM.ProfilePicture, "HR", hostEnvironment);
            newPerson.IsApproved = false;
            personService.Insert(newPerson);
            var personSalary = new PersonSalary() { IsActive = true, Salary = personCreateVM.Salary, StartDate = DateTime.Now, PersonId = newPerson.Id };
            personSalaryService.Insert(personSalary);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult PersonUpdate(PersonDetailViewModel vm)
        {
            var person = personService.GetById(vm.Person.Id);
            if (vm.PersonCreateVM != null)
            {
                if (vm.PersonCreateVM.IdCard != null)
                {
                    person.IdCard = FileWork.ReturnFileName(vm.PersonCreateVM.IdCard, "HR", hostEnvironment);
                }

                if (vm.PersonCreateVM.PlaceOfResidence != null)
                {
                    person.PlaceOfResidence = FileWork.ReturnFileName(vm.PersonCreateVM.PlaceOfResidence, "HR", hostEnvironment);
                }

                if (vm.PersonCreateVM.ProfilePicture != null)
                {
                    person.ProfilePicture = FileWork.ReturnFileName(vm.PersonCreateVM.ProfilePicture, "HR", hostEnvironment);
                }

                if (vm.PersonCreateVM.Diploma != null)
                {
                    person.Diploma = FileWork.ReturnFileName(vm.PersonCreateVM.Diploma, "HR", hostEnvironment);
                }

                if (vm.PersonCreateVM.CriminalRecord != null)
                {
                    person.CriminalRecord = FileWork.ReturnFileName(vm.PersonCreateVM.CriminalRecord, "HR", hostEnvironment);
                }

                if (vm.PersonCreateVM.PopulationRegistration != null)
                {
                    person.PopulationRegistration = FileWork.ReturnFileName(vm.PersonCreateVM.PopulationRegistration, "HR", hostEnvironment);
                }

                if (vm.PersonCreateVM.HealthReport != null)
                {
                    person.HealthReport = FileWork.ReturnFileName(vm.PersonCreateVM.HealthReport, "HR", hostEnvironment);
                }
                if (vm.PostType == PostType.Document)
                {
                    personService.Update(person);
                }

            }
            if (vm.PostType != PostType.Document)
            {
                person = vm.Person;
                personService.Update(person);

            }

            return RedirectToAction("PersonelDetail", new { id = vm.Person.Id });
        }
        [HttpPost]
        public IActionResult UpdateSalary(PersonDetailViewModel vm)
        {
            var oldSalary = personSalaryService.GetBySalary(vm.Person.Id);
            oldSalary.IsActive = false;
            oldSalary.FinishDate = DateTime.Now.AddDays(-1);
            personSalaryService.Update(oldSalary);
            PersonSalary personSalary = new PersonSalary();
            personSalary.Salary = vm.PersonSalary.Salary;
            personSalary.StartDate = vm.PersonSalary.StartDate;
            personSalary.IsActive = true;
            personSalary.PersonId = vm.Person.Id;
            personSalaryService.Insert(personSalary);
            return RedirectToAction("PersonelDetail", new { id = vm.Person.Id });
        }
        [HttpPost]
        public IActionResult DeleteSalary(int salaryId)
        {
            try
            {
                var salaryToDelete = personSalaryService.GetByDeleteSalary(salaryId);

                if (salaryToDelete != null)
                {
                    personSalaryService.Delete(salaryId);

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddPersonBonus(PersonDetailViewModel vm)
        {
            PersonBonus bonus = new PersonBonus();
            bonus.BonusAmount = vm.PersonBonus.BonusAmount;
            bonus.DateOfIssue = vm.PersonBonus.DateOfIssue;
            bonus.PersonId = vm.Person.Id;
            bonus.Description = vm.PersonBonus.Description;
            //var result = mapper.Map(vm, new PersonBonus());
            personBonusService.Insert(bonus);
            return RedirectToAction("PersonelDetail", new { id = vm.Person.Id });
        }
        [HttpPost]
        public IActionResult UpdatePersonBonus([FromBody] List<int> selectedBonuses)
        {
            try
            {
                foreach (var bonusId in selectedBonuses)
                {
                    var bonus = personBonusService.GetById(bonusId);
                    bonus.IsOkey = true;
                    personBonusService.Update(bonus);
                }

                return Ok(new { success = true, message = "Bonuslar başarıyla işlendi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult AddPersonAvans(PersonDetailViewModel vm)
        {
            PersonAdvancePayment avans = new PersonAdvancePayment();
            avans.BonusAmount = vm.PersonAdvancePayment.BonusAmount;
            avans.DateOfIssue = vm.PersonAdvancePayment.DateOfIssue;
            avans.PersonId = vm.Person.Id;
            avans.Description = vm.PersonAdvancePayment.Description;
            //var result = mapper.Map(vm, new PersonBonus());
            personAdvancePaymentService.Insert(avans);
            return RedirectToAction("PersonelDetail", new { id = vm.Person.Id });
        }
        [HttpPost]
        public IActionResult UpdatePersonAvans([FromBody] List<int> selectedAvans)
        {
            try
            {
                foreach (var avansId in selectedAvans)
                {
                    var avans = personAdvancePaymentService.GetById(avansId);
                    avans.IsOkey = true;
                    personAdvancePaymentService.Update(avans);
                }

                return Ok(new { success = true, message = "Avanslar başarıyla işlendi." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult CreatePermission(PersonDetailViewModel vm)
        {
            PersonPermission permission = mapper.Map<PersonPermission>(vm.PersonPermission);
            try
            {
                permission.File = FileWork.ReturnFileName(vm.PersonPermissionFile, "PersonPermission", hostEnvironment);
                personPermissionService.Insert(permission);

                return RedirectToAction("PersonelDetail", new { id = vm.PersonPermission.PersonId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult RemovePerson(PersonDetailViewModel vm)
        {
            PersonIstenCikar istenCikar = mapper.Map<PersonIstenCikar>(vm.PersonIstenCikar);
            istenCikar.File = FileWork.ReturnFileName(vm.IstenCikisDosya, "HR", hostEnvironment);
            try
            {
                personIstenCikarService.Insert(istenCikar);
                var person = personService.GetById(istenCikar.PersonId);
                person.IsActiveWorker = false;
                personService.Update(person);

                return RedirectToAction("PersonelDetail", new { id = vm.PersonIstenCikar.PersonId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult CreatePermissionType()
        {
            var existingPermissionTypes = personPermissionTypeService.GetAll();

            var viewModel = new PermissionViewModel
            {
                ExistingPermissionTypes = existingPermissionTypes,
                NewPermissionType = new PersonPermissionType()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddNewPermissionType(PermissionViewModel viewModel)
        {
            personPermissionTypeService.Insert(viewModel.NewPermissionType);

            return RedirectToAction("CreatePermissionType");

        }
        [HttpPost]
        public IActionResult AddPersonAnnualLeave(PersonDetailViewModel viewModel)
        {
            var result = mapper.Map<PersonAnnualLeave>(viewModel.PersonAnnualLeave);
            personAnnualLeaveService.Insert(result);
            return RedirectToAction("PersonelDetail", new { id = result.PersonId });

        }
        [HttpGet]
        public IActionResult CreatePersonWorkPlace()
        {
            var result = workPlaceService.GetAll();
            return View(result);
        }
        [HttpPost]
        public IActionResult AddPersonWorkPlace(Workplace workplace)
        {
            workPlaceService.Insert(workplace);
            return RedirectToAction("CreatePerson");

        }

        [HttpPost]
        public IActionResult EditPersonWorkPlace(Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                workPlaceService.Update(workplace);
                return Json("İşlem Başarıyla Tamamlandı");
            }
            return Json("İşlem Sırasında Hata");
        }
        public IActionResult DeletePersonWorkPlaceConfirmed(int id)
        {
            workPlaceService.Delete(id);
            return Json("İşlem Başarıyla Tamamlandı");
        }
        [HttpGet]
        public IActionResult CreatePersonPosition()
        {
            var result = personPositionService.GetAll();
            return View(result);
        }
        [HttpPost]
        public IActionResult AddPersonPosition(PersonPosition personPosition)
        {
            personPosition.Code = personPositionService.CreatePositionCode(personPosition);
            personPositionService.Insert(personPosition);
            return RedirectToAction("CreatePerson");

        }

        [HttpGet]
        public IActionResult TallyDetailIndex()
        {
            var result = workPlaceService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult GetPersonByWorkPlace(int id, DateTime tarih)
        {
            if (tarih == DateTime.MinValue)
            {
                tarih = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else
            {
                tarih = new DateTime(tarih.Year, tarih.Month, 1);
            }
            ViewBag.Id = id;
            TallyDetailViewModel vm = new TallyDetailViewModel();
            vm.Persons = personService.Where(x => x.WorkplaceId == id);
            if (vm.Persons.Count() == 0)
                return BadRequest("Bu çalışma yerinde personel bulunmuyor.");
            // İçinde bulunduğumuz ayın gün sayısı
            int numberOfDaysInMonth = DateTime.DaysInMonth(tarih.Year, tarih.Month);

            // İçinde bulunduğumuz ayın günlerini oluşturup listeye ekle
            vm.DateTimes = Enumerable.Range(0, numberOfDaysInMonth)
                                  .Select(day => tarih.AddDays(day))
                                  .ToList();

            vm.TallyDetails = tallyDetailService.GetAll();

            return View(vm);
        }



        [HttpGet]
        public IActionResult PaymentList(int id, DateTime tarih)
        {
            if (tarih == DateTime.MinValue)
            {
                tarih = DateTime.Now;
            }
            ViewBag.Id = id;
            ViewBag.Tarih = tarih;
            var persons = personService.GetPersonInclude().Where(x => x.WorkplaceId == id).ToList();
            var avans = personAdvancePaymentService.Where(x => x.DateOfIssue.Month == tarih.Month && x.DateOfIssue.Year == tarih.Year).ToList();
            var personsIds = personService.GetAll().ToList().Select(x => x.Id).ToList();
            var tailys = tallyDetailService.GetTailiesByMounth(tarih, personsIds);
            var prims = personBonusService.Where(x => x.DateOfIssue.Month == tarih.Month &&
                                                        x.DateOfIssue.Year == tarih.Year &&
                                                        personsIds.Contains(x.PersonId)).ToList();

            ViewBag.TallyDetails = tailys;
            ViewBag.PersonBonus = prims;
            ViewBag.Avans = avans;
            return View(persons);
        }

        [HttpGet]
        public IActionResult AllPaymentsList(DateTime tarih)
        {
            if (tarih == DateTime.MinValue)
            {
                tarih = DateTime.Now;
            }

            ViewBag.Tarih = tarih;

            // Fetch all persons
            var persons = personService.GetPersonInclude().ToList();

            var avans = personAdvancePaymentService
                .Where(x => x.DateOfIssue.Month == tarih.Month && x.DateOfIssue.Year == tarih.Year)
                .ToList();

            var personsIds = persons.Select(x => x.Id).ToList();

            var tailys = tallyDetailService.GetTailiesByMounth(tarih, personsIds);
            var prims = personBonusService
                .Where(x => x.DateOfIssue.Month == tarih.Month && x.DateOfIssue.Year == tarih.Year && personsIds.Contains(x.PersonId))
                .ToList();

            ViewBag.TallyDetails = tailys;
            ViewBag.PersonBonus = prims;
            ViewBag.Avans = avans;

            return View("AllPaymentList", persons);
        }



        [HttpGet]
        public IActionResult AllPersonels()
        {
            return View();
        }

        public async Task<IActionResult> AllPersonelsWithFilter(string personelName, string tcNo, int? positionId, int? workplaceId, string phoneNumber, string IBAN, int? workingTime, int page = 1, int pageSize = 10)
        {
            // Get the complete list of persons (no server-side filtering or sorting)
            var filteredEntries = personService.GetPersonList(personelName, tcNo, positionId, workplaceId, phoneNumber, IBAN, workingTime) ?? new List<Person>();

            var viewModel = new List<PersonListViewModel>();

            foreach (var p in filteredEntries)
            {
                var approvedByUser = await userManager.FindByIdAsync(p.ApprovedById);
                var approvedByName = approvedByUser != null ? $"{approvedByUser.Name} {approvedByUser.SurName}" : "Bekliyor";

                var personViewModel = new PersonListViewModel
                {
                    Id = p.Id,
                    IsActiveWorker = p.IsActiveWorker,
                    TcNo = p.TcNo,
                    Name = p.Name,
                    Surname = p.Surname,
                    Position = p.PersonPosition.Name,
                    Workplace = p.Workplace.Name,
                    PhoneNumber = p.PhoneNumber,
                    WorkingTime = p.WorkingTime,
                    ProfilePicture = p.ProfilePicture,
                    IsApproved = p.IsApproved,
                    ApprovedBy = approvedByName,
                    ApprovalDate = p.ApprovalDate,
                    IBAN = p.IBAN,
                    Salary = personSalaryService.GetPersonSalaries(p.Id)
                                .Where(s => s.IsActive)
                                .OrderByDescending(s => s.StartDate)
                                .Select(s => s.Salary)
                                .FirstOrDefault()
                };

                viewModel.Add(personViewModel);
            }

            // Pass data to the view without pagination
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ApprovePerson(string personelName, string tcNo, int? positionId, int? workplaceId, string phoneNumber, string IBAN, int? workingTime, int page = 1, int pageSize = 10)
        {
            // Get the list of pending persons (IsApproved = false)
            var pendingPersons = personService.GetPersonList(personelName, tcNo, positionId, workplaceId, phoneNumber, IBAN, workingTime)
                                ?.Where(p => !p.IsApproved) // Only select unapproved persons
                                .ToList() ?? new List<Person>();
            var viewModel = pendingPersons.Select(p => new PersonListViewModel
            {
                Id = p.Id,
                IsActiveWorker = p.IsActiveWorker,
                TcNo = p.TcNo,
                Name = p.Name,
                Surname = p.Surname,
                Position = p.PersonPosition.Name,
                Workplace = p.Workplace.Name,
                PhoneNumber = p.PhoneNumber,
                WorkingTime = p.WorkingTime,
                ProfilePicture = p.ProfilePicture,
                IsApproved = p.IsApproved,
                IBAN = p.IBAN,
                Salary = personSalaryService.GetPersonSalaries(p.Id)
                            .Where(s => s.IsActive)
                            .OrderByDescending(s => s.StartDate)
                            .Select(s => s.Salary)
                            .FirstOrDefault()
            }).ToList();

            // Pass data to the view without pagination
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult ApprovePerson(int personId)
        {
            // Kişiyi veritabanından al
            var person = personService.GetPersonInclude(personId);
            if (person == null)
            {
                return NotFound();
            }

            // Şu anki kullanıcıyı al (onaylayan kişi)
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Onay işlemi
            person.IsApproved = true;
            person.ApprovedById = currentUserId; // Onayı yapan kullanıcı ID'si
            person.ApprovalDate = DateTime.Now;  // Onay tarihi

            // Veritabanında güncelle
            personService.Update(person);

            // Onaylanmamış kişilerin listesine geri dön
            return RedirectToAction("ApprovePerson");
        }


        [HttpGet]
        public IActionResult UploadExcelPerson(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                return BadRequest("Excel dosyası yüklenmedi.");
            }


            using (var stream = new MemoryStream())
            {
                excelFile.CopyTo(stream);
                stream.Position = 0;

                IWorkbook workbook = new XSSFWorkbook(stream);
                ISheet sheet = workbook.GetSheetAt(0); // İlk sayfayı alır
                string sheetName = sheet.SheetName; // Sayfa adını alır
                var calismaYer = workPlaceService.Where(x => x.Name == sheetName).FirstOrDefault();
                if (calismaYer == null)
                {
                    return Json("İşlemde Hata");
                }
                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++) // 0 indeksli olan başlık satırını atla
                {
                    IRow row = sheet.GetRow(rowIndex);
                    if (row == null) continue;


                    string Tc = row.GetCell(2)?.ToString();
                    string FullName = row.GetCell(3)?.ToString();
                    string Position = row.GetCell(4)?.ToString();
                    DateTime EntryDate = DateTime.Parse(row.GetCell(5)?.ToString());
                    decimal Salary = decimal.Parse(row.GetCell(7)?.ToString());
                    Person person = new Person();
                    person.TcNo = Tc;
                    person.Name = FullName;
                    person.Surname = FullName;
                    person.WorkplaceId = calismaYer.Id;
                    person.PersonPositionId = calismaYer.Id;
                    person.Birthdate = EntryDate;
                    person.EntryDate = EntryDate;
                    person.IdCard = " ";
                    person.PlaceOfResidence = " ";
                    person.Diploma = " ";
                    person.CriminalRecord = " ";
                    person.PopulationRegistration = " ";
                    person.HealthReport = " ";
                    person.PhoneNumber = " ";
                    personService.Insert(person);
                    PersonSalary personSalary = new PersonSalary();
                    personSalary.StartDate = new DateTime(2024, 6, 1);
                    personSalary.IsActive = true;
                    personSalary.PersonId = person.Id;
                    personSalaryService.Insert(personSalary);


                }
            }


            return Ok("person");
        }
        public static (string FirstName, string LastName) SplitFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return (string.Empty, string.Empty);
            }

            string[] nameParts = fullName.Trim().Split(' ');

            if (nameParts.Length == 1)
            {
                return (nameParts[0], string.Empty);
            }

            string firstName = nameParts[0];
            string lastName = string.Join(" ", nameParts.Skip(1));

            return (firstName, lastName);
        }
        [HttpPost]
        public ActionResult SaveTallyDetail([FromBody] List<TallyDetail> dataArray)
        {
            try
            {
                // Veriyi işleme işlemleri burada gerçekleştirilir
                foreach (var data in dataArray)
                {
                    if (data.Id != 0)
                    {
                        TallyDetail entity = tallyDetailService.GetById(data.Id);
                        entity.WorkTime = data.WorkTime;
                        tallyDetailService.Update(entity);
                    }
                    else
                    {
                        TallyDetail entity = new TallyDetail();
                        entity.PersonId = data.PersonId;
                        entity.DayOfWork = data.DayOfWork;
                        entity.WorkTime = data.WorkTime;
                        tallyDetailService.Insert(entity);
                    }

                }

                // Veritabanı işlemleri başarılı olduysa
                return Json(new { success = true, message = "Veri başarıyla kaydedildi." });
            }
            catch (Exception ex)
            {
                // Hata durumunda
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

    }

}
