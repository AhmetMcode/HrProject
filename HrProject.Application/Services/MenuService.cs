using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class MenuService : BaseRepository<Menu>, IMenuService
    {
        public MenuService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public List<Menu> GetMenuByDate(DateTime tarih)
        {
            var menu = new List<Menu>();
            menu = _context.Menus.Where(x => x.DateTime.Date == tarih.Date).Include(x => x.MenuDetails).ThenInclude(x => x.Meal).ThenInclude(x => x.NewFoods).ToList();
            return menu;
        }
        public void CompleteMealService(int mealId)
        {
            var menu = _context.Menus
                .Include(m => m.MenuDetails)
                .ThenInclude(md => md.Meal)
                .ThenInclude(m => m.NewFoods)
                .FirstOrDefault(m => m.Id == mealId);

            if (menu != null)
            {
                foreach (var menuDetail in menu.MenuDetails)
                {
                    foreach (var newFood in menuDetail.Meal.NewFoods)
                    {
                        // Stok değişimi yap
                        StockChange stockChange = new StockChange
                        {
                            StockId = newFood.StockId,
                            Quantity = (decimal)-(newFood.Quantity * menu.PersonQuant), // PersonQuant ile çarpıldı
                            UnitType = _context.Units.Where(u => u.Id == newFood.UnitId).FirstOrDefault()?.UnitName,
                            StockChangeEnum = Domain.Enums.StockChangeEnum.StokCikis,
                            DateChange = menu.DateTime,
                            //ExitWareHouseId = // Burada uygun bir değeri atamalısınız,
                            // Diğer özellikleri de ayarlamalısınız
                        };

                        _context.StockChanges.Add(stockChange);
                        _context.SaveChanges();

                        // Stok miktarını güncelle
                        var stock = _context.Stocks.Find(newFood.StockId);
                        if (stock != null)
                        {
                            if (stock.Quantity == null)
                            {
                                stock.Quantity = 0;
                            }
                            stock.Quantity -= newFood.Quantity * menu.PersonQuant; // PersonQuant ile çarpıldı
                            _context.Stocks.Update(stock);
                            _context.SaveChanges();
                        }
                    }
                }

                // İlgili menüyü tamamlandı olarak işaretle

                menu.Completed = true;
                _context.Menus.Update(menu);
                _context.SaveChanges();
            }
        }


    }
}
