using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IFileProjeModulService : IBaseRepository<FileProjeModul>
    {
        List<FileProjeModul> GetFileOnylNameByProjeId(int id);
        List<FileProjeModul> DosyalariGetirProjeElemanaGore(int id, int projeElemanId);
    }
}
