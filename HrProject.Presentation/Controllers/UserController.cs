using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Application.Services;
using HrProject.Domain.Entities;
using HrProject.Presentation.Models;
using HrProject.Presentation.ViewModels;
using System.Security.Claims;

namespace HrProject.Presentation.Controllers;

public class UserController : Controller
{
    private readonly IUserService userService;
    private readonly IMapper mapper;
    private readonly IWebHostEnvironment hostEnvironment;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IWorkPlaceService workPlaceService;
    

    private readonly ILogsKayitService logsKayitService;
    private readonly IUserEmailService userEmailSetService;

    public UserController(IUserService userService, IMapper mapper, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IWorkPlaceService workPlaceService, ILogsKayitService logsKayitService, IUserEmailService userEmailSetService)
    {
        this.userService = userService;
        this.mapper = mapper;
        this.hostEnvironment = hostEnvironment;
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.workPlaceService = workPlaceService;
        this.logsKayitService = logsKayitService;
        this.userEmailSetService = userEmailSetService;
    }
    [HttpGet]
    public async Task<IActionResult> AllUsers()
    {
        var users = await userManager.Users.ToListAsync();
        var userViewModels = new List<UserViewModel>();
        foreach (var user in users)
        {
            var sonGiris = logsKayitService.SonGiris(user.Id);
            userViewModels.Add(new UserViewModel
            {
                Id = user.Id,
                user = user,
                Name = user.Name,
                SurName = user.SurName,
                UserName = user.UserName,
                ProfilPhoto = user.ProfilPhoto,
                SonGirisTarihi = sonGiris?.GerceklesmeZamani
            });
        }
        return View(userViewModels);
    }
    [HttpGet]
    public async Task<IActionResult> GetUserEmailSettings(string userId)
    {
        var userEmail = userEmailSetService.Where(x => x.ApplicationUserId == userId).FirstOrDefault();
        if (userEmail == null)
        {
            return Json(null);
        }
        return Json(userEmail);
    }
    [HttpPost]
    public IActionResult SaveUserEmailSettings(UserEmail userEmail)
    {
        var existingUserEmail = userEmailSetService.Where(x => x.ApplicationUserId == userEmail.ApplicationUserId).FirstOrDefault();

        if (existingUserEmail != null)
        {
            existingUserEmail.host = userEmail.host;
            existingUserEmail.Baslik = userEmail.Baslik;
            existingUserEmail.gondermeport = userEmail.gondermeport;
            existingUserEmail.almaport = userEmail.almaport;

            userEmailSetService.Update(existingUserEmail);
        }
        else
        {
            userEmailSetService.Insert(userEmail);
        }


        return Json(new { success = true });
    }
    [HttpGet]
    public async Task<IActionResult> UserDetail(string id)
    {
        var roles = roleManager.Roles.ToList();
        var user = await userManager.FindByIdAsync(id);
        var calismaYerleriHr = workPlaceService.GetAll().ToList();
        var myUretimYerleriDizi = FileWork.StringToIntArray(user.ResponsibleWareHouseFabrica).ToList();
        var myCalismaYerleriDizi = FileWork.StringToIntArray(user.ResponsibleHrLocation).ToList();
        var myCalismaYerleriHr = calismaYerleriHr.Where(x => myCalismaYerleriDizi.Contains(x.Id)).ToList();
        var myRoles = await userManager.GetRolesAsync(user); // Kullanıcının rollerini al
        ViewBag.AllRoles = roles;
        ViewBag.MyRoles = myRoles;
        ViewBag.User = user;
        ViewBag.TumCalismaYerleri = calismaYerleriHr;
        ViewBag.MyCalismaYerleri = myCalismaYerleriHr;

        return View();
    }
    [HttpPost]

    public async Task<IActionResult> AddProductionPlace(string userId, int workPlaceId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("Kullanıcı kimliği geçersiz.");
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"ID'si '{userId}' olan kullanıcı bulunamadı.");
        }

        if (workPlaceId <= 0)
        {
            return BadRequest("Çalışma yeri kimliği geçersiz.");
        }

        // Kullanıcının çalışma yerlerini işleme al
        if (string.IsNullOrEmpty(user.ResponsibleHrLocation))
        {
            user.ResponsibleWareHouseFabrica = workPlaceId.ToString();
        }
        else
        {
            // Kullanıcının mevcut çalışma yerlerini string dizisine dönüştür
            var myCalismaYerleriDizi = FileWork.StringToIntArray(user.ResponsibleWareHouseFabrica).ToList();

            // Yeni çalışma yeri kimliğini diziye ekle (eğer zaten ekli değilse)
            if (!myCalismaYerleriDizi.Contains(workPlaceId))
            {
                myCalismaYerleriDizi.Add(workPlaceId);
                user.ResponsibleWareHouseFabrica = FileWork.IntArrayToString(myCalismaYerleriDizi.ToArray());
            }
        }

        // Kullanıcı bilgilerini güncelle
        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return Ok("Çalışma yeri başarıyla güncellendi.");
        }
        else
        {
            return StatusCode(500, "Kullanıcı bilgileri güncellenirken bir hata oluştu.");
        }
    }
    [HttpPost]

    public async Task<IActionResult> RemoveProductionPlace(string userId, int workPlaceId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("Kullanıcı kimliği geçersiz.");
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"ID'si '{userId}' olan kullanıcı bulunamadı.");
        }

        if (workPlaceId <= 0)
        {
            return BadRequest("Çalışma yeri kimliği geçersiz.");
        }

        // Kullanıcının çalışma yerlerini işleme al
        if (string.IsNullOrEmpty(user.ResponsibleWareHouseFabrica))
        {
            // Kullanıcının mevcut bir çalışma yeri yoksa, herhangi bir işlem yapmaya gerek yoktur
            return Ok("Kullanıcının mevcut bir çalışma yeri yok.");
        }
        else
        {
            // Kullanıcının mevcut çalışma yerlerini string dizisine dönüştür
            var myCalismaYerleriDizi = FileWork.StringToIntArray(user.ResponsibleWareHouseFabrica).ToList();

            // Çalışma yeri kimliğini dizi içerisinde ara ve kaldır
            if (myCalismaYerleriDizi.Contains(workPlaceId))
            {
                myCalismaYerleriDizi.Remove(workPlaceId);
                user.ResponsibleWareHouseFabrica = FileWork.IntArrayToString(myCalismaYerleriDizi.ToArray());
            }
            else
            {
                return Ok("Kullanıcıya atanmış böyle bir çalışma yeri yok.");
            }
        }

        // Kullanıcı bilgilerini güncelle
        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return Ok("Çalışma yeri başarıyla kaldırıldı.");
        }
        else
        {
            return StatusCode(500, "Kullanıcı bilgileri güncellenirken bir hata oluştu.");
        }
    }
    [HttpPost]

    public async Task<IActionResult> AddWorkPlace(string userId, int workPlaceId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("Kullanıcı kimliği geçersiz.");
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"ID'si '{userId}' olan kullanıcı bulunamadı.");
        }

        if (workPlaceId <= 0)
        {
            return BadRequest("Çalışma yeri kimliği geçersiz.");
        }

        // Kullanıcının çalışma yerlerini işleme al
        if (string.IsNullOrEmpty(user.ResponsibleHrLocation))
        {
            user.ResponsibleHrLocation = workPlaceId.ToString();
        }
        else
        {
            // Kullanıcının mevcut çalışma yerlerini string dizisine dönüştür
            var myCalismaYerleriDizi = FileWork.StringToIntArray(user.ResponsibleHrLocation).ToList();

            // Yeni çalışma yeri kimliğini diziye ekle (eğer zaten ekli değilse)
            if (!myCalismaYerleriDizi.Contains(workPlaceId))
            {
                myCalismaYerleriDizi.Add(workPlaceId);
                user.ResponsibleHrLocation = FileWork.IntArrayToString(myCalismaYerleriDizi.ToArray());
            }
        }

        // Kullanıcı bilgilerini güncelle
        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return Ok("Çalışma yeri başarıyla güncellendi.");
        }
        else
        {
            return StatusCode(500, "Kullanıcı bilgileri güncellenirken bir hata oluştu.");
        }
    }
    [HttpPost]

    public async Task<IActionResult> RemoveWorkPlace(string userId, int workPlaceId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("Kullanıcı kimliği geçersiz.");
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound($"ID'si '{userId}' olan kullanıcı bulunamadı.");
        }

        if (workPlaceId <= 0)
        {
            return BadRequest("Çalışma yeri kimliği geçersiz.");
        }

        // Kullanıcının çalışma yerlerini işleme al
        if (string.IsNullOrEmpty(user.ResponsibleHrLocation))
        {
            // Kullanıcının mevcut bir çalışma yeri yoksa, herhangi bir işlem yapmaya gerek yoktur
            return Ok("Kullanıcının mevcut bir çalışma yeri yok.");
        }
        else
        {
            // Kullanıcının mevcut çalışma yerlerini string dizisine dönüştür
            var myCalismaYerleriDizi = FileWork.StringToIntArray(user.ResponsibleHrLocation).ToList();

            // Çalışma yeri kimliğini dizi içerisinde ara ve kaldır
            if (myCalismaYerleriDizi.Contains(workPlaceId))
            {
                myCalismaYerleriDizi.Remove(workPlaceId);
                user.ResponsibleHrLocation = FileWork.IntArrayToString(myCalismaYerleriDizi.ToArray());
            }
            else
            {
                return Ok("Kullanıcıya atanmış böyle bir çalışma yeri yok.");
            }
        }

        // Kullanıcı bilgilerini güncelle
        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return Ok("Çalışma yeri başarıyla kaldırıldı.");
        }
        else
        {
            return StatusCode(500, "Kullanıcı bilgileri güncellenirken bir hata oluştu.");
        }
    }

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await userService.GetById(userId);
        var userUpdateViewModel = mapper.Map<UserUpdateViewModel>(user);
        ViewBag.ChangePassword = false;
        return View(userUpdateViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(string userId, string roleId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }

        var role = await roleManager.FindByIdAsync(roleId);
        if (role == null)
        {
            return NotFound("Rol bulunamadı.");
        }

        var result = await userManager.AddToRoleAsync(user, role.Name);
        if (result.Succeeded)
        {
            return Ok("Rol başarıyla eklendi.");
        }
        else
        {
            return BadRequest("Rol eklenirken bir hata oluştu.");
        }
    }
    [HttpPost]

    public async Task<IActionResult> RemoveRole(string userId, string roleId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }

        var role = await roleManager.FindByIdAsync(roleId);
        if (role == null)
        {
            return NotFound("Rol bulunamadı.");
        }

        if (!await userManager.IsInRoleAsync(user, role.Name))
        {
            return BadRequest("Kullanıcı bu role sahip değil.");
        }

        var userRoles = await userManager.GetRolesAsync(user);
        if (userRoles.Count == 1 && userRoles.Contains(role.Name))
        {
            return BadRequest("Kullanıcının tek rolü var ve bu rol kaldırılamaz.");
        }

        var result = await userManager.RemoveFromRoleAsync(user, role.Name);
        if (result.Succeeded)
        {
            return Ok("Rol başarıyla kaldırıldı.");
        }
        else
        {
            return BadRequest("Rol kaldırılırken bir hata oluştu.");
        }
    }


    public async Task<IActionResult> List()
    {
        var usersWithRoles = userManager.Users.Select(user => new UserWithRolesViewModel
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
        }).ToList();

        return View(usersWithRoles);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user != null)
        {

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                // Başarıyla silindiğinde yapılacak işlemler
                // Örneğin, bir bildirim veya loglama yapılabilir.
            }
            else
            {
                // Silme işlemi başarısız olduğunda yapılacak işlemler
                // Hata mesajları alınabilir veya işlemin neden başarısız olduğu ile ilgili bilgiler tutulabilir.
            }
        }

        // Kullanıcıları listeleme sayfasına geri yönlendir
        return RedirectToAction("AllUsers");
    }



    public async Task<IActionResult> GetOfferUsersJson()
    {
        var usersTask = userService.GetOfferUsers();
        var users = await usersTask;
        if (users != null)
        {
            return Json(users.ToList());
        }
        else
        {
            return BadRequest("Kullanıcılar alınamadı.");
        }
    }
    public async Task<IActionResult> GetOfferProjectUsersJson()
    {
        var usersTask = userService.GetOfferProjectUsers();
        var users = await usersTask;
        if (users != null)
        {
            return Json(users.ToList());
        }
        else
        {
            return BadRequest("Kullanıcılar alınamadı.");
        }
    }
    public async Task<IActionResult> GetProjectUsersJson()
    {
        var usersTask = userService.GetUsersWhere(Roller.Role_Proje_Calisan);
        var users = await usersTask;
        return Json(users);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateUser(UserUpdateViewModel updatedUser)
    {
        string file = "";
        var user = await userService.GetById(updatedUser.Id);
        var user2 = await userService.GetById(updatedUser.Id);
        mapper.Map(updatedUser, user);
        if (updatedUser.Photo != null)
        {
            file = FileWork.ReturnFileName(updatedUser.Photo, "ProfilPhoto", hostEnvironment);
            user.ProfilPhoto = file;
        }
        else
        {
            user.ProfilPhoto = user2.ProfilPhoto;
        }

        await userService.UpdateUser(user);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ChangePassword(string currentPassword, string newpassword, string renewPassword)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user2 = await userService.GetById(userId);
        var userUpdateViewModel = mapper.Map<UserUpdateViewModel>(user2);

        if (newpassword != renewPassword)
        {
            // Yeni şifre ile şifre tekrarı eşleşmiyorsa hata döndür.
            ModelState.AddModelError(string.Empty, "Yeni şifre ve şifre tekrarı eşleşmiyor.");
            return View("Index", userUpdateViewModel);
        }

        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }

        // Mevcut şifreyi değiştirmek için ChangePasswordAsync metodunu kullan.
        var changePasswordResult = await userManager.ChangePasswordAsync(user, currentPassword, newpassword);
        if (!changePasswordResult.Succeeded)
        {
            // Şifre değiştirme işlemi başarısız oldu.
            foreach (var error in changePasswordResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            ViewBag.ChangePassword = false;
            return View("Index", userUpdateViewModel);
        }

        ViewBag.ChangePassword = true;

        // Şifre değiştirme işlemi başarılı oldu.
        return View("Index", userUpdateViewModel);
    }
}
