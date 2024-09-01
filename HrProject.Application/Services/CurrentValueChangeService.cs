using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class CurrentValueChangeService : BaseRepository<CurrentValueChange>, ICurrentValueChangeService
    {
        public CurrentValueChangeService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<CurrentValueChange> GetByListCurrentValueId(int currentValueId)
        {
            return Where(x => x.CurrentValueId == currentValueId).OrderByDescending(x => x.StartDate).ToList();
        }
        public CurrentValueChange GetLast(int currentValueId)
        {
            var lastValueChange = _context.CurrentValueChanges
                .Where(x => x.CurrentValueId == currentValueId && x.IsActive)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            return lastValueChange;
        }
        public void UpdateValueChange(int currentValueId, decimal price)
        {
            var lastValue = GetLast(currentValueId);
            if (lastValue == null)
            {
                CurrentValueChange currentValueChange = new CurrentValueChange();
                currentValueChange.StartDate = DateTime.Now;
                currentValueChange.Price = price;
                currentValueChange.CurrentValueId = currentValueId;
                currentValueChange.IsActive = true;
                Insert(currentValueChange);
            }
            else
            {
                lastValue.EndDate = DateTime.Now;
                lastValue.IsActive = false;
                Update(lastValue);
                CurrentValueChange currentValueChange = new CurrentValueChange();
                currentValueChange.StartDate = DateTime.Now;
                currentValueChange.Price = price;
                currentValueChange.CurrentValueId = currentValueId;
                currentValueChange.IsActive = true;
                Insert(currentValueChange);
            }
        }

    }
}
