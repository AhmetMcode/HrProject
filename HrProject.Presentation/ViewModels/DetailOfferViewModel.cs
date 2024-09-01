using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HrProject.Presentation.ViewModels
{
    public class DetailOfferViewModel
    {
        public List<DetailOffer> DetailOffers { get; set; }
        public List<CariKart> CariKarts { get; set; }
        [Required(ErrorMessage = "Teklif türü seçimi zorunludur.")]
        public int FirstOfferId { get; set; }
        public OfferType OfferType { get; set; }
        [Required(ErrorMessage = "Cari kart seçimi zorunludur.")]
        public int CariKartId { get; set; }
        [Required(ErrorMessage = "Mal kodu seçimi zorunludur.")]
        public int GoodsCodeId { get; set; }
        [Required(ErrorMessage = "Stok adı seçimi zorunludur.")]
        public int StockId { get; set; }

        private DateTime _deliveryTime;

        [Required(ErrorMessage = "Son teslim tarihini seçimi zorunludur.")]
        public DateTime DeliveryTime
        {
            get { return _deliveryTime == default ? DateTime.Today : _deliveryTime; }
            set
            {
                if (value.Date >= DateTime.Today)
                {
                    _deliveryTime = value;
                }
                else
                {
                    // Hata işlemleri veya geri bildirim mesajı ekleme
                    throw new InvalidOperationException("Geçmiş tarih seçilemez");
                }
            }
        }



        [Required(ErrorMessage = "Ürün miktarı girilmesi zorunludur.")]
        public decimal Qantity { get; set; }
        [Required(ErrorMessage = "Ürün tipinin girilmesi zorunludur.")]
        public string UnitType { get; set; }
        [Required(ErrorMessage = "Birim Fiyatın girilmesi zorunludur.")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "İskonto oranının girilmesi zorunludur.")]
        public decimal DiscountRate { get; set; }
        public decimal NetPrice { get; set; }
        [Required(ErrorMessage = "KDV durumu seçilmesi zorunludur.")]
        public bool IsVat { get; set; }
        [Required(ErrorMessage = "KDV oranının seçilmesi zorunludur.")]
        public int PurchaseVatId { get; set; }
        public decimal TotalPrice { get; set; }

        private DateTime _priceValidityDate;
        [Required(ErrorMessage = "Fiyat geçerlilik tarihinin seçimi zorunludur.")]
        public DateTime PriceValidityDate
        {
            get { return _priceValidityDate == default ? DateTime.Today : _priceValidityDate; }
            set
            {
                if (value.Date >= DateTime.Today)
                {
                    _priceValidityDate = value;
                }
                else
                {
                    // Hata işlemleri veya geri bildirim mesajı ekleme
                    throw new InvalidOperationException("Geçmiş tarih seçilemez");
                }
            }
        }
        [Required(ErrorMessage = "Ödeme tipinin seçimi zorunludur.")]
        public string PaymentType { get; set; }

        private DateTime _paymentLastDate;
        [Required(ErrorMessage = "Son ödeme tarihinin seçimi zorunludur.")]
        public DateTime PaymentLastDate
        {
            get { return _paymentLastDate == default ? DateTime.Today : _paymentLastDate; }
            set
            {
                if (value.Date >= DateTime.Today)
                {
                    _paymentLastDate = value;
                }
                else
                {
                    // Hata işlemleri veya geri bildirim mesajı ekleme
                    throw new InvalidOperationException("Geçmiş tarih seçilemez");
                }
            }
        }

        public string? Description { get; set; }
    }
}
