using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class SayimService : ISayimService
    {
        private readonly ApplicationDbContext _context;


        public SayimService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void AddSubSayim(SubSayim subSayim)
        {
            _context.Set<SubSayim>().Add(subSayim);
            _context.SaveChanges();
        }

        public SubSayim GetSubSayimById(int id)
        {
            return _context.Set<SubSayim>()
                .Include(s => s.Depo) // Eagerly load the Depo (Warehouse) entity
                .Include(s => s.ApplicationUser) // Eagerly load the ApplicationUser entity
                .Include(s => s.SayimDetaylar) // Eagerly load the SayimDetaylar collection
                .FirstOrDefault(s => s.Id == id);
        }
        public IEnumerable<SubSayim> GetOngoingSubSayims()
        {
            return _context.SubSayim
                           .Include(s => s.Depo)
                           .Include(s => s.ApplicationUser)
                           .Include(s => s.SayimDetaylar)
                           .ToList();
        }
        public void UpdateSubSayim(SubSayim subSayim)
        {
            _context.Set<SubSayim>().Update(subSayim);
            _context.SaveChanges();
        }

        public void AddStockChange(StockChange stockChange)
        {
            _context.StockChanges.Add(stockChange);
            _context.SaveChanges(); // Ensure this saves the changes immediately
        }
        public Stock GetStockById(int stockId)
        {
            return _context.Stocks
                           .Include(x => x.Unit)
                           .FirstOrDefault(x => x.Id == stockId);
        }
    }
}
