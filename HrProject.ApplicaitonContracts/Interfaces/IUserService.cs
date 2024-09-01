using HrProject.Domain.Entities;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<ApplicationUser>> GetOfferUsers();
        public Task<IEnumerable<ApplicationUser>> GetOfferProjectUsers();
        public Task<IEnumerable<ApplicationUser>> GetProjectYoneticiUsers();
        public Task<IEnumerable<ApplicationUser>> GetUsersWhere(string Role);
        public Task<IEnumerable<ApplicationUser>> GetAllUsers();
        public Task<IEnumerable<ApplicationUser>> GetKaliteUsers();

        public Task UpdateUser(ApplicationUser user);
        public Task<ApplicationUser> GetById(string id);
    }
}
