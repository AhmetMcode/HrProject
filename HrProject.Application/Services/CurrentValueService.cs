using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class CurrentValueService : BaseRepository<CurrentValue>, ICurrentValueService
    {
        private readonly ICurrentValueChangeService _currentValueChangeService;
        public CurrentValueService(DbContextOptions<ApplicationDbContext> options, ICurrentValueChangeService currentValueChangeService) : base(options)
        {
            _currentValueChangeService = currentValueChangeService;
        }


        public List<CurrentValue> GetCurrentValuesByInclude()
        {
            return _context.CurrentValues.Include(x => x.Unit).ToList();
        }

        public bool UpdateCurrentValueWithChange(int currentValueId, decimal price)
        {
            CurrentValue currentValue = GetById(currentValueId);
            currentValue.Price = price;
            currentValue.UpdateTime = DateTime.Now;
            Update(currentValue);
            _currentValueChangeService.UpdateValueChange(currentValueId, price);
            return true;

        }
    }
}
