using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IQualityFormSub : IBaseRepository<QualityFormSub>
    {
        public QualityFormSub GetOrAddQualityFormSub(int stepId);
        public List<QualityFormSubAnswer> DoldurulanFormlar(string? arama, DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 10);
        public int DoldurulanFormlarTotal(string? arama, DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 10);
        public QualityFormSubAnswer DemirFormuEkle(int[] urunIdler);
        public QualityFormSubAnswer DigerFormEkle(int[] urunIdler);
        public QualityFormSubAnswer GelFormSubInclude(int id);
        public QualityFormSub GetOrAddQualityFormSubBySubId(int subId);
        public QualityFormSub GetOrAddQualityFormAnswer(int stepId);
        public QualityFormSub GetQualityForm(int Id);
        public QualityFormSubAnswer GetOrAddQualityAnswer(int productPlanId);
        public QualityFormSubAnswer GetOrAddQualityAnswerByManifactId(int manifactId);
        public QualityFormSubAnswer GetOrAddQualityAnswerByManifactIdsToplu(int[] manifactIds);
        public QualityFormSubAnswer GetOrAddQualityAnswerByManifactIdAtamayaGore(int manifactId);
        public QualityFormSubAnswer GetOrAddQualityAnswerByManifactIdsTopluAtamayaGore(int[] manifactIds);
        public Question SoruGetirId(int id);
        public Task SoruGuncelle(Question question);
        public void AddQuestion(Question question);
        public Task UpdateQualityFormSubAnswer(QualityFormSubAnswer qualityFormSubAnswer);
    }
}
