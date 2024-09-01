using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IKaliteBirimAtamaService : IBaseRepository<KaliteBirimAtama>
    {
        public KaliteBirimAtama GetUretimYeriInclude(int UretimYeriId);
        public bool AddIlkUser(KaliteBirimAtamaIlkKontrolUser kaliteBirimAtama);
        public bool AddSonUser(KaliteBirimAtamaSonKontrolUser kaliteBirimAtama);
        public bool KaliteAtamaSil(string userKontrolId, int KaliteBirimAtamaId, bool ilk);
        public List<ProductionPlace> GetUretimYerleri(string userId);
    }
}
