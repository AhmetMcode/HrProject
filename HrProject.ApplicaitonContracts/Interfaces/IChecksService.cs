using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IChecksService : IBaseRepository<Checks>
    {
        public IEnumerable<Checks> GetIncludeChecks();
        void UpdateStatus(bool inMoney, int checkId);
        public void UpdateCirolaStatus(int checkId);
    }
}
