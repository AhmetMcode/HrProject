using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ILabaratuarSonucService : IBaseRepository<LabaratuarSonuc>
    {
        public List<ProductPlanDailyPlanned> GetDailyPlanneds();
        public LabaratuarSonuc EkleVeyaGetir(int dailyId);
    }
}
