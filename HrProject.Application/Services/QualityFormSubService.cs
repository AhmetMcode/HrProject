using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using Xceed.Document.NET;

namespace HrProject.Application.Services
{
    public class QualityFormSubService : BaseRepository<QualityFormSub>, IQualityFormSub
    {
        private readonly IProductManifactDetail productManifactDetailService;

        public QualityFormSubService(DbContextOptions<ApplicationDbContext> options, IProductManifactDetail productManifactDetailService) : base(options)
        {
            this.productManifactDetailService = productManifactDetailService;
        }

        public void AddQuestion(Question question)
        {
            _context.Question.Add(question);
            _context.SaveChanges();
        }

        public QualityFormSubAnswer GetOrAddQualityAnswer(int productPlanId)
        {
            var qualityFormSub = _context.QualityFormSub.Include(x => x.Questions).FirstOrDefault();
            QualityFormSubAnswer answer = new QualityFormSubAnswer();
            answer.QualityFormSubId = qualityFormSub.Id;
            foreach (var item in qualityFormSub.Questions)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();
                questionAnswer.QuestionId = item.Id;
                _context.QuestionAnswer.Add(questionAnswer);

            }
            _context.QualityFormSubAnswer.Add(answer);
            _context.SaveChanges();
            return _context.QualityFormSubAnswer.Where(x => x.Id == answer.Id).Include(x => x.QualityFormSub).ThenInclude(x => x.Questions).FirstOrDefault();
        }

        public QualityFormSubAnswer GetOrAddQualityAnswerByManifactId(int manifactId)
        {
            var ex = new QualityFormSubAnswer();
            foreach (var exqualityAnswer in _context.QualityFormSubAnswer.ToList())
            {
                if (StringToIntArray(exqualityAnswer.ProductManifactsId).Contains(manifactId))
                {
                    ex = exqualityAnswer;
                }
            }
            if (ex.Id != 0)
            {
                return _context.QualityFormSubAnswer.Where(x => x.Id == ex.Id).Include(x => x.QuestionAnswers).Include(x => x.QualityFormSub).ThenInclude(x => x.Questions).FirstOrDefault();
            }
            var manifact = _context.ProductManifacts2.Where(x => x.Id == manifactId).Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned)
                .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan).ToList();

            var qualityForms = _context.QualityFormSubAnswer.ToList().Select(x => x.ProductManifactsId);
            var allQualityAnswers = _context.QualityFormSubAnswer.ToList();

            var qualityFormSub = _context.QualityFormSub.Where(x => x.BetonDemirTipi == BetonDemirTipi.Demir).Include(x => x.Questions).FirstOrDefault();
            QualityFormSubAnswer qualityFormSubAnswer = new QualityFormSubAnswer();
            qualityFormSubAnswer.DokumanTarihi = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
            qualityFormSubAnswer.ElemanAdi = manifact.FirstOrDefault().ProductPlanProductPlanned.Name;
            qualityFormSubAnswer.MusteriAdi = manifact.FirstOrDefault().ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.ProductPlan.Name;
            qualityFormSubAnswer.QualityFormSubId = qualityFormSub.Id;
            int[] manIds = manifact.Select(x => x.Id).ToArray();
            qualityFormSubAnswer.ProductManifactsId = IntArrayToString(manifact.Select(x => x.Id).ToArray());
            _context.QualityFormSubAnswer.Add(qualityFormSubAnswer);
            _context.SaveChanges();
            foreach (var item in qualityFormSub.Questions)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();
                questionAnswer.QualityFormSubAnswerId = qualityFormSubAnswer.Id;
                questionAnswer.QuestionId = item.Id;
                _context.QuestionAnswer.Add(questionAnswer);
            }
            _context.SaveChanges();
            return _context.QualityFormSubAnswer.Where(x => x.Id == qualityFormSubAnswer.Id).Include(x => x.QuestionAnswers).Include(x => x.QualityFormSub).ThenInclude(x => x.Questions).FirstOrDefault();

        }

        public QualityFormSub GetOrAddQualityFormAnswer(int stepId)
        {
            throw new NotImplementedException();
        }

        public QualityFormSub GetOrAddQualityFormSub(int stepId)
        {
            var qualityFormSub = _context.QualityFormSub.Where(x => x.Id == stepId).Include(x => x.Questions).FirstOrDefault();
            if (qualityFormSub != null)
            {
                return qualityFormSub;
            }
            else
            {
                QualityFormSub qualityFormSub1 = new QualityFormSub();
                _context.QualityFormSub.Add(qualityFormSub1);
                _context.SaveChanges();
                return qualityFormSub1;
            }
        }

        public QualityFormSub GetQualityForm(int Id)
        {
            var qualityFormSub = _context.QualityFormSub.Where(x => x.Id == Id).Include(x => x.Questions).FirstOrDefault();
            if (qualityFormSub != null)
            {
                return qualityFormSub;
            }
            else
            {
                QualityFormSub qualityFormSub1 = new QualityFormSub();
                _context.QualityFormSub.Add(qualityFormSub1);
                _context.SaveChanges();
                return qualityFormSub1;
            }
        }
        public static string IntArrayToString(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return "";
            }

            return string.Join("-", array);
        }
        public static int[] StringToIntArray(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new int[0];
            }

            string[] parts = str.Split('-');
            List<int> tempList = new List<int>();

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int num))
                {
                    tempList.Add(num);
                }
                else
                {
                    // Hata durumunda uygun bir işlem yapabilirsiniz.
                    Console.WriteLine($"'{part}' is not a valid integer.");
                }
            }

            return tempList.ToArray();
        }

        public async Task UpdateQualityFormSubAnswer(QualityFormSubAnswer qualityFormSubAnswer)
        {
            QualityFormSubAnswer qualityFormSubAnswer1 = _context.QualityFormSubAnswer.Where(x => x.Id == qualityFormSubAnswer.Id).FirstOrDefault();
            qualityFormSubAnswer1.DokumanTarihi = qualityFormSubAnswer.DokumanTarihi;
            qualityFormSubAnswer1.KalipNo = qualityFormSubAnswer.KalipNo;
            qualityFormSubAnswer1.DonatiSinifi = qualityFormSubAnswer.DonatiSinifi;
            qualityFormSubAnswer1.KalipNo = qualityFormSubAnswer.KalipNo;
            qualityFormSubAnswer1.QualityFormFinalType = qualityFormSubAnswer.QualityFormFinalType;
            var manifactDetail = StringToIntArray(qualityFormSubAnswer1.ProductManifactsId);
            foreach (var id in manifactDetail)
            {
                if (qualityFormSubAnswer.QualityFormFinalType == QualityFormFinalType.Uygun)
                {
                    qualityFormSubAnswer1.QualityFormFinalType = QualityFormFinalType.Uygun;
                    var productManifat = productManifactDetailService.GetByActiveManifactInclude(id);
                    productManifat.EndDate = DateTime.Now;
                    productManifat.ProductStepEnum = ProductStepDurumEnum.Finish;
                    var siradaki = productManifactDetailService.GetByIdNextInclude(productManifat.Id);
                    if (siradaki != null)
                    {
                        siradaki.ProductStepEnum = ProductStepDurumEnum.Start;
                        siradaki.StartDate = DateTime.Now;
                        productManifactDetailService.Update(siradaki);
                        productManifactDetailService.Update(productManifat);
                    }
                    _context.SaveChanges();
                }
            }
            if (qualityFormSubAnswer.QuestionAnswers != null)
            {
                foreach (var item in qualityFormSubAnswer.QuestionAnswers)
                {
                    if (item.Id == 0)
                    {
                        QuestionAnswer questionAnswer = new QuestionAnswer();
                        questionAnswer.QualityFormSubAnswerId = qualityFormSubAnswer.Id;
                        questionAnswer.QuestionId = item.QuestionId;
                        questionAnswer.AnswerType = item.AnswerType;
                        questionAnswer.Desc = item.Desc;
                        _context.QuestionAnswer.Add(questionAnswer);
                    }
                    else
                    {
                        item.QualityFormSubAnswerId = qualityFormSubAnswer.Id;
                        _context.QuestionAnswer.Update(item);

                    }
                    try
                    {
                        _context.SaveChanges();

                    }
                    catch (Exception)
                    {

                        continue;
                    }
                }
                _context.QualityFormSubAnswer.Update(qualityFormSubAnswer1);
                try
                {

                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public QualityFormSubAnswer GetOrAddQualityAnswerByManifactIdsToplu(int[] manifactIds)
        {
            var ex = new QualityFormSubAnswer();
            var exqualityAnswers = _context.QualityFormSubAnswer.Where(x => x.ProductManifactsId != "" && x.ProductManifactsId != null).ToList();
            foreach (var exqualityAnswer in exqualityAnswers)
            {
                if (exqualityAnswer.ProductManifactsId != null)
                {
                    try
                    {
                        var productManifactIds = StringToIntArray(exqualityAnswer.ProductManifactsId);
                        if (manifactIds.Any(manifactId => productManifactIds.Contains(manifactId)))
                        {
                            ex = _context.QualityFormSubAnswer
                                .Where(x => x.Id == exqualityAnswer.Id)
                                .Include(x => x.QuestionAnswers)
                                .Include(x => x.QualityFormSub)
                                    .ThenInclude(x => x.Questions)
                                .FirstOrDefault();
                        }
                    }
                    catch (Exception)
                    {

                        continue;
                    }

                }

            }
            if (ex.Id != 0)
            {
                return _context.QualityFormSubAnswer.Where(x => x.Id == ex.Id).Include(x => x.QuestionAnswers).Include(x => x.QualityFormSub).ThenInclude(x => x.Questions).FirstOrDefault();
            }
            var manifactDetails = _context.ProductManifactDetails.Where(x => manifactIds.Contains(x.Id)).Include(x => x.ProductManifact).ToList().Select(x => x.ProductManifact.Id).ToArray();
            manifactIds = manifactDetails;
            var manifact = _context.ProductManifacts2.Where(x => manifactIds.Contains(x.Id)).Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned)
               .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan).Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned)
               .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.Pattern).ToList();

            var qualityForms = _context.QualityFormSubAnswer.ToList().Select(x => x.ProductManifactsId);
            var allQualityAnswers = _context.QualityFormSubAnswer.ToList();

            // Şimdi C# kodu kullanarak filtreleme işlemlerini gerçekleştirin



            var qualityFormSub = _context.QualityFormSub.Where(x => x.BetonDemirTipi == BetonDemirTipi.Demir).Include(x => x.Questions).FirstOrDefault();
            QualityFormSubAnswer qualityFormSubAnswer = new QualityFormSubAnswer();
            qualityFormSubAnswer.DokumanTarihi = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
            qualityFormSubAnswer.ElemanAdi = manifact.FirstOrDefault().ProductPlanProductPlanned.Name;
            qualityFormSubAnswer.QualityFormSubId = qualityFormSub.Id;
            var grouped = manifact
                        .GroupBy(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.ProductPlan.Name)
                        .Select(g => g.Key);
            var groupedElemanAd = manifact
                        .GroupBy(x => x.ProductPlanProductPlanned.Name)
                        .Select(g => g.Key);
            var groupedKalipAd = manifact
                        .GroupBy(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.Pattern.Name)
                        .Select(g => g.Key);
            var musteriAdi = string.Join(" - ", grouped);
            var elemanAdi = string.Join(" - ", groupedElemanAd);
            var kalipAdi = string.Join(" - ", groupedKalipAd);
            qualityFormSubAnswer.MusteriAdi = musteriAdi;
            qualityFormSubAnswer.ElemanAdi = elemanAdi;
            qualityFormSubAnswer.KalipNo = kalipAdi;
            int[] manIds = manifact.Select(x => x.Id).ToArray();
            qualityFormSubAnswer.ProductManifactsId = IntArrayToString(manifact.Select(x => x.Id).ToArray());
            _context.QualityFormSubAnswer.Add(qualityFormSubAnswer);
            _context.SaveChanges();
            foreach (var item in qualityFormSub.Questions)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();
                questionAnswer.QualityFormSubAnswerId = qualityFormSubAnswer.Id;
                questionAnswer.QuestionId = item.Id;
                _context.QuestionAnswer.Add(questionAnswer);
            }
            _context.SaveChanges();
            return qualityFormSubAnswer;

        }

        public QualityFormSub GetOrAddQualityFormSubBySubId(int subId)
        {
            var qualityFormSub = _context.QualityFormSub.Where(x => x.Id == subId).Include(x => x.Questions).FirstOrDefault();
            if (qualityFormSub != null)
            {
                return qualityFormSub;
            }
            else
            {
                QualityFormSub qualityFormSub1 = new QualityFormSub();
                _context.QualityFormSub.Add(qualityFormSub1);
                _context.SaveChanges();
                return qualityFormSub1;
            }
        }

        public QualityFormSubAnswer GetOrAddQualityAnswerByManifactIdAtamayaGore(int manifactId)
        {
            var ex = new QualityFormSubAnswer();
            foreach (var exqualityAnswer in _context.QualityFormSubAnswer.ToList())
            {
                if (StringToIntArray(exqualityAnswer.ProductManifactsId).Contains(manifactId))
                {
                    ex = exqualityAnswer;
                }
            }
            if (ex.Id != 0)
            {
                return _context.QualityFormSubAnswer.Where(x => x.Id == ex.Id).Include(x => x.QuestionAnswers).Include(x => x.QualityFormSub).ThenInclude(x => x.Questions).FirstOrDefault();
            }
            var manifact = _context.ProductManifacts2.Where(x => x.Id == manifactId).Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned)
                .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan).ToList();

            var qualityForms = _context.QualityFormSubAnswer.ToList().Select(x => x.ProductManifactsId);
            var allQualityAnswers = _context.QualityFormSubAnswer.ToList();

            var qualityFormSub = _context.QualityFormSub.Where(x => x.BetonDemirTipi == BetonDemirTipi.Beton).Include(x => x.Questions).FirstOrDefault();
            QualityFormSubAnswer qualityFormSubAnswer = new QualityFormSubAnswer();
            qualityFormSubAnswer.DokumanTarihi = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
            qualityFormSubAnswer.ElemanAdi = manifact.FirstOrDefault().ProductPlanProductPlanned.Name;
            qualityFormSubAnswer.MusteriAdi = manifact.FirstOrDefault().ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.ProductPlan.Name;
            qualityFormSubAnswer.QualityFormSubId = qualityFormSub.Id;
            int[] manIds = manifact.Select(x => x.Id).ToArray();
            qualityFormSubAnswer.ProductManifactsId = IntArrayToString(manifact.Select(x => x.Id).ToArray());
            _context.QualityFormSubAnswer.Add(qualityFormSubAnswer);
            _context.SaveChanges();
            foreach (var item in qualityFormSub.Questions)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();
                questionAnswer.QualityFormSubAnswerId = qualityFormSubAnswer.Id;
                questionAnswer.QuestionId = item.Id;
                _context.QuestionAnswer.Add(questionAnswer);
            }
            _context.SaveChanges();
            return _context.QualityFormSubAnswer.Where(x => x.Id == qualityFormSubAnswer.Id).Include(x => x.QuestionAnswers).Include(x => x.QualityFormSub).ThenInclude(x => x.Questions).FirstOrDefault();
        }

        public QualityFormSubAnswer GetOrAddQualityAnswerByManifactIdsTopluAtamayaGore(int[] manifactIds)
        {
            var ex = new QualityFormSubAnswer();
            var exqualityAnswers = _context.QualityFormSubAnswer.Where(x => x.ProductManifactsId != "" && x.ProductManifactsId != null).ToList();
            var manifactDetails = _context.ProductManifactDetails.Where(x => manifactIds.Contains(x.Id)).Include(x => x.ProductManifact).ToList().Select(x => x.ProductManifact.Id).ToArray();
            manifactIds = manifactDetails;
            foreach (var exqualityAnswer in exqualityAnswers)
            {
                if (exqualityAnswer.ProductManifactsId != null)
                {
                    try
                    {
                        var productManifactIds = StringToIntArray(exqualityAnswer.ProductManifactsId);
                        if (manifactIds.Any(manifactId => productManifactIds.Contains(manifactId)))
                        {
                            ex = _context.QualityFormSubAnswer
                                .Where(x => x.Id == exqualityAnswer.Id)
                                .Include(x => x.QuestionAnswers)
                                .Include(x => x.QualityFormSub)
                                    .ThenInclude(x => x.Questions)
                                .FirstOrDefault();
                        }
                    }
                    catch (Exception)
                    {

                        continue;
                    }

                }

            }
            if (ex.Id != 0)
            {
                return _context.QualityFormSubAnswer.Where(x => x.Id == ex.Id).Include(x => x.QuestionAnswers).Include(x => x.QualityFormSub).ThenInclude(x => x.Questions).FirstOrDefault();
            }

            var manifact = _context.ProductManifacts2.Where(x => manifactIds.Contains(x.Id)).Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned)
               .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.ProductPlan).Include(x => x.ProductPlanProductPlanned).ThenInclude(x => x.ProductPlanDailyPlanned)
               .ThenInclude(x => x.ProductPlanSubPlanned).ThenInclude(x => x.Pattern).ToList();

            var qualityForms = _context.QualityFormSubAnswer.ToList().Select(x => x.ProductManifactsId);
            var allQualityAnswers = _context.QualityFormSubAnswer.ToList();


            var qualityFormSub = _context.QualityFormSub.Where(x => x.BetonDemirTipi == BetonDemirTipi.Beton).Include(x => x.Questions).FirstOrDefault();
            QualityFormSubAnswer qualityFormSubAnswer = new QualityFormSubAnswer();
            qualityFormSubAnswer.DokumanTarihi = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
            qualityFormSubAnswer.ElemanAdi = manifact.FirstOrDefault().ProductPlanProductPlanned.Name;
            qualityFormSubAnswer.QualityFormSubId = qualityFormSub.Id;
            var grouped = manifact
                        .GroupBy(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.ProductPlan.Name)
                        .Select(g => g.Key);
            var groupedElemanAd = manifact
                        .GroupBy(x => x.ProductPlanProductPlanned.Name)
                        .Select(g => g.Key);
            var groupedKalipAd = manifact
                        .GroupBy(x => x.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.Pattern.Name)
                        .Select(g => g.Key);
            var musteriAdi = string.Join(" - ", grouped);
            var elemanAdi = string.Join(" - ", groupedElemanAd);
            var kalipAdi = string.Join(" - ", groupedKalipAd);
            qualityFormSubAnswer.MusteriAdi = musteriAdi;
            qualityFormSubAnswer.ElemanAdi = elemanAdi;
            qualityFormSubAnswer.KalipNo = kalipAdi;
            int[] manIds = manifact.Select(x => x.Id).ToArray();
            qualityFormSubAnswer.ProductManifactsId = IntArrayToString(manifact.Select(x => x.Id).ToArray());
            _context.QualityFormSubAnswer.Add(qualityFormSubAnswer);
            _context.SaveChanges();
            foreach (var item in qualityFormSub.Questions)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();
                questionAnswer.QualityFormSubAnswerId = qualityFormSubAnswer.Id;
                questionAnswer.QuestionId = item.Id;
                _context.QuestionAnswer.Add(questionAnswer);
            }
            _context.SaveChanges();
            return qualityFormSubAnswer;
        }

        public QualityFormSubAnswer DemirFormuEkle(int[] urunIdler)
        {
            QualityFormSubAnswer qualityFormSubAnswer = new QualityFormSubAnswer();

            var urunler = _context.ProductPlanProductPlanned
                .Where(x => urunIdler.Contains(x.Id))
                .Include(x => x.ProductPlanDailyPlanned)
                .ThenInclude(x => x.ProductPlanSubPlanned)
                .ToList();

            var uretimEmirleri = _context.ProductManifacts2
                .Where(x => urunIdler.Contains(x.ProductPlanProductPlannedId))
                .Include(x => x.ProductManifactDetail)
                .ThenInclude(x => x.ProjectElementStep)
                .ThenInclude(x => x.ProductionStep)
                .ThenInclude(x => x.ManifactStepType)
                .ToList();

            var demirVeSonAdimManifactDetail = uretimEmirleri
                .SelectMany(x => x.ProductManifactDetail)
                .Where(detail => detail.ProjectElementStep.ProductionStep.ManifactStepType.Name == "Demir" &&
                                 detail.ProjectElementStep.LastStep == true)
                .ToList();
            int qualityFormSubId = (int)demirVeSonAdimManifactDetail.FirstOrDefault().ProjectElementStep.ProductionStep.QualityFormSubId;
            QualityFormSub qualityFormSub = _context.QualityFormSub.Where(x => x.Id == qualityFormSubId).Include(x => x.Questions).FirstOrDefault();

            qualityFormSubAnswer.QualityFormSubId = qualityFormSub.Id;
            qualityFormSubAnswer.ProductManifactsId = string.Join("-", uretimEmirleri.Select(d => d.Id));
            qualityFormSubAnswer.ProductManifactsDetailsId = string.Join("-", demirVeSonAdimManifactDetail.Select(d => d.Id));
            qualityFormSubAnswer.UrunlerId = string.Join("-", urunIdler);
            qualityFormSubAnswer.UrunAdedi = urunIdler.Length.ToString();
            qualityFormSubAnswer.ElemanAdi = string.Join(" / ", urunler.Select(x => x.Name));
            qualityFormSubAnswer.MusteriAdi = urunler.FirstOrDefault()?.ProductPlanDailyPlanned.ProductPlanSubPlanned.Name;
            qualityFormSubAnswer.DokumanTarihi = DateTime.Now.ToString("dd.MM.yyyy");
            qualityFormSubAnswer.DokumanNo = qualityFormSub.Code + " / " + _context.QualityFormSub.Count().ToString("00");
            _context.Add(qualityFormSubAnswer);
            _context.SaveChanges();
            foreach (var item in qualityFormSub.Questions)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();
                questionAnswer.QuestionId = item.Id;
                questionAnswer.QualityFormSubAnswerId = qualityFormSubAnswer.Id;
                _context.QuestionAnswer.Add(questionAnswer);
                _context.SaveChanges();

            }
            return qualityFormSubAnswer;
        }

        public List<QualityFormSubAnswer> DoldurulanFormlar(string? arama, DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 10)
        {
            IQueryable<QualityFormSubAnswer> query = _context.QualityFormSubAnswer
       .Include(x => x.QualityFormSub)
       .Include(x => x.QuestionAnswers);

            if (!string.IsNullOrEmpty(arama))
            {
                query = query.Where(x => x.MusteriAdi.Contains(arama) ||
                                         x.ElemanAdi.Contains(arama) ||
                                         x.DokumanNo.Contains(arama));
            }



            var formlar = query.OrderByDescending(x => x.Id)
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

            return formlar.ToList();
        }

        public QualityFormSubAnswer GelFormSubInclude(int id)
        {
            return _context.QualityFormSubAnswer.Where(x => x.Id == id).Include(x => x.QuestionAnswers).Include(x => x.QualityFormSub).ThenInclude(x => x.Questions).FirstOrDefault();
        }

        public int DoldurulanFormlarTotal(string? arama, DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 10)
        {

            IQueryable<QualityFormSubAnswer> query = _context.QualityFormSubAnswer
       .Include(x => x.QualityFormSub)
       .Include(x => x.QuestionAnswers);

            if (!string.IsNullOrEmpty(arama))
            {
                query = query.Where(x => x.MusteriAdi.Contains(arama) ||
                                         x.ElemanAdi.Contains(arama) ||
                                         x.DokumanNo.Contains(arama));
            }

            return query.Count();
        }

        public QualityFormSubAnswer DigerFormEkle(int[] urunIdler)
        {
            QualityFormSubAnswer qualityFormSubAnswer = new QualityFormSubAnswer();

            var urunler = _context.ProductPlanProductPlanned
                .Where(x => urunIdler.Contains(x.Id))
                .Include(x => x.ProductPlanDailyPlanned)
                .ThenInclude(x => x.ProductPlanSubPlanned)
                .ToList();

            var uretimEmirleri = _context.ProductManifacts2
                .Where(x => urunIdler.Contains(x.ProductPlanProductPlannedId))
                .Include(x => x.ProductManifactDetail)
                .ThenInclude(x => x.ProjectElementStep)
                .ThenInclude(x => x.ProductionStep)
                .ThenInclude(x => x.ManifactStepType)
                .ToList();

            var demirVeSonAdimManifactDetail = uretimEmirleri
                .SelectMany(x => x.ProductManifactDetail)
                .Where(detail => detail.ProjectElementStep.ProductionStep.ManifactStepType.Name.ToUpper() == "BETON" &&
                                 detail.ProjectElementStep.ProductionStep.IsQuality == true).ToList();

            int qualityFormSubId = (int)demirVeSonAdimManifactDetail.FirstOrDefault().ProjectElementStep.ProductionStep.QualityFormSubId;
            QualityFormSub qualityFormSub = _context.QualityFormSub.Where(x => x.Id == qualityFormSubId).Include(x => x.Questions).FirstOrDefault();

            qualityFormSubAnswer.QualityFormSubId = qualityFormSub.Id;
            qualityFormSubAnswer.ProductManifactsId = string.Join("-", uretimEmirleri.Select(d => d.Id));
            qualityFormSubAnswer.ProductManifactsDetailsId = string.Join("-", demirVeSonAdimManifactDetail.Select(d => d.Id));
            qualityFormSubAnswer.UrunlerId = string.Join("-", urunIdler);
            qualityFormSubAnswer.UrunAdedi = urunIdler.Length.ToString();
            qualityFormSubAnswer.ElemanAdi = string.Join(" / ", urunler.Select(x => x.Name));
            qualityFormSubAnswer.MusteriAdi = urunler.FirstOrDefault()?.ProductPlanDailyPlanned.ProductPlanSubPlanned.Name;
            qualityFormSubAnswer.DokumanTarihi = DateTime.Now.ToString("dd.MM.yyyy");
            qualityFormSubAnswer.DokumanNo = qualityFormSub.Code + " / " + _context.QualityFormSub.Count().ToString("00");
            _context.Add(qualityFormSubAnswer);
            _context.SaveChanges();
            foreach (var item in qualityFormSub.Questions)
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();
                questionAnswer.QuestionId = item.Id;
                questionAnswer.QualityFormSubAnswerId = qualityFormSubAnswer.Id;
                _context.QuestionAnswer.Add(questionAnswer);
                _context.SaveChanges();

            }
            return qualityFormSubAnswer;
        }

        public Question SoruGetirId(int id)
        {
            return _context.Question.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task SoruGuncelle(Question question)
        {
            _context.Question.Update(question);
            await _context.SaveChangesAsync();
        }
    }
}
