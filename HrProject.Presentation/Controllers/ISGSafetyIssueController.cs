using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Application.Services;
using HrProject.Domain.Entities;
using HrProject.Presentation.Models;
using HrProject.Presentation.ViewModels;
using System.Text.Json;

namespace HrProject.Presentation.Controllers
{
    [Authorize]
    public class ISGSafetyIssueController : Controller
    {
        private readonly ISafetyIssueService _safetyIssueService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IPersonService _personService;

        public ISGSafetyIssueController(ISafetyIssueService safetyIssueService, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment, IPersonService personService)
        {
            _safetyIssueService = safetyIssueService;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var issues = await _safetyIssueService.GetAllIssuesAsync();

            // Kullanıcı ID'lerini listeleyin ve isimlerini bulun
            var userIds = issues.Select(i => i.ReportedById).Distinct().ToList();
            var users = new Dictionary<string, string>();

            foreach (var userId in userIds)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    users.Add(userId, $"{user.Name} {user.SurName}");
                }
            }

            // Person ID'lerini listeleyin ve isimlerini bulun
            var personIds = issues.Where(i => i.PersonId.HasValue).Select(i => i.PersonId.Value).Distinct().ToList();
            var persons = new Dictionary<int, string>();

            foreach (var personId in personIds)
            {
                var person = await _personService.GetPersonByIdAsync(personId);
                // PersonManager kullanarak person bilgilerini alıyoruz
                if (person != null)
                {
                    persons.Add(personId, $"{person.Name} {person.Surname}");
                }
            }

            ViewBag.Persons = persons;
            ViewBag.Users = users;

            var viewModel = new ISGSafetyIssueViewModel
            {
                Issues = issues.ToList()
            };

            return View(viewModel);
        }




        public async Task<IActionResult> Create()
        {
            var categories = await _safetyIssueService.GetAllCategoriesAsync();
            var subCategories = await _safetyIssueService.GetAllSubCategoriesAsync();
            var persons = await _safetyIssueService.GetAllPersonsAsync(); // Assuming you have a service for persons

            var viewModel = new ISGSafetyIssueViewModel
            {
                Persons = persons.ToList()
            };

            ViewBag.Categories = categories;
            ViewBag.SubCategoriesJson = JsonSerializer.Serialize(subCategories);

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ISGSafetyIssueViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reportedByUser = await _userManager.FindByIdAsync(model.ReportedById);

                if (reportedByUser == null)
                {
                    // If the user does not exist, do not attempt to create a new user
                    return BadRequest("Kullanıcı bulunamadı.");
                }

                var issue = new ISGSafetyIssue
                {
                    PersonId = model.PersonId,
                    Description = model.Description,
                    ReportDate = DateTime.Now,
                    ReportedById = model.ReportedById,
                    CategoryId = model.CategoryId,
                    SubCategoryId = model.SubCategoryId,
                    Images = new List<ISGSafetyIssueImages>()
                };

                // Process and save each image
                if (model.Images != null && model.Images.Count > 0)
                {
                    foreach (var img in model.Images)
                    {
                        if (img.Length > 0)
                        {
                            // Save the file to the server and return the file name
                            var imagePath = FileWork.ReturnFileName(img, "SafetyIssueImages", _hostEnvironment);
                            var issueImage = new ISGSafetyIssueImages
                            {
                                ImagePath = imagePath,
                                ISGSafetyIssue = issue // Associate the image with the issue
                            };

                            issue.Images.Add(issueImage);

                            // Save the image file
                            var fileSavePath = Path.Combine(_hostEnvironment.WebRootPath, "SafetyIssueImages", imagePath);
                            using (var stream = new FileStream(fileSavePath, FileMode.Create))
                            {
                                await img.CopyToAsync(stream);
                            }
                        }
                    }
                }

                await _safetyIssueService.AddIssueAsync(issue);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var issue = await _safetyIssueService.GetIssueByIdAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            var persons = await _personService.GetAllPersonsAsync();
            var categories = await _safetyIssueService.GetAllCategoriesAsync();
            var subCategories = await _safetyIssueService.GetAllSubCategoriesAsync();

            var viewModel = new ISGSafetyIssueViewModel
            {
                Id = issue.Id,
                Description = issue.Description,
                ReportDate = issue.ReportDate,
                ReportedById = issue.ReportedById,
                PersonId = issue.PersonId,
                CategoryId = issue.CategoryId,
                SubCategoryId = issue.SubCategoryId,
                Persons = persons.ToList(),
                ExistingImages = issue.Images?.ToList() // Mevcut resimleri ekliyoruz
            };

            ViewBag.Categories = categories;
            ViewBag.SubCategoriesJson = JsonSerializer.Serialize(subCategories);

            return View(viewModel);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(ISGSafetyIssueViewModel model)
        {
            if (ModelState.IsValid)
            {
                var issue = await _safetyIssueService.GetIssueByIdAsync(model.Id);

                if (issue == null)
                {
                    return NotFound();
                }

                if (model.Images != null && model.Images.Count > 0)
                {
                    foreach (var img in model.Images)
                    {
                        if (img.Length > 0)
                        {
                            var imagePath = FileWork.ReturnFileName(img, "SafetyIssueImages", _hostEnvironment);
                            var issueImage = new ISGSafetyIssueImages
                            {
                                ImagePath = imagePath,
                                ISGSafetyIssue = issue
                            };

                            issue.Images.Add(issueImage);

                            var fileSavePath = Path.Combine(_hostEnvironment.WebRootPath, "SafetyIssueImages", imagePath);
                            using (var stream = new FileStream(fileSavePath, FileMode.Create))
                            {
                                await img.CopyToAsync(stream);
                            }
                        }
                    }
                }

                issue.Description = model.Description;
                issue.PersonId = model.PersonId;
                issue.CategoryId = model.CategoryId;
                issue.SubCategoryId = model.SubCategoryId;

                await _safetyIssueService.UpdateIssueAsync(issue);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _safetyIssueService.DeleteIssueAsync(id);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }



        //------------CATEGORY-------------

        // Kategori işlemleri için listeleme sayfası
        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await _safetyIssueService.GetAllCategoriesAsync();
            return View(categories);
        }

        // Yeni bir kategori oluşturma sayfası
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(ISGSafetyIssueCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new ISGSafetyIssueCategory
                {
                    Name = model.Name
                };

                await _safetyIssueService.AddCategoryAsync(category);
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(ISGSafetyIssueCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = await _safetyIssueService.GetCategoryByIdAsync(model.Id);

                if (category == null)
                {
                    return NotFound();
                }

                category.Name = model.Name;
                await _safetyIssueService.UpdateCategoryAsync(category);
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false });
        }


        /// Kategori silme işlemi
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int deleteCategoryId)
        {
            try
            {
                await _safetyIssueService.DeleteCategoryAsync(deleteCategoryId);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        //---------------SUB CATEGORY----------------

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(ISGSafetyIssueSubCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = await _safetyIssueService.GetCategoryByIdAsync(model.CategoryId);
                if (category == null)
                {
                    // Hata döndür veya log ekle
                    return BadRequest("Category not found.");
                }

                var subCategory = new ISGSafetyIssueSubCategory
                {
                    Id = model.Id,
                    Name = model.Name,
                    RiskLevel = model.RiskLevel,
                    CategoryId = model.CategoryId,
                };
                await _safetyIssueService.AddSubCategoryAsync(subCategory);
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> EditSubCategory(ISGSafetyIssueSubCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var subCategory = await _safetyIssueService.GetSubCategoryByIdAsync(model.Id);

                if (subCategory == null)
                {
                    return NotFound(new { success = false, message = "Alt kategori bulunamadı." });
                }

                subCategory.Name = model.Name;
                subCategory.RiskLevel = model.RiskLevel;
                subCategory.CategoryId = model.CategoryId;

                await _safetyIssueService.UpdateSubCategoryAsync(subCategory);
                return Ok(new { success = true });
            }
            return BadRequest(new { success = false, message = "Geçersiz model verisi." });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory(int subCategoryId)
        {
            var subCategory = await _safetyIssueService.GetSubCategoryByIdAsync(subCategoryId);
            if (subCategory == null)
            {
                return NotFound(new { success = false, message = "Alt kategori bulunamadı." });
            }

            await _safetyIssueService.DeleteSubCategoryAsync(subCategory);
            return Ok(new { success = true });
        }
    }
}
