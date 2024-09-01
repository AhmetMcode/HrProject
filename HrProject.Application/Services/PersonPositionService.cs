using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using System.Globalization;

namespace HrProject.Application.Services
{
    public class PersonPositionService : BaseRepository<PersonPosition>, IPersonPositionService
    {
        public PersonPositionService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public string CreatePositionCode(PersonPosition personPosition)
        {
            string[] words = personPosition.Name.Split(' ');

            string result = string.Join("", words.Select(word => char.ToUpper(word[0], CultureInfo.InvariantCulture)));
            return result;

        }

        public List<SelectListItem> GetPersonPositionsAsSelectListItems()
        {
            var positions = _context.PersonPosition.ToList(); // Veritabanından pozisyonları alın

            // Pozisyonları SelectListItem listesine dönüştürün
            var positionListItems = positions.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(), // Pozisyonun benzersiz kimliği
                Text = p.Name // Pozisyonun adı veya açıklaması
            }).ToList();

            return positionListItems;
        }
    }
}
