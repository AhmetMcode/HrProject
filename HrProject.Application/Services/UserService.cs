using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;

namespace HrProject.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            try
            {

                var user = context.ApplicationUsers.Where(x => x.Id == id).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetOfferUsers()
        {

            var teklifCalisanUsers = await userManager.GetUsersInRoleAsync("Teklif Calisan");
            return teklifCalisanUsers;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            var users = await context.ApplicationUsers.ToListAsync();
            return users;
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }



        public async Task<IEnumerable<ApplicationUser>> GetProjectYoneticiUsers()
        {
            var teklifCalisanUsers = await userManager.GetUsersInRoleAsync("Proje Yonetici");
            return teklifCalisanUsers;
        }

        public async Task<IEnumerable<ApplicationUser>> GetOfferProjectUsers()
        {
            var teklifCalisanUsers = await userManager.GetUsersInRoleAsync("Teklif Proje");
            return teklifCalisanUsers;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersWhere(string Role)
        {
            var teklifCalisanUsers = await userManager.GetUsersInRoleAsync(Role);
            return teklifCalisanUsers;
        }

        public async Task<IEnumerable<ApplicationUser>> GetKaliteUsers()
        {
            var kaliteAdminUsers = await userManager.GetUsersInRoleAsync(RolsApp.Role_Kalite_Admin);
            var kaliteSefUsers = await userManager.GetUsersInRoleAsync(RolsApp.Role_Kalite_Sef);

            var combinedUsers = kaliteAdminUsers.Concat(kaliteSefUsers).Distinct();
            return combinedUsers;
        }

    }
}
