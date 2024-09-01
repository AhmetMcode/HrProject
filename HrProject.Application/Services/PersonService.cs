using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class PersonService : BaseRepository<Person>, IPersonService
    {
        public PersonService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _context.Personals.ToListAsync();
        }

        public async Task<Person?> GetPersonByIdAsync(int personId)
        {
            return await _context.Personals.FindAsync(personId);
        }

        public async Task CalculateSskSalary(int personId, DateTime tarih)
        {
            var person = _context.Personals.Where(x => x.Id == personId).FirstOrDefault();
            var momentSalary = _context.PersonSalaries.Where(x => x.PersonId == personId && x.StartDate.Month == tarih.Month).LastOrDefault();
            decimal CalismasiGerekenSaat = person.WorkingTime;
            decimal mesaiCarpan = person.MesaiCarpan;
            decimal calisilanSaat = Convert.ToDecimal(_context.TallyDetails.Where(x => x.PersonId == personId).ToList().Sum(x => x.WorkTime));
            PersonMounthPayment personMounthPayment = new PersonMounthPayment();
            personMounthPayment.Maas = momentSalary.Salary;
            personMounthPayment.CalisilanSaat += calisilanSaat;
            if (calisilanSaat < CalismasiGerekenSaat)
            {
                personMounthPayment.NetUcret = (momentSalary.Salary / CalismasiGerekenSaat) * calisilanSaat;
            }
            else if (calisilanSaat == CalismasiGerekenSaat)
            {
                personMounthPayment.NetUcret = momentSalary.Salary;
            }
            else
            {
                personMounthPayment.NetUcret = momentSalary.Salary;
                personMounthPayment.IkramiyePrimFazlaMesai = (momentSalary.Salary / CalismasiGerekenSaat) * (calisilanSaat - CalismasiGerekenSaat);
            }
            personMounthPayment.TotalMesai = (calisilanSaat - CalismasiGerekenSaat);
            personMounthPayment.Tarih = tarih;
            personMounthPayment.BesKesintisi = 0;
            personMounthPayment.GelirVergisi = 0;
            personMounthPayment.SgkMatrahi = 0;
            personMounthPayment.VergiMatrahi = 0;
            personMounthPayment.KumuleVergiMatrahi = 0;
            personMounthPayment.BrutUcret = 0;
            personMounthPayment.DamgaVergisi = 0;
            personMounthPayment.GelirVergisiIndirimi = 0;
            _context.PersonMounthPayments.Add(personMounthPayment);
            _context.SaveChanges();
        }

        public Person GetByIdIncDepartman(int id)
        {
            var result = _context.Personals.Include(x => x.Workplace).Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public IEnumerable<Person> GetPersonInclude()
        {
            var result = _context.Personals.Include(x => x.PersonPosition).Include(x => x.PersonSalaries);
            return result;
        }

        public Person GetPersonInclude(int id)
        {
            var result = _context.Personals
                                      .Where(p => p.Id == id)
                                      .Include(p => p.PersonPosition)
                                      .Include(p => p.Workplace)
                                      .Include(p => p.PersonSalaries)
                                      .FirstOrDefault();

            return result;
        }
        public IEnumerable<Person> GetPersonList(string personelName, string tcNo, int? positionId, int? workplaceId, string phoneNumber, string IBAN, int? workingTime)
        {
            var query = _context.Personals
                .Include(p => p.PersonPosition)
                .Include(p => p.Workplace)
                .AsQueryable();

            // İsim filtresi
            if (!string.IsNullOrEmpty(personelName))
            {
                query = query.Where(p => p.Name.Contains(personelName) || p.Surname.Contains(personelName));
            }

            // T.C. No filtresi
            if (!string.IsNullOrEmpty(tcNo))
            {
                query = query.Where(p => p.TcNo.Contains(tcNo));
            }

            // Telefon numarası filtresi
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                query = query.Where(p => p.PhoneNumber.Contains(phoneNumber));
            }

            // Çalışma süresi filtresi
            if (workingTime.HasValue)
            {
                query = query.Where(p => p.WorkingTime == workingTime.Value);
            }

            return query.ToList();
        }

    }
}
