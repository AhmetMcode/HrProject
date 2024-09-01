using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class OutWaybillService : BaseRepository<OutWaybill2>, IOutWaybillService
    {
        public OutWaybillService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public void UpdateStockQuantities(OutWaybillChange outWaybillChange)
        {
            // Fatura değişimindeki stok adedini güncelleme kodu buraya gelecek
            var stock = _context.Stocks.FirstOrDefault(s => s.Id == outWaybillChange.StockId);

            if (stock != null)
            {
                // Stok adedini azalt
                stock.Quantity -= outWaybillChange.Quantity;

                _context.Entry(stock).State = EntityState.Modified;
                // Değişiklikleri kaydet
                _context.SaveChanges();
            }
            _context.OutWaybillChanges.Add(outWaybillChange);
            _context.SaveChanges();


        }
        public object GetInvoiceAddress(int id)
        {

            try
            {
                var cariKart = _context.CariKarts
                    .Include(c => c.InvoiceAdresses)
                    .ThenInclude(a => a.City)
                    .Include(c => c.InvoiceAdresses)
                    .ThenInclude(a => a.District)
                    .FirstOrDefault(c => c.Id == id);

                if (cariKart != null)
                {

                    return cariKart;
                }

                return null;
            }
            catch (Exception ex)
            {
                // Hata durumunu logla veya işle
                Console.WriteLine("Hata oluştu: " + ex.Message);
                return null;
            }
        }

        public string UpdateWaybillNo(DateTime editDate, int cariKartId)
        {
            try
            {
                var cariKart = _context.CariKarts.FirstOrDefault(c => c.Id == cariKartId);

                if (cariKart != null)
                {
                    // İlk üç karakteri al
                    string firstThreeChars = _context.InfoCompany.FirstOrDefault().FaturaHarf;

                    // Yılın son iki hanesini al
                    string year = editDate.ToString("yyyy");



                    string counter = (_context.OutWaybills2.Count() + 1).ToString("D9");

                    string waybillNo = firstThreeChars + year + counter;

                    return waybillNo;


                }

                return null;
            }
            catch (Exception ex)
            {
                // Hata durumunu logla veya işle
                Console.WriteLine("Hata oluştu: " + ex.Message);
                return null;
            }
        }

        public void AddOutWayBillService(OutWaybill2 outWaybill2)
        {
            outWaybill2.InWay = false;
            _context.OutWaybills2.Add(outWaybill2);
            _context.SaveChanges();
            foreach (var item in outWaybill2.OutWaybillChanges)
            {
                decimal carpan = 1;
                var stock = _context.Stocks.Where(x => x.Id == item.StockId).Include(x => x.Unit).FirstOrDefault();
                if (stock.UnitId != item.UnitId)
                {
                    carpan = _context.StockUnits.Where(x => x.StockId == stock.Id && x.UnitId == item.UnitId).FirstOrDefault().Carpan;
                }
                StockChange stockChange = new StockChange();
                stockChange.StockId = item.StockId;
                stockChange.OutWaybill2Id = outWaybill2.Id;
                stockChange.DateChange = DateTime.Now;
                stockChange.Quantity = -(((decimal)item.Quantity) * ((decimal)carpan));
                stockChange.StockChangeEnum = Domain.Enums.StockChangeEnum.StokCikis;
                stockChange.UnitType = _context.Units.Where(x => x.Id == item.UnitId).FirstOrDefault().UnitName;
                stockChange.ExitWareHouseId = item.WareHouseId;
                _context.StockChanges.Add(stockChange);
                _context.SaveChanges();
                stock.Quantity -= (item.Quantity * ((double)carpan));
                _context.Stocks.Update(stock);
                _context.SaveChanges();

            }
        }


    }
}
