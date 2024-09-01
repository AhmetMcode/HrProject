using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ILogsKayitService : IBaseRepository<LogKayit>
    {
        public LogKayit SonGiris(string userId);
    }
}
