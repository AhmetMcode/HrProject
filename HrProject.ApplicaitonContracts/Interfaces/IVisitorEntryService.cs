using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IVisitorEntryService : IBaseRepository<VisitorEntry>
    {
        public IEnumerable<VisitorEntry> GetIncludeVisitorEntry();
        public void AddToken(MobileToken mobileToken);
        public void UpdateToken(MobileToken mobileToken);
        public List<MobileToken> GetToken();
        public Task<List<MobileToken>> GetTokenUsersByRole(string Role);
        public MobileToken GetTokenUser(string userId);
        public string ConvertTurkishToEnglishfor(string input);

        //public Person GetPersonInfo(int id);

        //public string GetPersonData(int id);
    }

}
