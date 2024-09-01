using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using System.Text;

namespace HrProject.Application.Services
{
    public class VisitorEntryService : BaseRepository<VisitorEntry>, IVisitorEntryService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public VisitorEntryService(DbContextOptions<ApplicationDbContext> options, UserManager<ApplicationUser> userManager) : base(options)
        {
            this.userManager = userManager;
        }

        public void AddToken(MobileToken mobileToken)
        {
            _context.MobileToken.Add(mobileToken);
            _context.SaveChanges();
        }

        public string ConvertTurkishToEnglishfor(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            Dictionary<char, string> turkishToEnglish = new Dictionary<char, string>
    {
        {'ı', "i"},
        {'ğ', "g"},
        {'ü', "u"},
        {'ş', "s"},
        {'ö', "o"},
        {'ç', "c"},
        {'İ', "I"},
        {'Ğ', "G"},
        {'Ü', "U"},
        {'Ş', "S"},
        {'Ö', "O"},
        {'Ç', "C"}
    };

            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (turkishToEnglish.ContainsKey(c))
                {
                    result.Append(turkishToEnglish[c]);
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public IEnumerable<VisitorEntry> GetIncludeVisitorEntry()
        {
            var result = _context.VisitorEntries
                           .Include(x => x.Person)
                           .OrderByDescending(x => x.EntryTime)
                           .ToList();

            return result;
        }

        public List<MobileToken> GetToken()
        {
            return _context.MobileToken.ToList();
        }

        public MobileToken GetTokenUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            var token = _context.MobileToken.Where(x => x.UserId == userId).FirstOrDefault();

            if (token == null)
            {
                // Null olduğunda yapılacak işlemler varsa buraya ekleyebilirsiniz.
            }

            return token;
        }

        public async Task<List<MobileToken>> GetTokenUsersByRole(string Role)
        {
            var usersInRole = await userManager.GetUsersInRoleAsync(Role);
            List<MobileToken> users = new List<MobileToken>();

            foreach (var item in usersInRole)
            {
                var token = _context.MobileToken.Where(x => x.UserId == item.Id).FirstOrDefault();
                if (token != null)
                {
                    users.Add(token);
                }
            }
            return users;
        }

        public void UpdateToken(MobileToken mobileToken)
        {
            _context.MobileToken.Update(mobileToken);
            _context.SaveChanges();
        }
    }
}
