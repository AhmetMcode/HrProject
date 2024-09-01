using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services;

public class PersonAnnualLeaveService : BaseRepository<PersonAnnualLeave>, IPersonAnnualLeaveService
{
    public PersonAnnualLeaveService(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public int GetTotalPermissionDay(int personId)
    {
        var person = _context.Personals.FirstOrDefault(x => x.Id == personId);

        if (person == null)
        {
            return 0;
        }
        var experience = (int)((DateTime.Now.Date - person.EntryDate.Date).TotalDays / 365);
        int totalPermission = 0;
        var maxExperience = _context.PersonPermissionRules.Max(rule => rule.WorkingYear);
        if (experience > maxExperience)
        {
            totalPermission = _context.PersonPermissionRules
                                .Where(rule => rule.WorkingYear == maxExperience)
                                .Select(rule => rule.Day)
                                .FirstOrDefault();
        }
        else
        {
            totalPermission = _context.PersonPermissionRules
                                .Where(rule => rule.WorkingYear == experience)
                                .Select(rule => rule.Day)
                                .FirstOrDefault();
        }

        return totalPermission;
    }
    public int GetUsePermission(int personId)
    {
        var person = _context.Personals.FirstOrDefault(x => x.Id == personId);
        var difference = DateTime.Now - person.EntryDate;
        int year = difference.Days / 365;
        var sorguTarihi = person.EntryDate.AddYears(year);
        int kullanilanIzin = _context.PersonAnnualLeaves.Where(x => x.PersonId == personId && x.StartDate.Date > sorguTarihi.Date).ToList().Sum(x => x.UsedDay);
        return kullanilanIzin;
    }
}
