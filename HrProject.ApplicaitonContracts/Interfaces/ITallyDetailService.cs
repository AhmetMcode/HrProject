using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces;

public interface ITallyDetailService : IBaseRepository<TallyDetail>
{
    public List<TallyDetail> GetTailiesByMounth(DateTime tarih, List<int> personIds);
    public void AddAlperenUretim(AlperenUretim alperenUretim);
    public List<AlperenUretim> GetAlperenUretim();
}
