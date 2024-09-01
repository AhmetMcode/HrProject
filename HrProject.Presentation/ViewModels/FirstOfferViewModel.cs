using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class FirstOfferViewModel
    {
        public List<FirstOffer> FirstOffers { get; set; }
        public int GoodsCodeId { get; set; }
        public int SubFirstOfferId { get; set; }
        public string StockNames { get; set; }

        private DateTime _deliveryDate;

        public DateTime DeliveryDate
        {
            get { return _deliveryDate == default ? DateTime.Today : _deliveryDate; }
            set
            {
                if (value.Date >= DateTime.Today)
                {
                    _deliveryDate = value;
                }
                else
                {
                    // Hata işlemleri veya geri bildirim mesajı ekleme
                    throw new InvalidOperationException("Geçmiş tarih seçilemez");
                }
            }
        }
        public decimal Quantity { get; set; }
        public string? UnitType { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
    }
}
